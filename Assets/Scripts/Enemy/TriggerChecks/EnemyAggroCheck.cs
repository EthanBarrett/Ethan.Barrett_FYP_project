using UnityEngine;

public class enemyAggroCheck : MonoBehaviour
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
            Debug.Log("Aggro triggerd");
            _enemy.SetAggroStatus(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Aggro exit triggerd");
            _enemy.SetAggroStatus(false);
        }
    }
}
