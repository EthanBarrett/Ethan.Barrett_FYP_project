using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletprefab;
    public float bulletspeed = 10f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPos = bulletSpawn.position + bulletSpawn.forward * 0.5f;
            var bullet = Instantiate(bulletprefab, spawnPos, bulletSpawn.rotation);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.linearVelocity = bulletSpawn.forward * bulletspeed;

            
        }

        

    }
}
