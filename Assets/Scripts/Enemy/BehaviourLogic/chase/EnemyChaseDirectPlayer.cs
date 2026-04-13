using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "chase-random chase", menuName = "Enemy Logic/chase logic/random chase")]
public class enemyChaseDirectPlayer : EnemyChaseBase
{
    private Transform _player;

    //zig zag
    private float zTimer;
    private float zInterval = 0.5f;
    private int zDirection = 1;
    private float zAmount = 3f;

    private Vector3 currentZ;
    private bool hasTarget;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        enemy.agent.isStopped = false;

        


        float accuracy = PlayerStats.Instance.fightResults;

        if (accuracy > 70f)
        {
           // Debug.Log("speed = 20");
            enemy.agent.speed = 20f;
            enemy.agent.angularSpeed = 200f;
        }
        else if (accuracy < 30f)
        {
           // Debug.Log("speed = 5");
            enemy.agent.speed = 5f;
            enemy.agent.angularSpeed = 100f;
        }
        else
        {
           // Debug.Log("speed = 7");
            enemy.agent.speed = 10f;
            enemy.agent.angularSpeed = 120f;
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

        float aggression = PlayerStats.Instance.Aggression;

        if (aggression > 70f)
        {
            enemy.StateMachine.ChangeState(enemy.IdleState);
            return;
        }


        if (enemy.IsWithinAttack)
        {
            enemy.StateMachine.ChangeState(enemy.AttackState);
        }

        float accuracy = PlayerStats.Instance.fightResults;

        if (accuracy > 70f && aggression < 50f)
        {
            //smart and calm with zig zag
            ZigZag();
        }
        else if (accuracy > 70f && aggression > 70f)
        {
            //dangoures player
            enemy.StateMachine.ChangeState(enemy.IdleState);
            return;
        }
        else
        {
            //nomral
            enemy.agent.SetDestination(_player.position);
        }
        

    }

    private void ZigZag()
    {
        zTimer -= Time.deltaTime;

        if (zTimer <= 0f || !hasTarget)
        {
            zInterval = Random.Range(0.3f, 0.7f); //timing randomned
            zTimer = zInterval;

            //change from left to right
            zDirection *= -1;
        }

            Vector3 toPlayer = (_player.position - enemy.transform.position).normalized;

            //get direction sideways
            Vector3 side = Vector3.Cross(toPlayer, Vector3.up).normalized;

            //based on distance
            float dis = Vector3.Distance(enemy.transform.position, _player.position);
            float dyanmic = Mathf.Clamp(dis * 0.5f, 1f, 6f);

            Vector3 offset = side * zDirection * dyanmic;

            // Vector3 tPostion = _player.position + offset;

          //  Vector3 forward = toPlayer * 2f;
            currentZ = _player.position + offset;
            hasTarget = true;

            enemy.agent.SetDestination(currentZ);
        
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
