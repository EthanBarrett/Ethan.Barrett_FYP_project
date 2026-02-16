using UnityEngine;

public class EnemyChase : EnemyState
{

    // private Transform _player;
    public EnemyChase(Enemys enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        // _player = GameObject.FindGameObjectWithTag("Player").transform;
    }



    public override void EnterState()
    {
        base.EnterState();

        //   enemy.agent.isStopped = false;

        //  enemy.agent.speed = 7f;

        enemy.EnemyChaseBaseInstance.DoEnterLogic();

    }

    public override void ExitState()
    {
        base.ExitState();
        // enemy.agent.isStopped = false;
        // enemy.agent.ResetPath();

        enemy.EnemyChaseBaseInstance.DoEnterLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        enemy.EnemyChaseBaseInstance.DoFrameUpdateLogic();
        /*
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
        */
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        enemy.EnemyChaseBaseInstance.DoPhysicsLogic();

    }
}