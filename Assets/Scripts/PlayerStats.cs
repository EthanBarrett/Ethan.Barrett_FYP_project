using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    //target hit
    public int bulletsFired = 0;
    public int bulletsHit = 0;

    //when shooting and when not shooting
    public float shootTime = 0f;
    public float notShooting = 0f;

    private bool isShooting = false;
    private float shootingDelay = 0.2f;
    public float fightResults { get; private set; }

    //movement
    private Vector3 lastPosition;
    public float timeMoved = 0f;
    public float timeIdle = 0f;

    [SerializeField] private float moveThreshold = 0.1f;

    private float resetTimer = 60f;
    [SerializeField] private float resetInterval = 60f;



   
    /// //////////////////////////////////////////////////////////////////////////////////////////////////////////
   
    //player accuracy
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

        shootTime = 0f;
        notShooting = 0f;
    }

    private void Awake()
    {
        Instance = this;
        lastPosition = transform.position;
    }

    public void SaveShots()
    {
        bulletsFired++;

        isShooting = true;

        //restart timer
        CancelInvoke(nameof(StopShooting));
        Invoke(nameof(StopShooting), shootingDelay);
    }

    public void SaveHits()
    {
        bulletsHit++;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////

   

     void Update()
    {
        if (isShooting)
        {
            shootTime += Time.deltaTime;
        }
        else
        {
            notShooting += Time.deltaTime;
        }

        float movedistance = Vector3.Distance(transform.position, lastPosition);

        if (movedistance > moveThreshold)
        {
            timeMoved += Time.deltaTime;
        }
        else
        {
            timeIdle += Time.deltaTime;
        }

        lastPosition = transform.position;

        resetTimer -= Time.deltaTime;

        if (resetTimer <= 0)
        {
          //  shootTime = 0f;
          // notShooting = 0f;

            timeMoved = 0f;
            timeIdle = 0f;

            resetTimer = resetInterval;
        }
        
    }

    //plater Aggression

    public float Aggression
    {
        get
        {
            float totalTime = shootTime + notShooting;
            if (totalTime == 0) return 0f;

            return (shootTime / totalTime) * 100f;
        }
    }

    public void SetShooting(bool shot)
    {
        isShooting = shot;
    }

    void StopShooting()
    {
        isShooting = false;
    }

    //moblility

    public float Mobility
    {
        get
        {
            float total = timeMoved + timeIdle;
            if (total == 0) return 0f;

            return (timeMoved / total) * 100f;
        }
    }
   

}
