using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class math : MonoBehaviour
{

    string symbol_confusion, comparing_difficulty, depending_finger, object_counting;
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

        symbol_confusion = GameObject.Find("GameObject").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;
        comparing_difficulty = GameObject.Find("GameObject (1)").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;
        depending_finger = GameObject.Find("GameObject (2)").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;
        object_counting = GameObject.Find("GameObject (3)").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;


        WWWForm form = new WWWForm();
        form.AddField("username", session.userName);
        form.AddField("type", "math");
        form.AddField("symbol_confusion", symbol_confusion);
        form.AddField("comparing_difficulty", comparing_difficulty);
        form.AddField("depending_finger", depending_finger);
        form.AddField("object_counting", object_counting);

        UnityWebRequest www = UnityWebRequest.Post("https://six-crepe.glitch.me/set_student_measures", form);
        www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

         //   EditorUtility.DisplayDialog("Success", "Your Recordings has been saved", "Ok");
            SceneManager.LoadScene("read");

            Debug.Log("Form upload complete!");
        }





        //Debug.Log("username=" + frustration);

    }

}
