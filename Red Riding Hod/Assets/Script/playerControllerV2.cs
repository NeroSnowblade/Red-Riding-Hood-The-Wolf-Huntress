using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllerV2 : MonoBehaviour
{
    public System.Action OnFiring;
    [SerializeField] Transform bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float bulletForce;
    [SerializeField] Transform weaponRotationPoint;
    //yang diputer sama badannya juga
    [SerializeField] Transform torso;
    [SerializeField] LayerMask enemyLayer;
    Camera cam;

    //Pake charactercontroller aja biar custom movementnya lebih gampang
    CharacterController characterController;

    Quaternion initialRotation;
    float recoilTimer;
    Vector3 recoilVector;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        characterController = GetComponent<CharacterController>();
        initialRotation = torso.rotation;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(recoilTimer > 0)
        {
            //hitung sudut pantul
//            if(hit.normal.y < -0.25f)
                recoilVector = Vector3.Reflect(recoilVector, hit.normal);
        }
        else
            //reset speed kalau nabrak lantai aja
            if(hit.normal.y > 0.25f)
                recoilVector = Vector3.zero;
    }

    void Shoot(Vector3 direction)
    {
        if(AudioManager.Instance)
            AudioManager.Instance.PlaySFX("Shoot");
        for (int i = -2; i < 2; i++)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);//belum jadi
            bullet.transform.forward =  direction;
            bullet.transform.Rotate(i * 3, 0, 0);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletForce;
        }

        OnFiring?.Invoke();
    }

    // Pakai LateUpdate biar bisa ngeoverride animasi
    void LateUpdate()
    {
        if(recoilTimer > 0)
        {
            recoilTimer -= Time.deltaTime;
            RaycastHit raycastHit;
            if(Physics.SphereCast(transform.position, characterController.radius, recoilVector, out raycastHit, recoilVector.magnitude * Time.deltaTime, enemyLayer))
            {
                EnemyController enemyController = raycastHit.transform.GetComponent<EnemyController>();
                if(enemyController)
                {
                    enemyController.Hurt(10);
                }
            }
            characterController.Move(recoilVector * Time.deltaTime);
            weaponRotationPoint.Rotate(Vector3.forward * Time.deltaTime * 14400, Space.Self);
        }else
        {
            weaponRotationPoint.localEulerAngles = new Vector3(0, 78, 0);

            recoilVector.y -= Time.deltaTime * 9; //Custom gravitasi
            recoilVector.x = Mathf.Clamp(recoilVector.x, -2, 2); //batesin horizontal speed, kurang akurat tapi masih ok harusnya
            recoilVector.y = Mathf.Clamp(recoilVector.y, -50, 1);//batesin vertical speed, kecepatan turun harus lebih besar biar gk melayang
            characterController.Move(recoilVector * Time.deltaTime);

            Vector3 screenPosition = Input.mousePosition;
            screenPosition.z = Vector3.Distance(torso.position, cam.transform.position);
            Vector3 cursorPosition = cam.ScreenToWorldPoint(screenPosition);
            cursorPosition.z = torso.position.z;
            Vector3 gunDirection = cursorPosition - torso.position;

            //puter dulu playernya berdasarkan posisi kursor sebelum muter torso
            if(gunDirection.x > 0)
                transform.eulerAngles = Vector3.up * 180;
            else
                transform.eulerAngles = Vector3.up * 0;

            //rotasi akhir = rotasi dari kalkulasi ditambah rotasi awal(initialRotation)
            torso.rotation = Quaternion.LookRotation(gunDirection.normalized);
            torso.Rotate(initialRotation.eulerAngles.x, 0, initialRotation.eulerAngles.z);
            
            if(Input.GetMouseButtonDown(0))
            {
                recoilTimer = 0.25f;
                recoilVector = -gunDirection.normalized * 25;
                Shoot(gunDirection);
            }
        }        
    }
}
