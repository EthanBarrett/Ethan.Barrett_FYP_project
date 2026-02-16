using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ilde-random wander", menuName = "Enemy Logic/idle logic/random wander")]
public class EnemyIdleRandomWander : EnemyIdleBase
{
    private Vector3 _targetPos;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        _targetPos = GetRandomPoint();
        enemy.MoveEnemy(_targetPos);

        enemy.agent.speed = 5f;
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        if (enemy.IsAggroed)
        {
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }

        if (!enemy.agent.pathPending && enemy.agent.remainingDistance <= enemy.agent.stoppingDistance)
        {
            _targetPos = GetRandomPoint();
            enemy.MoveEnemy(_targetPos);
        }

    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
    }

    public override void Initialize(GameObject gameObject, Enemys enemys)
    {
        base.Initialize(gameObject, enemys);
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }

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
}