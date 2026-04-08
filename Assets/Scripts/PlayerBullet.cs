using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float lifetime = 6f;
    public float damage = 10f;

    private void Awake()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           Enemys enemy = collision.gameObject.GetComponent<Enemys>();

            if (enemy != null)
            {
                enemy.Damage(damage);
                //save bullet hits
                PlayerStats.Instance.SaveHits();
            }
          
        }
       
        Destroy(gameObject);
    }
}
