using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "chase-random chase", menuName = "Enemy Logic/chase logic/random chase")]
public class enemyChaseDirectPlayer : EnemyChaseBase
{
    private Transform _player;


    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        enemy.agent.isStopped = false;


        float accuracy = PlayerStats.Instance.fightResults;

        if (accuracy > 70f)
        {
            Debug.Log("speed = 20");
            enemy.agent.speed = 20f;
        }
        else if (accuracy < 30f)
        {
            Debug.Log("speed = 2");
            enemy.agent.speed = 2f;
        }
        else
        {
            Debug.Log("speed = 7");
            enemy.agent.speed = 7f;
        }
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        enemy.agent.ResetPath();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        if (!enemy.IsAggroed)
        {
            enemy.StateMachine.ChangeState(enemy.IdleState);
            return;
        }

       

        enemy.agent.SetDestination(_player.position);

        if (enemy.IsWithinAttack)
        {
            enemy.StateMachine.ChangeState(enemy.AttackState);
        }
    }



    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
    }

    public override void Initialize(GameObject gameObject, Enemys enemys)
    {
        base.Initialize(gameObject, enemys);
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
