using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(enemyAtribut))]
public class EnemyController : MonoBehaviour
{
    System.Action _action;
    System.Action action
    {
        get{return _action;}
        set
        {
            _action = value;
            animator.SetBool("IsJumping", value != Idle);
            animator.SetBool("Hurt", value == Hurt);
        }
    }
    Transform playerTransform;
    Vector3 destination;
    Vector3 startPosition;
    Vector3 velocity;
    float cooldown = 0;
    float lerpTimer = 0;
    float lerpSpeed = 1;
    [SerializeField] float attackDistance = 10;
    [SerializeField] LayerMask groundOnly;
    CharacterController characterController;
    enemyAtribut enemyAtribut;
    bool isInvulnerable;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        enemyAtribut = GetComponent<enemyAtribut>();
        animator = GetComponent<Animator>();
        action = Idle;
        cooldown = Random.Range(0,1);
        FindObjectOfType<playerControllerV2>().OnFiring += ResetInvulnerability;
    }

    private void ResetInvulnerability()
    {
        isInvulnerable = false;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //kalo nabrak lantai pas jatuh, idle
        if(hit.normal.y > 0.25f && action == Fall)
        {
            cooldown = Random.Range(1, 2);
            action = Idle;
        }
    }

    void Idle()
    {

        //istirahat dulu
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            return;
        }
        Vector3 delta  = playerTransform.position - transform.position;
        float distance = delta.magnitude;
        if(distance < attackDistance)
            destination = playerTransform.position;
        else
        {
            Vector3 maxPosition = delta.normalized * attackDistance + transform.position;
            RaycastHit raycastHit;
            if(Physics.Raycast(maxPosition, Vector3.down, out raycastHit, 100, groundOnly))
                destination = raycastHit.point;
            else
                destination = maxPosition;//harusnya sih gk mungkin sampai sini XD
        }
        lerpTimer = 0;
        startPosition = transform.position;
        action = JumpTo;
    }

    void JumpTo()
    {
        if(lerpTimer > 1)
        {
            action = Fall;
            return;
        }
        Vector3 prevPosition = transform.position;
        transform.position = Vector3.Lerp(startPosition, destination, lerpTimer) + Vector3.up * Mathf.Sin(Mathf.Deg2Rad * 180 * lerpTimer) * 2;
        velocity = (transform.position - prevPosition) / Time.deltaTime;
        lerpTimer += Time.deltaTime * lerpSpeed;
        if(velocity.x > 0)
            transform.eulerAngles = Vector3.up * 180;
        else
            transform.eulerAngles = Vector3.up * 0;
    }

    void Hurt()
    {
        if(lerpTimer > 0.5)
        {
            action = Fall;
            return;
        }
        Vector3 prevPosition = transform.position;
        transform.position = Vector3.Lerp(startPosition, destination, lerpTimer) + Vector3.up * Mathf.Sin(Mathf.Deg2Rad * 180 * lerpTimer) * 2;
        velocity = (transform.position - prevPosition) / Time.deltaTime;
        lerpTimer += Time.deltaTime * lerpSpeed;
    }

    void Fall()
    {
        characterController.Move(velocity * Time.deltaTime);
        velocity += Time.deltaTime * Vector3.down * 10;
        //jaga2 bisi nembus lantai
        if(transform.position.y < -12)
            Idle();
    }

    // Update is called once per frame
    void Update()
    {
        action?.Invoke();
    }

    void OnDestroy()
    {
        FindObjectOfType<playerControllerV2>().OnFiring -= ResetInvulnerability;
    }

    internal void Hurt(int v)
    {
        if(isInvulnerable)
            return;

        action = Hurt;
        lerpTimer = 0;
        startPosition = transform.position;
        destination = transform.position + transform.right * 2;
        isInvulnerable = true;
        enemyAtribut.TakeDamage(v);
    }
}
