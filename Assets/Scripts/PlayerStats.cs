using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public int bulletsFired = 0;
    public int bulletsHit = 0;

    public float Accuracy
    {
        get
        {
            if (bulletsFired == 0) return 0f;
            return (float)bulletsHit / bulletsFired * 100f;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    public void SaveShots()
    {
        bulletsFired++;
    }

    public void SaveHits()
    {
        bulletsHit++;
    }

}
