using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float goneTime;

    // Update is called once per frame
    void Update()
    {
        if (goneTime > 0)
        {
            goneTime -= Time.deltaTime;
        }
        else if (goneTime < 0)
        {
            goneTime = 0;
            timerText.color = Color.red;
        }

        goneTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(goneTime / 60);
        int seconds = Mathf.FloorToInt(goneTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        
    }
}
