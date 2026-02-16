using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyAttackDistanceCheck : MonoBehaviour
{

    private Enemys _enemy;

    private void Awake()
    {


        _enemy = GetComponentInParent<Enemys>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            _enemy.SetAttackDistance(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("exit triggerd");
            _enemy.SetAttackDistance(false);
        }
    }


}
