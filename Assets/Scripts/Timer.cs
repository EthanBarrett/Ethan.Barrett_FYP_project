using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float goneTime;

    [SerializeField] GameObject survey;
    private bool ended = false;

     void Start()
    {
        survey.SetActive(false);
    }
    void Update()
    {
        if (goneTime > 0)
        {
            goneTime -= Time.deltaTime;
        }
        else if (!ended)
        {
            goneTime = 0;
            timerText.color = Color.red;

            ended = true;

            Survey();
        }

       
        int minutes = Mathf.FloorToInt(goneTime / 60);
        int seconds = Mathf.FloorToInt(goneTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        
    }

    void Survey()
    {
        survey.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

       // Time.timeScale = 0f;
    }
}
