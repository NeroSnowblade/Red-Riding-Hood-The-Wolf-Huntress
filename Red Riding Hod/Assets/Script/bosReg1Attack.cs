using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosReg1Attack : MonoBehaviour
{
    public BosReg1Atribut Atribut;
    public moveBosReg1 Move;
    public float atkTime = 0;
    public float atkSpeed = 3;
    public float cdAtk = 0.25f;
    public float cdAtkTime = 0;
    public GameObject BatuPV;
    public Transform BatuSP;
    public float BatuForce = 5;
    public Transform PlayerPos;
    public bool isAtk = false;
    int serangKe = 0;
    // Start is called before the first frame update
    void Start()
    {
        Atribut = gameObject.GetComponent<BosReg1Atribut>();
        Move = gameObject.GetComponent<moveBosReg1>();
    }

    // Update is called once per frame
    void Update()
    {
        Lemparan();
    }

    void Cakaran(){
        
    }
    void Lemparan(){
        if(!Move.isMove){
            if(!isAtk){
                if(atkTime >= atkSpeed){
                    isAtk = true;
                    serangKe = 0;
                    atkTime = 0;
                }else{
                    atkTime += Time.deltaTime;
                }
            }else{
                if(serangKe >= 3){
                    isAtk = false;
                }else{
                    if(cdAtkTime >= cdAtk){
                        PlayerPos = GameObject.Find("player").transform;
                        Vector3 rotation = PlayerPos.position - BatuSP.position;//variabel untuk membuat rotasi (diambil dari mouse position dikurang object position(object rotasi))
                        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;//variabel untuk membuat derajat rotasi(diambil dari Tangen(variabel rotation(y,x))selain sumbu rotasi)
                        BatuSP.transform.rotation = Quaternion.Euler(0, 0, rotz);
                        var Batu = Instantiate(BatuPV, BatuSP.position, BatuSP.rotation);
                        Batu.transform.rotation = Quaternion.Euler(Random.Range(rotz-5,rotz+5)+180, -90, 0);
                        Batu.GetComponent<Rigidbody>().velocity = Batu.transform.forward * BatuForce;
                        cdAtkTime = 0;
                        serangKe += 1;
                    }else{
                        cdAtkTime += Time.deltaTime;
                    }
                }
            }
        }else{
            atkTime = 0;
            cdAtkTime = 0;
        }
    }
}
