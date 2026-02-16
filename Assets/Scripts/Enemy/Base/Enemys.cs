using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class Enemys : MonoBehaviour, IDamage, IEnemyMove, ITriggerCheck
{
    //Enemy health
    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }

    public float damage { get; set; }

    //Enemy move 
    public Rigidbody rb { get; set; }
    public bool IsFacingright { get; set; } = true;

    public NavMeshAgent agent { get; set; }

    //States for enemy
    public EnemyStateMachine StateMachine { get; set; }

    public EnemyIdle IdleState { get; set; }

    public EnemyChase ChaseState { get; set; }

    public enemyAttack AttackState { get; set; }



    public float MovementRange = 5f;
    public float MovementSpeed = 2f;

    public Vector3 StartPosition { get; set; }

    //Enemey Bullet
    // public Rigidbody EnemyBulletPrefab;

    //Trigger
    public bool IsAggroed { get; set; }
    public bool IsWithinAttack { get; set; }

    [SerializeField] private EnemyChaseBase enemyChaseBase;
    [SerializeField] private EnemyIdleBase enemyIdleBase;
    [SerializeField] private EnemyAttackBase enemyAttackBase;


    public EnemyIdleBase EnemyIdleBaseInstance { get; set; }
    public EnemyChaseBase EnemyChaseBaseInstance { get; set; }

    public EnemyAttackBase EnemyAttackBaseInstance { get; set; }



    private void Awake()
    {

        EnemyIdleBaseInstance = Instantiate(enemyIdleBase);
        EnemyChaseBaseInstance = Instantiate(enemyChaseBase);
        EnemyAttackBaseInstance = Instantiate(enemyAttackBase);

        agent = GetComponent<NavMeshAgent>();

        // rb = GetComponent<Rigidbody>();

        StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdle(this, StateMachine);
        ChaseState = new EnemyChase(this, StateMachine);
        AttackState = new enemyAttack(this, StateMachine);


    }


    private void Start()
    {
        CurrentHealth = MaxHealth;

        EnemyIdleBaseInstance.Initialize(gameObject, this);
        EnemyChaseBaseInstance.Initialize(gameObject, this);
        EnemyAttackBaseInstance.Initialize(gameObject, this);

        StartPosition = transform.position;

        StateMachine.Initialize(IdleState);


    }

    private void Update()
    {
        StateMachine.CurrentEnemyState.FrameUpdate();
    }

    // private void FixedUpdate()
    // {
    //  
    //    StateMachine.CurrentEnemyState.PhysicsUpdate();
    //  }



    public void Damage(float damageAmout)
    {
        CurrentHealth -= damageAmout;

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void MoveEnemy(Vector3 velocity)
    {
        // rb.linearVelocity = new Vector3(velocity.x, 0f, velocity.z);
        // CheckForLeftOrRightFacing(velocity);

        if (agent.enabled)
            agent.SetDestination(velocity);
    }

    public void CheckForLeftOrRightFacing(Vector3 velocity)
    {
        if (IsFacingright && velocity.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingright = !IsFacingright;
        }

        else if (!IsFacingright && velocity.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingright = !IsFacingright;
        }

    }

    public void SetAggroStatus(bool isAggroed)
    {
        IsAggroed = isAggroed;
    }

    public void SetAttackDistance(bool isWithinAttack)
    {
        IsWithinAttack = isWithinAttack;
    }
}
