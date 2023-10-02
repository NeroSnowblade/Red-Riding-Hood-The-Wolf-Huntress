using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public bool isAttack;
    bool isFacing;
    Vector3 mousePosition;
    public float recoil;
    public float bulletForce;
    public Rigidbody rbPlayer; //variable untuk mengambil rigidbody player
    public Transform trMousePos; //variable untuk mengembil posisi objek mousePos
    public Transform bulletSP;//variable untuk mengambil posisi spawn poin bullet
    public GameObject bulletPV; //variable untuk mengambil bullet Privab
    public Transform rotpoint; // variable untuk mengambil titik dari rotasi(posisi objek bernama rotasipoint)
    public Camera cam; // variable untuk mengambil camera

    public Transform scytheSp;
    public GameObject scythePv;

    // Start is called before the first frame update
    void Start()
    {
        isAttack = false;
        isFacing = false;
        bulletForce = 15f;  
        recoil = 6f;
        rbPlayer = GameObject.Find("player").GetComponent<Rigidbody>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>(); // memasukan kamera
        rotpoint = GameObject.Find("rotasipoint").transform;
        trMousePos = GameObject.Find("mousePos").transform;
        bulletSP = GameObject.Find("spawnBullet").transform;
        scytheSp = GameObject.Find("scytheSpawnPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        getMousePosition();
        rotateWepon();
        playerAttack();
        Facing();
    }
    // fungsi player Attak
    void playerAttack(){
        
        if(Input.GetMouseButtonDown(0)){ // mengetahui jika mouse di tekan ke bawah
            isAttack = true;
        }
        if (isAttack){
            for (int i = -2; i<2;i++){
                var bullet = Instantiate(bulletPV,bulletSP.position,bulletSP.rotation);//belum jadi
                Vector3 rotation = mousePosition - rotpoint.position;//variabel untuk membuat rotasi (diambil dari mouse position dikurang object position(object rotasi))
                float rotz = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg;//variabel untuk membuat derajat rotasi(diambil dari Tangen(variabel rotation(y,x))selain sumbu rotasi)
                bullet.transform.rotation = Quaternion.Euler(180+rotz+(3f*i),-90,0);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletForce;
            }
            var scythe = Instantiate(scythePv,scytheSp.position,Quaternion.identity);
            PlayerMove(mousePosition);
            isAttack = false;
        }
    }
// fungsi mengambil posisi mouse
    void getMousePosition(){
        var mousePos = Input.mousePosition;
        mousePos.z=13;
        mousePosition = cam.ScreenToWorldPoint(mousePos);
        trMousePos.position = mousePosition;
    }
    //fungsi menggerakan player
    void PlayerMove(Vector3 mousePos){
            Vector3 recoilPos;
            recoilPos = mousePos - gameObject.transform.position; // menentukan arah mousePos
            recoilPos = new Vector3(recoilPos.x,recoilPos.y,recoilPos.z).normalized; // membuat posisi recoilPos menjadi antara -1 sampai 1
            rbPlayer.AddForce(new Vector3(recoilPos.x,recoilPos.y,0) * -recoil,ForceMode.VelocityChange); // memberi gaya recoilPos pada object
    }
    // fungsi rotasi senjata
    void rotateWepon(){
        Vector3 rotation = mousePosition - rotpoint.position;//variabel untuk membuat rotasi (diambil dari mouse position dikurang object position(object rotasi))
        float rotz = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg;//variabel untuk membuat derajat rotasi(diambil dari Tangen(variabel rotation(y,x))selain sumbu rotasi)
        rotpoint.transform.rotation = Quaternion.Euler(0,0,rotz);//membuat rotasi objek sesuai sudud variable rotz
    }
    // facing
    void Facing(){
        if(mousePosition.x - transform.position.x < 0 && !isFacing){
            transform.rotation = Quaternion.Euler(0,180,0);
            isFacing = true;
        }
        if(mousePosition.x - transform.position.x > 0 && isFacing){
            transform.rotation = Quaternion.Euler(0,0,0);
            isFacing = false;
        }
    }
}
