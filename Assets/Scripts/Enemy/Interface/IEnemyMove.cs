using UnityEngine;

public interface IEnemyMove
{
    Rigidbody rb { get; set; }
    bool IsFacingright { get; set; }

    void MoveEnemy(Vector3 velocity);
    void CheckForLeftOrRightFacing(Vector3 velocity);
}
