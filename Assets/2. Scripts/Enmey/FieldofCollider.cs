using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldofCollider : MonoBehaviour
{


    public LookAtPlayer lookAtPlayer;


   /* private void OnTriggerStay(Collider collision)
    {
        Debug.Log("Ʈ���� ����" + collision.gameObject.name);
        lookAtPlayer.LookPlayer();
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ʈ���� ����" + other.gameObject.name);
            lookAtPlayer.LookPlayer();


            //���⿡ ��� �ڵ�
            //������ ��� �ڵ� 
            //������ �ߴٴ� �� �˸��� �ڵ� 
            // �������� ����Ʈ�� ������ �� �ϴ� �ڵ�, 
            //�Ѿ˱���ü�� �߻��ڵ� ��� �ڵ� �ֱ�
            // �׸��� ��Ÿ�Ӹ��� ��� �ڵ� ����� TIme.time�ϱ�
            //��Ÿ�Ӿ����� ������ �̰� ���� �Լ�ȭ ��Ű�� ���� ������? 
            //FUncitonTImer�ϸ� ������ �̰� �ݺ��ϸ� �Ǳ��ϴµ�, ��� ���������� ���� ������ ������
        }
    }
}
