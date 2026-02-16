
using UnityEngine;

public class enemyAttack : EnemyState
{
    /*
    private Transform _playerTransform;

    private float _timer;
    private float _timeBetweenShots = 2f;

    private float _exitTimer;
    private float _timeTillExit = 3f;
    private float _distanceToCountExit = 3f;

    private float BulletSpeed = 20f;
    */
    public enemyAttack(Enemys enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        // _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void EnterState()
    {
        base.EnterState();

        enemy.EnemyAttackBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();
        enemy.EnemyAttackBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemy.EnemyAttackBaseInstance.DoFrameUpdateLogic();
        /*
                if (_timer > _timeBetweenShots)
                {
                    _timer = 0f;

                    Vector3 dir = (_playerTransform.position - enemy.transform.position).normalized;
                    Vector3 spawnPos = enemy.transform.position + dir * 0.5f;

                    Rigidbody bullet = GameObject.Instantiate(enemy.EnemyBulletPrefab, spawnPos, Quaternion.identity);

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
        */
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        enemy.EnemyAttackBaseInstance.DoPhysicsLogic();
    }
}
