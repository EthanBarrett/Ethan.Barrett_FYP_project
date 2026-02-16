using UnityEngine;

public class EnemyAttackBase : ScriptableObject
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

    }

    public virtual void DoPhysicsLogic() { }

    public virtual void ResetValues() { }

}
