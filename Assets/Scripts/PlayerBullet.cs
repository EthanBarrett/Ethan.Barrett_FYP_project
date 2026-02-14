using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float lifetime = 6f;

    private void Awake()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
       
        Destroy(gameObject);
    }
}
