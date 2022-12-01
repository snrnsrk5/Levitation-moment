using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTypeAtkBehaviour : AtkBehaviour
{


  
    public override void callAtkMotion(GameObject target = null, Transform posAtkStart = null)
    {
   

        if (target == null && posAtkStart != null)
        {
            return;
        }
        //Ÿ���� �����ִ� �Ű��� 
        

        Vector3 vecProjectile = posAtkStart?.position ?? transform.position;

        if (atkEffectPrefab != null)
        {

           

            //�������� ������� 
            GameObject objProjectile = GameObject.Instantiate<GameObject>(atkEffectPrefab, vecProjectile, Quaternion.identity);
   
            objProjectile.transform.forward = transform.forward;

            CollisionProjectileAtk projectile = objProjectile.GetComponent<CollisionProjectileAtk>();
  
            if (projectile != null)
            {
                projectile.projectileParents = this.gameObject; 
                projectile.target = target; 
                projectile.attackBehaviour = this;
            }
        }

        nowAtkCoolTime = 0.0f;
    }
}