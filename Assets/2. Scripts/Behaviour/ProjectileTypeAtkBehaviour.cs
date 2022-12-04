using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTypeAtkBehaviour : AtkBehaviour
{


  
    public override void callAtkMotion(GameObject target = null, Transform posAtkStart = null)
    {
   

        if (target == null && posAtkStart != null) //Ÿ���� ����, �߻���ġ����
        {
            return;
        }
        //Ÿ���� �����ִ� �Ű��� 
        

        Vector3 vecProjectile = posAtkStart?.position ?? transform.position; //�߻���ġ�� ���̶�� �ڱ���ġ����

        if (atkEffectPrefab != null)
        {

           

            //�������� ������� 
            GameObject objProjectile = GameObject.Instantiate<GameObject>(atkEffectPrefab, vecProjectile, Quaternion.identity);
   
            objProjectile.transform.forward = transform.forward; //������ �θ��� forward�� ����. �� �����ΰ�

            CollisionProjectileAtk projectile = objProjectile.GetComponent<CollisionProjectileAtk>(); //�������� �̰� ������ �̝��� �ϰ�
  
            if (projectile != null)
            {
                projectile.projectileParents = this.gameObject;  //�θ� ����� 
                projectile.target = target; 
                projectile.attackBehaviour = this;
            }
        }

        nowAtkCoolTime = 0.0f;
    }
}