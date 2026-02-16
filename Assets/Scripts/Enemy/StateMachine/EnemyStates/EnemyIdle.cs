using UnityEngine;
using UnityEngine.AI;

public class EnemyIdle : EnemyState
{

    // private Vector3 _targetPos;

    public EnemyIdle(Enemys enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {

    }

    public override void EnterState()
    {
        base.EnterState();

        //   _targetPos = GetRandomPoint();
        //    enemy.MoveEnemy(_targetPos);

        //   enemy.agent.speed = 5f;

        enemy.EnemyIdleBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();

        enemy.EnemyIdleBaseInstance.DoEnterLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        enemy.EnemyIdleBaseInstance.DoFrameUpdateLogic();


        /*
                if(enemy.IsAggroed)
               {
                  enemy.StateMachine.ChangeState(enemy.ChaseState);
                }

                if (!enemy.agent.pathPending && enemy.agent.remainingDistance <= enemy.agent.stoppingDistance)
                {
                    _targetPos = GetRandomPoint();
                    enemy.MoveEnemy(_targetPos);
                }
        */

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        enemy.EnemyIdleBaseInstance.DoPhysicsLogic();
    }

    /*
        private Vector3 GetRandomPoint()
        {
            // return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitSphere * enemy.MovementRange;

            //  Vector3 randomPoint = Random.insideUnitSphere * enemy.MovementRange;
            // randomPoint.y = 0f;

            // return enemy.transform.position + randomPoint;

            Vector3 randomPoint = enemy.StartPosition + Random.insideUnitSphere * enemy.MovementRange;

            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, enemy.MovementRange, NavMesh.AllAreas))
            {
                return hit.position;
            }

            return enemy.transform.position;
        }
    */
}

