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
        }
    }
}
