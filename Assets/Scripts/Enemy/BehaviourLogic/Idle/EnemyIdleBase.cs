using UnityEngine;

public class EnemyIdleBase : ScriptableObject
{
    protected Enemys enemy;
    protected Transform transform;
    protected GameObject gameObject;

    protected Transform playerTransform;

    public virtual void Initialize(GameObject gameObject, Enemys enemys)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;
        this.enemy = enemys;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void DoEnterLogic() { }

    public virtual void DoExitLogic() { ResetValues(); }

    public virtual void DoFrameUpdateLogic()
    {
        if (enemy.IsAggroed)
        {
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }
    }

    public virtual void DoPhysicsLogic() { }

    public virtual void ResetValues() { }




}
