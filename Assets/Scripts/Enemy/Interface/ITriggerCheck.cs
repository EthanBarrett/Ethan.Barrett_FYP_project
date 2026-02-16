using UnityEngine;

public interface ITriggerCheck
{
    bool IsAggroed { get; set; }
    bool IsWithinAttack { get; set; }

    void SetAggroStatus(bool isAggroed);

    void SetAttackDistance(bool isWithinAttack);

}
