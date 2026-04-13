using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float damageP = 10f;
    public float life = 5f;

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.Damage(damageP);
            }

            Destroy(gameObject);
        }
    }
}
