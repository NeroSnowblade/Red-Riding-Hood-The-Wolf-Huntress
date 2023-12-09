using UnityEngine;

public class EnemyBatShoot : MonoBehaviour
{
    [SerializeField] float visibility;
    [SerializeField] Transform eye;

    public Transform bulletPos;
    bool isShoot;
    float shootTimer = .2f;
    public GameObject bullet;
    public float shootSpeed;

    public GameObject blood;
    public int enemyHP = 50;

    // Audio
    private AudioManager audioManager;

    bool seeThePlayer(float distance)
    {
        bool val = false;
        float castDist = -distance;
        Vector3 endPos = eye.position + Vector3.left * castDist; // Change Vector3.right to Vector3.left
        RaycastHit hit;

        if (Physics.Raycast(eye.position, endPos - eye.position, out hit, castDist))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            else
            {
                val = false;
            }
        }
        else
        {
            Debug.DrawRay(eye.position, endPos - eye.position, Color.blue);
        }
        return val;
    }

    public void Shooting()
    {
        audioManager.PlaySound("EnemyShoot");
        if (!isShoot)
        {
            GameObject newPeluru = Instantiate(bullet, bulletPos.position, transform.rotation);
            newPeluru.GetComponent<Rigidbody>().velocity = transform.forward * shootSpeed;
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
        if (seeThePlayer(visibility))
        {
            Shooting();
        }
        else
        {
            // Do something else, e.g., stop shooting animation
        }

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
}
