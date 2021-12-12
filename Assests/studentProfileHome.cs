using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class studentProfileHome : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        GameObject.Find("StudentName").GetComponent<UnityEngine.UI.Text>().text = session.studentName;
        GameObject.Find("gender").GetComponent<UnityEngine.UI.Text>().text = session.studentGender;
        GameObject.Find("dob").GetComponent<UnityEngine.UI.Text>().text = session.studentDOB;
       // GameObject.Find("height").GetComponent<UnityEngine.UI.Text>().text = session.studentHeight;
        //GameObject.Find("height").GetComponent<UnityEngine.UI.Text>().text = session.childHeight;


        WWWForm form = new WWWForm();
        form.AddField("username", session.studentUserName);
        //form.AddField("username", "basil");
        UnityWebRequest www = UnityWebRequest.Post("https://six-crepe.glitch.me/get_level_score", form);
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
            for(int i=0; i < arr.Count; i++)
            {
                if (arr[i]["levelName"].Equals("level_01"))
                {
                    GameObject.Find("level01").GetComponent<UnityEngine.UI.Text>().text = arr[i]["score"];
                }
                if (arr[i]["levelName"].Equals("level_02"))
                {
                    GameObject.Find("level02").GetComponent<UnityEngine.UI.Text>().text = arr[i]["score"];
                }
                if (arr[i]["levelName"].Equals("level_03"))
                {
                    GameObject.Find("level03").GetComponent<UnityEngine.UI.Text>().text = arr[i]["score"];
                }
                if (arr[i]["levelName"].Equals("level_04"))
                {
                    GameObject.Find("level04").GetComponent<UnityEngine.UI.Text>().text = arr[i]["score"];
                }
                if (arr[i]["levelName"].Equals("level_05"))
                {
                    GameObject.Find("level05").GetComponent<UnityEngine.UI.Text>().text = arr[i]["score"];
                }
                if (arr[i]["levelName"].Equals("level_06"))
                {
                    GameObject.Find("level06").GetComponent<UnityEngine.UI.Text>().text = arr[i]["score"];
                }
            }
           
            

            Debug.Log(www.downloadHandler.text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void backtoselect()
    {
        SceneManager.LoadScene("student_list");
    }
    public void interactParent()
    {
        SceneManager.LoadScene("sendNotification");
    }

    public void launchSurvayResult(string survayName)
    {
        session.survayName = survayName;
        SceneManager.LoadScene("surveyResult");
    }
   public void showStudentDetails()
    {
      
        SceneManager.LoadScene("studentDetails");
    }
}
