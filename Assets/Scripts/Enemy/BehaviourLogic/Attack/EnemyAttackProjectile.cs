using UnityEngine;

[CreateAssetMenu(fileName = "Attack-random Attack", menuName = "Enemy Logic/Attack logic/random Attack")]
public class EnemyAttackProjectile : EnemyAttackBase
{
    private Transform _playerTransform;
    [SerializeField] private Rigidbody EnemyBulletPrefab;
    private float _timer;
    [SerializeField] private float _timeBetweenShots = 2f;

    private float _exitTimer;
    [SerializeField] private float _timeTillExit = 3f;
    [SerializeField] private float _distanceToCountExit = 3f;

    [SerializeField] private float BulletSpeed = 20f;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();      

        enemy.agent.ResetPath();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();

        enemy.agent.isStopped = false;
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        float mobility = Mathf.Clamp(PlayerStats.Instance.Mobility, 0f, 100f);

        float rateOfFire = _timeBetweenShots;

        if (mobility > 70f)
        {
            rateOfFire = 0.8f;
        }
        else if (mobility < 30f)
        {
            rateOfFire = 2.5f;
        }

        if (_timer > rateOfFire)
        {
            _timer = 0f;



            Vector3 target = _playerTransform.position;

            if (mobility > 70f)
            {
                Rigidbody rb = _playerTransform.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    float predict = 0.5f;
                    target += rb.linearVelocity * predict;
                }
            }

            Vector3 dir = (target - enemy.transform.position).normalized;

            if (mobility > 70f)
            {
                float spread = 0.5f;

                dir.x += Random.Range(-spread, spread);
                dir.z += Random.Range(-spread, spread);

                dir.Normalize();
            }


            Vector3 spawnPos = enemy.transform.position + dir * 0.5f;

            Rigidbody bullet = GameObject.Instantiate(EnemyBulletPrefab, spawnPos, Quaternion.identity);

            bullet.linearVelocity = dir * BulletSpeed;

            Object.Destroy(bullet.gameObject, 10f);

            //at spread fire to bullets
            if (PlayerStats.Instance.Mobility > 70f)
            {
                enemy.agent.isStopped = false;

                Vector3 side = Vector3.Cross((_playerTransform.position - enemy.transform.position).normalized, Vector3.up);

                Vector3 strafe = enemy.transform.position + side * Random.Range(-2f, 2f);

                enemy.agent.SetDestination(strafe);

            }
            else
            {
                enemy.agent.isStopped = true;
            }

        }


        if (Vector3.Distance(_playerTransform.position, enemy.transform.position) > _distanceToCountExit)
        {
            _exitTimer += Time.deltaTime;

            if (_exitTimer > _timeTillExit)
            {
                enemy.StateMachine.ChangeState(enemy.ChaseState);
            }

        }

        else
        {
            _exitTimer = 0f;
        }

        float aggression = PlayerStats.Instance.Aggression;

        if (mobility > 70f && aggression < 50f)
        {
            
            
        }


        _timer += Time.deltaTime;
    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
    }

    public override void Initialize(GameObject gameObject, Enemys enemys)
    {
        base.Initialize(gameObject, enemys);
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
