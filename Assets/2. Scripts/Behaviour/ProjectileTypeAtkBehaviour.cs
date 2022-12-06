using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTypeAtkBehaviour : AtkBehaviour
{


  
    public override void callAtkMotion(GameObject target = null, Transform posAtkStart = null)
    {
   

        if (target == null && posAtkStart != null) //타겟이 없고, 발사위치겠지
        {
            return;
        }
        //타겟은 정해주는 거겠지 
        

        Vector3 vecProjectile = posAtkStart?.position ?? transform.position; //발사위치가 널이라면 자기위치에서

        if (atkEffectPrefab != null)
        {

           

            //프리팹이 없어가지고 
            GameObject objProjectile = GameObject.Instantiate<GameObject>(atkEffectPrefab, vecProjectile, Quaternion.identity);
            //근데 왜 이게 아 rprojedtil이 없으니까 타겟도 없구나

            Vector3 l_vector = target.transform.position - transform.position;
            Quaternion ro =  Quaternion.LookRotation(l_vector).normalized; //position은ㅇ 벡터
            objProjectile.transform.forward = transform.forward ; //생성한 부모의 forward를 본다. 음 로컬인가
            objProjectile.transform.rotation = ro;

            
            CollisionProjectileAtk projectile = objProjectile.GetComponent<CollisionProjectileAtk>(); //오브제는 이걸 가지고 이씅니 하고
            //bulletMove에는 CollisionprojectilAtk를 상속안받으니까 시발
  
            if (projectile != null)
            {
                projectile.projectileParents = this.gameObject;  //부모를 현재로 
                projectile.target = target; 
                projectile.attackBehaviour = this;
            }
        }

        nowAtkCoolTime = 0.0f;
    }
}