using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEditor;

using UnityEngine.SceneManagement;

public class emotion : MonoBehaviour
{
    string frustration, aches, feels_bad, resisting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BackButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("parentHome");
    }

    public void buttonClick() { 
    
        frustration =  GameObject.Find("GameObject").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;
        aches = GameObject.Find("GameObject (1)").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;
        feels_bad = GameObject.Find("GameObject (2)").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;
        resisting = GameObject.Find("GameObject (3)").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;


        WWWForm form = new WWWForm();
        form.AddField("username", session.userName);
        form.AddField("type", "emotion");
        form.AddField("frustration", frustration);
        form.AddField("aches", aches);
        form.AddField("feels", feels_bad);
        form.AddField("resisting", resisting);

        UnityWebRequest www = UnityWebRequest.Post("https://six-crepe.glitch.me/set_student_measures", form);
        www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

//            EditorUtility.DisplayDialog("Success", "Your Recordings has been saved", "Ok");
            SceneManager.LoadScene("listening");

            Debug.Log("Form upload complete!");
        }





        //Debug.Log("username=" + frustration);

    }

}
