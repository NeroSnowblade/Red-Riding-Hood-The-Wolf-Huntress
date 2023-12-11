using UnityEngine;

public class EnemyBatShoot : MonoBehaviour
{
    [SerializeField] float visibility;
    [SerializeField] Transform eye;

    public Transform bulletPos;
    bool isShoot = false;
    float shootTimer = .2f;
    public GameObject bullet;
    public float shootSpeed;
    public Transform playerPos;
    public float RangeAtk;

    public GameObject blood;
    public int enemyHP = 50;

    // Audio
    private AudioManager audioManager;

    private void Awake() {
        playerPos = GameObject.Find("player").transform;
    }

    public void Shooting()
    {
        Debug.Log("pp");
        // audioManager.PlaySound("EnemyShoot");
        if (!isShoot)
        {
            Debug.Log("ppp");
            Vector3 rotation = playerPos.position - bulletPos.position;//variabel untuk membuat rotasi (diambil dari mouse position dikurang object position(object rotasi))
            float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;//variabel untuk membuat derajat rotasi(diambil dari Tangen(variabel rotation(y,x))selain sumbu rotasi)
            bulletPos.rotation = Quaternion.Euler(0, 0, rotz);
            Debug.Log("yy");
            var newPeluru = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            newPeluru.transform.rotation = Quaternion.Euler(rotz+180, -90, 0);
            newPeluru.GetComponent<Rigidbody>().velocity = newPeluru.transform.forward * shootSpeed;
            isShoot = true;
        }
    }

    public void GetHit(int damage)
    {
        enemyHP -= damage;
    }

    public void GetDestroy()
    {
        if (enemyHP < 1)
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            GetHit(10);
            GetDestroy();
            Debug.Log(enemyHP);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Audio 
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogWarning("Audio Manager not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        cekDistance();

        if (isShoot)
        {
            shootTimer -= Time.deltaTime;
        }

        if (shootTimer <= 0)
        {
            isShoot = false;
            shootTimer = 1.38f;
        }
    }

    void cekDistance(){
        float distanceToPlayer = Vector3.Distance(transform.position, playerPos.position);
        //Debug.Log(distanceToPlayer);
        if(distanceToPlayer <= RangeAtk){
            Debug.Log("p");
            Shooting();
        }else{
           Debug.Log("y");
        }
    }
}
