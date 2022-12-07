using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    public int damage;

    public GameObject target;
    void Start()
    {
        Destroy(gameObject, 5f);

       
  
    }
    private void Update()
    {
        
        transform.Translate((Vector3.forward ) * Time.deltaTime * speed);
    }
    protected virtual void OnProjectileStartCollision(Collider other)
    {
        

        IDmgAble iDmgAble = other.gameObject.GetComponent<IDmgAble>();

        if (iDmgAble != null)
        {
            //Debug.Log("���� ������");
            iDmgAble.setDmg(damage, null); //atk ������ �� �ʿ����?
            DamagePopup.Create(other.transform.position, damage, false);
            //for문으로 
            //�׷��� �÷��̾�� MonsterFsm�� attackBehaviour�� �����ݾ� �׷��� �׷��� 0�̴ϱ� �ȹٲ�ſ���
        }

    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        return;


        
        Debug.Log("OntriggerEnter Bullet");
        OnProjectileStartCollision(other);
    }
}
