using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject controlPanel;

    void Awake()
    {
        Time.timeScale = 1f;
    }
    public void Play()
    {
        SceneManager.LoadScene("game");
    }

    public void Quit()
    {
        Application.Quit();
    }


    public void open()
    {
        controlPanel.SetActive(true);
    }

    public void Close()
    {
        controlPanel.SetActive(false);
    }
}
