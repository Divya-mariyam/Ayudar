
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class writing : MonoBehaviour
{

    string resist, on_paper, copying_text, writing_task;
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

        resist = GameObject.Find("GameObject0").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;
        on_paper = GameObject.Find("GameObject").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;
        copying_text = GameObject.Find("GameObject (1)").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;
        writing_task = GameObject.Find("GameObject (2)").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;


        WWWForm form = new WWWForm();
        form.AddField("username", session.userName);
        form.AddField("type", "writing");
        form.AddField("resist", resist);
        form.AddField("on_paper", on_paper);
         form.AddField("copying_text", copying_text);
        form.AddField("writing_task", writing_task);


        UnityWebRequest www = UnityWebRequest.Post("https://six-crepe.glitch.me/set_student_measures", form);
        www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

          //  EditorUtility.DisplayDialog("Success", "Your Recordings has been saved", "Ok");
            SceneManager.LoadScene("parentHome");

            Debug.Log("Form upload complete!");
        }


    }
}
