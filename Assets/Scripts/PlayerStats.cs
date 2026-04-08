using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public int bulletsFired = 0;
    public int bulletsHit = 0;

    public float fightResults { get; private set; }

 

    public float Accuracy
    {
        get
        {
           // if (bulletsFired < 5) return 50f; //netural 
            
                 
            if (bulletsFired == 0) return 0f;
            return (float)bulletsHit / bulletsFired * 100f;
        }
    }

    public void CalculateAccuracy()
    {
        fightResults = Accuracy;
    }

    public void ResetStats()
    {
        bulletsFired = 0;
        bulletsHit = 0;
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
