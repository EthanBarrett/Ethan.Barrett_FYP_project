using UnityEngine;

public class MoveCam : MonoBehaviour
{

    public Transform cameraPos;
 
   private void Update()
    {
        transform.position = cameraPos.position;
    }
}
