using UnityEngine;

public class OpenSurvey : MonoBehaviour
{
    public string surveyURL = "https://forms.cloud.microsoft/Pages/ResponsePage.aspx?id=VeArfoqCI0W15bd62ZOXhX3qnGCnkipOvTGtCz2r_IJUN0c5TVYyRUJBRzJJQ09UVUtORlYzTVBaTC4u";

    public void OpenLink()
    {
        Application.OpenURL(surveyURL);
    }
}
