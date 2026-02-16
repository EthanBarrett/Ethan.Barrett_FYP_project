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

        enemy.agent.isStopped = true;
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

        if (_timer > _timeBetweenShots)
        {
            _timer = 0f;

            Vector3 dir = (_playerTransform.position - enemy.transform.position).normalized;
            Vector3 spawnPos = enemy.transform.position + dir * 0.5f;

            Rigidbody bullet = GameObject.Instantiate(EnemyBulletPrefab, spawnPos, Quaternion.identity);

            bullet.linearVelocity = dir * BulletSpeed;

            Object.Destroy(bullet.gameObject, 10f);

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
