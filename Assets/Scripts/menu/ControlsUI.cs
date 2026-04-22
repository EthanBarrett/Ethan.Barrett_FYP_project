using UnityEngine;

public class ControlsUI : MonoBehaviour
{
    public GameObject controlPanel;

    public void open()
    {
        controlPanel.SetActive(true);
    }

    public void Close()
    {
        controlPanel.SetActive(false);
    }
}
