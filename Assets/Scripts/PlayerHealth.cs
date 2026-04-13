using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxH = 50f;
    public float currentH;

    [SerializeField] private Transform spawnPoint;

    private void Awake()
    {
        currentH = maxH;
    }

    public void Damage(float damageP)
    {
        currentH -= damageP;

        if (currentH <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("died");

        Respawn();
    }

    private void Respawn()
    {
        currentH = maxH;
        transform.position =  spawnPoint.position;
    }

    
}
