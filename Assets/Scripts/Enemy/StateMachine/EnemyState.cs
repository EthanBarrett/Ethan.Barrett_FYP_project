using UnityEngine;

public class EnemyState
{
    protected Enemys enemy;
    protected EnemyStateMachine enemyStateMachine;

    public EnemyState(Enemys enemy, EnemyStateMachine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;

    }

    public virtual void EnterState() { }

    public virtual void ExitState() { }

    public virtual void FrameUpdate() { }

    public virtual void PhysicsUpdate() { }



}
