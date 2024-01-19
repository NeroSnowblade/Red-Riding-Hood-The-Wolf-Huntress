using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBosReg1 : MonoBehaviour
{
    private float speed = 5f;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 movedirection;
    public Transform[] targetMove;
    private Vector3 targetPosition;
    public bool isMove;
    public bool keKiri;
    private Rigidbody rb;
    private float cdDiem = 10;
    public float cdDiemTime=0;

    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody>();
       Anim = gameObject.GetComponent<Animator>();
       isMove=false;
       keKiri=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMove){
            move();
        }else
        {
            attackController();
        }
        Animasi(isMove);
        
    }

    void move()
    {
        targetPosition = targetMove[keKiri?0:3].position;
        //transform.Translate(targetPosition*speed*Time.deltaTime);
        //transform.position = Vector3.Lerp(gameObject.transform.position,targetPosition,speed*Time.deltaTime);
        float moveDirection = keKiri ? -1.0f : 1.0f;
        if((gameObject.transform.position.x > targetPosition.x && keKiri)||(gameObject.transform.position.x < targetPosition.x && !keKiri)){
            rb.velocity = new Vector3(moveDirection * speed, rb.velocity.y, 0);
        }
        else{
            rb.velocity = Vector3.zero;
            transform.position = Vector3.Lerp(gameObject.transform.position,targetPosition,speed*Time.deltaTime);
            isMove=false;
        }

    }
    public void jump(float force){
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    void attackController(){
        if(cdDiemTime >= cdDiem){
            keKiri = !keKiri;
            jump(keKiri?9f:5);
            isMove = true;
            float moveDirection = keKiri ? -1.0f : 1.0f;
            rb.velocity = new Vector3(moveDirection * speed, rb.velocity.y, 0);
            cdDiemTime=0;
        }else{
            Facing(keKiri);
            cdDiemTime+=Time.deltaTime;
        }
    }
    void Facing(bool isFaceLeft){
        gameObject.transform.rotation = isFaceLeft ? Quaternion.Euler(0,0,0) : Quaternion.Euler(0,180,0);
    }
    void Animasi(bool run){
        Anim.SetBool("run",run);
    }
}
