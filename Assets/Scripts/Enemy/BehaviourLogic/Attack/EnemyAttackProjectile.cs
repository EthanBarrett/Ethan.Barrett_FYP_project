using UnityEngine;

[CreateAssetMenu(fileName = "Attack-random Attack", menuName = "Enemy Logic/Attack logic/random Attack")]
public class EnemyAttackProjectile : EnemyAttackBase
{
    private Transform _playerTransform;
    [SerializeField] private Rigidbody EnemyBulletPrefab;
    private float _timer;
    [SerializeField] private float _timeBetweenShots = 1.5f;
    
    private float _exitTimer;
    [SerializeField] private float _timeTillExit = 3f;
    [SerializeField] private float _distanceToCountExit = 3f;

    [SerializeField] private float BulletSpeed = 20f;

    private float nextFire = 0f;
    private float smooth;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();      

        enemy.agent.ResetPath();

        _timer = 0f;
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();

        enemy.agent.isStopped = false;
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        
       


        //float mobility = Mathf.Clamp(PlayerStats.Instance.Mobility, 0f, 100f);
        // smooth = Mathf.Lerp(smooth, PlayerStats.Instance.Mobility, Time.deltaTime * 5f);
        // float mobility = smooth;

        float mobility = PlayerStats.Instance.freezeMobility;
        float accuracy = PlayerStats.Instance.freezeAccuracy;
        float Aggression = PlayerStats.Instance.freezeAggression;

        bool shouldStrafe = mobility >= 60f;

       // float accuracy = PlayerStats.Instance.fightResults;
        
        float rateOfFire;
        
        if (mobility >= 70f)
        {
            rateOfFire = 1.2f;
        }
        else if (mobility >= 40f)
        {
            rateOfFire = 1.7f;
        }
        else
        {
            rateOfFire = 0.8f;
        }

        if (shouldStrafe)
        {


            enemy.agent.isStopped = false;

            Vector3 toPlayer = (_playerTransform.position - enemy.transform.position).normalized;
            Vector3 side = Vector3.Cross(toPlayer, Vector3.up);

            float strafe = 20f;
            float offset = 3f;


            Vector3 moveTarget = _playerTransform.position + side * Mathf.Sin(Time.time * 2f) * strafe + toPlayer * -offset;


            enemy.agent.SetDestination(moveTarget);
        }


        if (Time.time >= nextFire)
        {
            nextFire = Time.time + rateOfFire;

            //Debug.Log("Rate of fire: " + rateOfFire);

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

            if (mobility < 20f)
            {
                dir = (_playerTransform.position - enemy.transform.position).normalized;
            }
            else
            {
                dir = (target - enemy.transform.position).normalized;

                float spread = Mathf.Lerp(0.5f, 0f, accuracy / 100f);


                dir.x += Random.Range(-spread, spread);
                dir.z += Random.Range(-spread, spread);

                dir.Normalize();
            }



            if (accuracy < 60f)
            {
                float spread = Mathf.Lerp(0.5f, 0f, accuracy / 100f);

                dir.x += Random.Range(-spread, spread);
                dir.z += Random.Range(-spread, spread);

                dir.Normalize();
            }


            //spawn bullet
            Vector3 spawnPos = enemy.transform.position + dir * 0.5f;

            bool shotgun = accuracy < 40f && Aggression > 60f;

            int pellet = shotgun ? 5 : 1;
            float spreadAmout = shotgun ? 0.4f : Mathf.Lerp(0.2f, 0.05f, accuracy / 100f);

            for (int i = 0; i < pellet; i++)
            {

                Vector3 shot = dir;

                //spread the pellet
                shot.x += Random.Range(-spreadAmout, spreadAmout);
                shot.z += Random.Range(-spreadAmout, spreadAmout);
                shot.Normalize();

                Rigidbody bullet = GameObject.Instantiate(EnemyBulletPrefab, spawnPos, Quaternion.identity);

                //  bullet.linearVelocity = dir * BulletSpeed;


                float baseSpeed = BulletSpeed;

                //scale with player
                float mobliltyLevel = Mathf.Lerp(0.8f, 1.3f, mobility / 100f);
                float accuracyLevel = Mathf.Lerp(0.9f, 1.2f, accuracy / 100f);
                float aggressionLevel = Mathf.Lerp(0.8f, 1.4f, PlayerStats.Instance.Aggression / 100f);

                //combine them
                float finalspeed = baseSpeed * mobliltyLevel * accuracyLevel * aggressionLevel;

                //add random shoot
                finalspeed *= Random.Range(0.9f, 1.1f);

                //apply
                bullet.linearVelocity = dir * finalspeed;

                EnemyBullet bulletScript = bullet.GetComponent<EnemyBullet>();
                if (bulletScript != null)
                {
                    float scale = PlayerStats.Instance.DeathScale;
                    bulletScript.damageP = bulletScript.damageStart * scale;

                    //  Debug.Log("bullet damage: " + bulletScript.damageP);
                }

                Object.Destroy(bullet.gameObject, 10f);
            }
            /*
            //at spread fire to bullets
            if (PlayerStats.Instance.Mobility > 80f)
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
            */

           

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
