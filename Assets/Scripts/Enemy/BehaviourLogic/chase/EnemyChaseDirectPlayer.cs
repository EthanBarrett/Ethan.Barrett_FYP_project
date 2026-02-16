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

        enemy.agent.speed = 7f;
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
