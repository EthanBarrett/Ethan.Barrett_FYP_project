using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public Transform Player;
    public NavMeshAgent Agent;

        void Update()
    {
        Agent.destination = Player.position;
    }
}
