using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldofCollider : MonoBehaviour
{


    public LookAtPlayer lookAtPlayer;


   /* private void OnTriggerStay(Collider collision)
    {
        Debug.Log("트리거 세이" + collision.gameObject.name);
        lookAtPlayer.LookPlayer();
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("트리거 세이" + other.gameObject.name);
            lookAtPlayer.LookPlayer();


            //여기에 쏘는 코드
            //적한테 쏘는 코드 
            //적감지 했다는 걸 알리는 코드 
            // 데미지와 이펙트를 넣으면 쏠때 하는 코드, 
            //총알그자체에 발사코드 쏘는 코드 넣기
            // 그리고 쿨타임마다 쏘는 코드 만들기 TIme.time하기
            //쿨타임쓸일이 많은데 이걸 뭔가 함수화 시키면 되지 않을까? 
            //FUncitonTImer하면 될지도 이걸 반복하면 되긴하는데, 계속 내부적으로 만들 이유는 없잔항
        }
    }
}
