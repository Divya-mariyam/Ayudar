
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spelling : MonoBehaviour
{
    string spelling_error, handwriting, truble_punctuation;
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

    public void buttonClick()
    {

        spelling_error = GameObject.Find("GameObject").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;
        handwriting = GameObject.Find("GameObject (1)").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;
        truble_punctuation = GameObject.Find("GameObject (2)").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;
        
        WWWForm form = new WWWForm();
        form.AddField("username", session.userName);
        form.AddField("type", "spelling");
        form.AddField("spelling_error", spelling_error);
        form.AddField("handwriting", handwriting);
        form.AddField("truble_punctuation", truble_punctuation);
        

        UnityWebRequest www = UnityWebRequest.Post("https://six-crepe.glitch.me/set_student_measures", form);
        www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

//            EditorUtility.DisplayDialog("Success", "Your Recordings has been saved", "Ok");
            SceneManager.LoadScene("writing");

            Debug.Log("Form upload complete!");
        }





        //Debug.Log("username=" + frustration);

    }
}
