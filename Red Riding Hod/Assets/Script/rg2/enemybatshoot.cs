using UnityEngine;

public class enemybatshoot : MonoBehaviour
{
    public GameObject enemyBullet;
    public Transform player;
    public float shootingCoolDown = 0.5f;
    public float shootSpeed = 40f;

    private float timer;

private void Update()
{
    timer += Time.deltaTime;

    if(timer >= shootingCoolDown)
    {
        ShootPlayer();
        timer = 0f;
    }
}

void ShootPlayer()
{
    Vector3 direction = (player.position - transform.position).normalized;
    GameObject bullet = Instantiate (enemyBullet, transform.position, Quaternion.identity);
    Rigidbody rb = bullet.GetComponent<Rigidbody>();

    rb.velocity = direction * shootSpeed;
    
     Destroy(bullet, 0.1f);


}


}
