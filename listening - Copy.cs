using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEditor; 
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class listening : MonoBehaviour
{

    string following, spoken_understating, understand_jokes, follow_conversations;
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

        following = GameObject.Find("GameObject").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;
        spoken_understating = GameObject.Find("GameObject (1)").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;
        understand_jokes = GameObject.Find("GameObject (2)").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;
        follow_conversations = GameObject.Find("GameObject (3)").GetComponent<UnityEngine.UI.ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;


        WWWForm form = new WWWForm();
        form.AddField("username", session.userName);
        form.AddField("type", "listening");
        form.AddField("following", following);
        form.AddField("spoken_understating", spoken_understating);
        form.AddField("understand_jokes", understand_jokes);
        form.AddField("follow_conversations", follow_conversations);

        UnityWebRequest www = UnityWebRequest.Post("https://six-crepe.glitch.me/set_student_measures", form);
        www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

            // EditorUtility.DisplayDialog("Success", "Your Recordings has been saved", "Ok");
            SceneManager.LoadScene("math&logic");

            Debug.Log("Form upload complete!");
        }





        //Debug.Log("username=" + frustration);

    }

}
