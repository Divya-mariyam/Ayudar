using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using UnityEditor;
using SimpleJSON;
using UnityEngine.SceneManagement;


public class LOGIN : MonoBehaviour
{
      InputField username;
      InputField password;
     string username1;
     string password1;
     public Button button; 
       public Button next1;
    void Start()
    {
      //next1 = GameObject.Find("next1").GetComponent<Button>();
    }
    public void BackButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("home");
    }

   public void cscene(string scenename)
{
    Application.LoadLevel(scenename);
    
}
   public void StudentButtonClick()
    {
         GameObject InputField = GameObject.Find("username");
       username1=InputField.GetComponent<UnityEngine.UI.InputField>().text;
     GameObject InputField2 = GameObject.Find("password");
       password1=InputField2.GetComponent<UnityEngine.UI.InputField>().text;
        Debug.Log("username="+username1);
      if(username1=="" || password1=="")
      {GameObject.Find("box2").GetComponent<UnityEngine.UI.Text>().text ="Enter Valid Login Credentials";}
      else
      {
              StartCoroutine( register(username1,password1)); 
      }
  
    }

    

  public IEnumerator  register(string username,string password){
    WWWForm form = new WWWForm();

    
        form.AddField("username", username);
        form.AddField("password", password);
 
        UnityWebRequest www = UnityWebRequest.Post("https://six-crepe.glitch.me/login_student", form);
         yield return www.SendWebRequest();


         
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Form upload complete!");

            var N = JSON.Parse(www.downloadHandler.text);
            if (N["status"].Equals("success"))
            {
                Debug.Log("Insides" + N["status"]);

                session.userName = username;
                SceneManager.LoadScene("parentHome");

            }
            else
            {

               


                //NativePlugins. NPBinding.UI.ShowAlertDialogWithMultipleButtons("Test", "This is a sample message.", _buttons, OnButtonPressed);
                //  EditorUtility.DisplayDialog("Failed", "Invalid Username or Passoword Please try again", "Ok");

            }

          
        }
  }
  

   }
 