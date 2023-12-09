using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public enum Attack{
        attack,
        cd,
        ready,
    };
    public Attack attackState;
    public float cdAttack;
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
    //audio
    private AudioManager audioManager;
    public playerAtribut atribut;

    private Vector3 lastVelocity;
    private Vector3 lastNormal;


    // Start is called before the first frame update
    void Start()
    {
        //audio
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogWarning("audio manager di temukan");
        }

        attackState = Attack.ready;
        isFacing = false;
        bulletForce = 15f;
        recoil = 6f;
        rbPlayer = GameObject.Find("player").GetComponent<Rigidbody>();
        atribut = GameObject.Find("player").GetComponent<playerAtribut>();
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
        lastVelocity = rbPlayer.velocity;
    }
    private void OnCollisionExit()
    {
        lastNormal = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //rata2 normal yang kena ke collider
        Vector3 normal = Vector3.zero;
        for (int i = 0; i < collision.contactCount; i++)
            normal += collision.contacts[i].normal;

        //simpan arah normal buat dipakai pengecekan nanti
        lastNormal = normal;
        //ganti arah recoilPos ke arah pantulan dan dikali setengah
        rbPlayer.velocity = Vector3.Reflect(lastVelocity, normal.normalized) * 0.5f;
    }

    private void OnCollisionStay(Collision collision)
    {
        //rata2 normal yang kena ke collider
        Vector3 normal = Vector3.zero;
        for (int i = 0; i < collision.contactCount; i++)
            normal += collision.contacts[i].normal;

        //simpan arah normal buat dipakai pengecekan nanti
        lastNormal = normal;
    }

    // fungsi player Attak
    void playerAttack()
    {
        if (Input.GetMouseButtonDown(0) && attackState == Attack.ready)
        { // mengetahui jika mouse di tekan ke bawah
            attackState = Attack.attack;
            audioManager.PlaySound("Shoot");
        }
        if (attackState == Attack.attack)
        {
            audioManager.PlaySound("Shoot");
            for (int i = -2; i < 2; i++)
            {
                var bullet = Instantiate(bulletPV, bulletSP.position, bulletSP.rotation);//belum jadi
                Vector3 rotation = mousePosition - rotpoint.position;//variabel untuk membuat rotasi (diambil dari mouse position dikurang object position(object rotasi))
                float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;//variabel untuk membuat derajat rotasi(diambil dari Tangen(variabel rotation(y,x))selain sumbu rotasi)
                bullet.transform.rotation = Quaternion.Euler(180 + rotz + (3f * i), 270, 0);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletForce;
            }
            PlayerMove(mousePosition);
            var Scythe = Instantiate(scythePv, scytheSp.position, Quaternion.identity);
            cdAttack = 0.3f * 1/atribut.atkSpeed;
            attackState = Attack.cd;
        }
        if(attackState == Attack.cd){
            cdAtk();
        }
    }
    // fungsi mengambil posisi mouse
    void getMousePosition()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 13;
        mousePosition = cam.ScreenToWorldPoint(mousePos);
        trMousePos.position = mousePosition;
    }
    //fungsi menggerakan player
    void PlayerMove(Vector3 mousePos)
    {
        Vector3 recoilPos;
        recoilPos = mousePos - gameObject.transform.position; // menentukan arah mousePos
        recoilPos = new Vector3(recoilPos.x, recoilPos.y, recoilPos.z).normalized; // membuat posisi recoilPos menjadi antara -1 sampai 1

        //cek kalau recoilPos mengarah ke arah normal yg terakhir disimpan, kalau iya, ganti arah recoilPos ke arah pantulan dan dikali setengah
        if (lastNormal != Vector3.zero && Vector3.Dot(lastNormal, recoilPos) > 0)
            recoilPos = Vector3.Reflect(recoilPos, lastNormal) * 0.5f;

        rbPlayer.AddForce(new Vector3(recoilPos.x, recoilPos.y, 0) * -recoil, ForceMode.VelocityChange); // memberi gaya recoilPos pada object
    }
    // fungsi rotasi senjata
    void rotateWepon()
    {
        Vector3 rotation = mousePosition - rotpoint.position;//variabel untuk membuat rotasi (diambil dari mouse position dikurang object position(object rotasi))
        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;//variabel untuk membuat derajat rotasi(diambil dari Tangen(variabel rotation(y,x))selain sumbu rotasi)
        rotpoint.transform.rotation = Quaternion.Euler(0, 0, rotz);//membuat rotasi objek sesuai sudud variable rotz
    }
    // facing
    void Facing()
    {
        if (mousePosition.x - transform.position.x < 0 && !isFacing)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            isFacing = true;
        }
        if (mousePosition.x - transform.position.x > 0 && isFacing)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isFacing = false;
        }
    }
    public void cdAtk(){
        if(cdAttack <= 0){
            attackState = Attack.ready;
        }else{
            cdAttack -= Time.deltaTime;
            Debug.Log(cdAttack);
        }
    }

}
