using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ilde-random wander", menuName = "Enemy Logic/idle logic/random wander")]
public class EnemyIdleRandomWander : EnemyIdleBase
{
    private Vector3 _targetPos;
    private Transform _player;
  
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        float aggression = PlayerStats.Instance.Aggression;

        //speed will change depending on aggression
        if (aggression > 70f)
        {
            enemy.agent.speed = 5f; //playing safe

            //move away from player
            Vector3 direction = (enemy.transform.position - _player.position).normalized;
            _targetPos = enemy.transform.position + direction * enemy.MovementRange;
        }

        else if (aggression < 30f)
        {
            enemy.agent.speed = 10f; //searching
            
            //go to player
            Vector3 direction = (_player.position - enemy.transform.position).normalized;
            _targetPos = enemy.transform.position + direction * Random.Range(10f, enemy.MovementRange);
        }

        else
        {
            enemy.agent.speed = 3f; //normal

            _targetPos = GetRandomPoint();
        }

        
        enemy.MoveEnemy(_targetPos);

        
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        if (enemy.IsWithinAttack)
        {
            enemy.StateMachine.ChangeState(enemy.AttackState);
            return;
        }

        if (enemy.IsAggroed)
        {
            float aggression = PlayerStats.Instance.Aggression;

            if (aggression < 30f)
            {
                // passive player it will chase
                enemy.StateMachine.ChangeState(enemy.ChaseState);
            }
            else
            {

            }
           
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
        _player = GameObject.FindGameObjectWithTag("Player").transform;


    }

    public override void ResetValues()
    {
        base.ResetValues();
    }

    private Vector3 GetRandomPoint()
    {
       

      
        Vector3 randomPoint = enemy.StartPosition + Random.insideUnitSphere * enemy.MovementRange;

        if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, enemy.MovementRange, NavMesh.AllAreas))
        {
            return hit.position;
        }

        return enemy.transform.position;
    }
}