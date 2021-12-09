using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class parentHome : MonoBehaviour
{
    // Start is called before the first frame update
  IEnumerator Start()
    {


        WWWForm form = new WWWForm();
        form.AddField("username", session.userName);
        UnityWebRequest www = UnityWebRequest.Post("https://six-crepe.glitch.me/get_message", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");

            var N = JSON.Parse(www.downloadHandler.text);
            JSONArray arr = (JSONArray)N;
            for (int i = 0; i < arr.Count; i++)
            {

                GameObject.Find("note").GetComponent<Text>().text = arr[i]["message"];

                
            }

            Debug.Log(arr.Count);
        }


    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void help_home()
    {
        SceneManager.LoadScene("helpMain");
    }

    public void startSurvay()
    {

        SceneManager.LoadScene("emotions");

    }
    public void startGame1()
    {

        SceneManager.LoadScene("level01");

    }
    public void startGame2()
    {
        SceneManager.LoadScene("level06");
    }
    public void startGame3()
    {
        SceneManager.LoadScene("level03");

    }
    public void startGame4()
    {
        SceneManager.LoadScene("level04");

    }

    public void startGame5()
    {
        SceneManager.LoadScene("level05");

    }


}
