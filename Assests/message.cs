using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class message : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void backButtonz()
    {
        SceneManager.LoadScene("studentProfileHome");
    }
    public void BTNCLICK()
    {
        StartCoroutine(sendMessageToParent());
    }

    public IEnumerator  sendMessageToParent()
    {


        WWWForm form = new WWWForm();
        form.AddField("username", session.studentUserName);
        form.AddField("message", GameObject.Find("message").GetComponent<UnityEngine.UI.InputField>().text);


        UnityWebRequest www = UnityWebRequest.Post("https://six-crepe.glitch.me/send_message", form);
        yield return www.SendWebRequest();



        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");

            var N = JSON.Parse(www.downloadHandler.text);
            if (N["status"].Equals("success"))
            {
                Debug.Log("Insides" + N["status"]);

               SceneManager.LoadScene("studentProfileHome");

            }
            else
            {
               // EditorUtility.DisplayDialog("Failed", "Invalid Username or Passoword, Please try again", "Ok");
            }


        }
    }
}

