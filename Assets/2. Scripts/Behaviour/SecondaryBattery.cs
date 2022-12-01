using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryBattery : MonsterFSM_Behaviour
{

    ShipEnemy shipEnemy;

    [SerializeField]
    private bool imDie = false;
    private void Awake()
    {
        hp = maxHp;
        imDie = false;
        //shipEnemy.TotalHpMax(maxHp); //�̰� �ý������ε� �Ҽ� �ֳ�? new�� �ذ����� 
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        shipEnemy = GetComponentInParent<ShipEnemy>();

        //Debug.Log("�������� ���͸�");
        fsmManager = new StateMachine<MonsterFSM>(this, new stateIdleBattery());
        fsmManager.AddStateList(new stateAtkBattery());
        fsmManager.AddStateList(new stateMainBatteryDie());
        fov = GetComponent<FieldOfView>();

        OnAwakeAtkBehaviour();

        atkRange = nowAtkBehaviour?.atkRange ?? 5.0f;
   

        

        healthSystem = new HealthSystem(maxHp);
        healthBar.Setup(healthSystem);
        
    }

    public override void OnExecuteAttack(int attackIndex)
    {
        if(getFlagLive)
        {
            base.OnExecuteAttack(attackIndex);
        }
      
    }

    public override void setDmg(int dmg, GameObject atkEffectPrefab)
    {
        Debug.Log("�µ�����");
        //�׾��� ?
        if (!getFlagLive)
        {
            //������ ó�� ���� 
            return;
        }


        hp -= dmg;
        healthSystem.Damage(dmg);


        if (atkEffectPrefab)
        {
            Instantiate(atkEffectPrefab, weaponHitTransform); //������ �ً�, ����Ʈ����Ʈ�� �ֳ�
        }

        //������ ���� �ϰ� 0 ���ϰ� �Ǹ� ���� ���°� �ǰ���
        //�ٵ� ������ �����ص� ��� �ִ� ���¸� 
        if (getFlagLive)
        {
            //animator?.SetTrigger("hitTriggerHash"); /�´� �ִϸ��̼�
        }
        else
        {

            //
            //�´� �Ҹ�
            //�´� ����Ʈ �ֱ�
            
            //���� ���¸� stateDie�� ���� ��ȯ 
            fsmManager.ChangeState<stateMainBatteryDie>(); //

        }
    }


}
