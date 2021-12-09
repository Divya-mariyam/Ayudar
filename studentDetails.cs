
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class studentDetails : MonoBehaviour
{
  // Start is called before the first frame update
  IEnumerator Start()
    {
        
       WWWForm form = new WWWForm();
        form.AddField("username", session.studentUserName);
        UnityWebRequest www = UnityWebRequest.Post("https://six-crepe.glitch.me/get_student", form);
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

            GameObject.Find("Textbox").GetComponent<Text>().text = arr[i]["username"];
            GameObject.Find("cgender").GetComponent<Text>().text = arr[i]["childGender"];
            GameObject.Find("cdob").GetComponent<Text>().text = arr[i]["dob"];
            GameObject.Find("cheight").GetComponent<Text>().text = arr[i]["height"];
            GameObject.Find("cweight").GetComponent<Text>().text = arr[i]["weight"];
            GameObject.Find("ctype").GetComponent<Text>().text = arr[i]["observationType"];
            
            GameObject.Find("fname").GetComponent<Text>().text = arr[i]["fatherName"];
            GameObject.Find("foccupation").GetComponent<Text>().text = arr[i]["fatherOccupation"];
            GameObject.Find("mname").GetComponent<Text>().text = arr[i]["motherName"];
            GameObject.Find("moccupation").GetComponent<Text>().text = arr[i]["motherOccupation"];
            GameObject.Find("cmob").GetComponent<Text>().text = arr[i]["contactNumber"];
            GameObject.Find("cemail").GetComponent<Text>().text = arr[i]["email"];
                
            }

            Debug.Log(arr.Count);
        } 
        

    }


    // Update is called once per frame
    void Update()
    {
        
    }
    /*    string replaceModules(string data)
    {
        string newString=data;
        for (int i=0; i < questions.Count; i++)
        {
            newString = newString.Replace(keywords[i], questions[i]);
        }



        return newString;

    }*/
}

