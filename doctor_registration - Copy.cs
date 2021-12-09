using System.Collections;
using System.Collections.Generic;
using UnityEditor;
 
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class doctor_registration : MonoBehaviour
{

    string username, password, doctorName, contactNumber, imaNumber, email, confirmPassword;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BackButton2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("home");
    }

    public void BackButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("dr_login");
    }
    public void registration()
    {
        doctorName = GameObject.Find("doctorName").GetComponent<UnityEngine.UI.InputField>().text;
        imaNumber = GameObject.Find("imaNumber").GetComponent<UnityEngine.UI.InputField>().text;
        contactNumber = GameObject.Find("contactNumber").GetComponent<UnityEngine.UI.InputField>().text;
        email = GameObject.Find("email").GetComponent<UnityEngine.UI.InputField>().text;
        username = GameObject.Find("username").GetComponent<UnityEngine.UI.InputField>().text;
        password = GameObject.Find("password").GetComponent<UnityEngine.UI.InputField>().text;
        register();


    }


    public void register()
    {
        WWWForm form = new WWWForm();
        form.AddField("doctorName", doctorName);
        form.AddField("imaNumber", imaNumber);
        form.AddField("email", email);
        form.AddField("username", username);
        form.AddField("password", password);
        


        UnityWebRequest www = UnityWebRequest.Post("https://six-crepe.glitch.me/register_doctor", form);
        www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

//            EditorUtility.DisplayDialog("Success", "Your Registration is Complete", "Ok");
            //SceneManager.LoadScene("login");

            Debug.Log("Form upload complete!");
        }
    }
    public void DRButtonClick()
    {
        GameObject InputField = GameObject.Find("username");
        username = InputField.GetComponent<UnityEngine.UI.InputField>().text;
        GameObject InputField2 = GameObject.Find("password");
        password = InputField2.GetComponent<UnityEngine.UI.InputField>().text;
        if(username=="" || password=="")
      {GameObject.Find("box").GetComponent<UnityEngine.UI.Text>().text ="Enter Valid Login Credentials";}
        
        StartCoroutine(login(username, password));
    }


    public void loadDrRegistration()
    {
        SceneManager.LoadScene("doctor_registration");
    }


        public IEnumerator login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        UnityWebRequest www = UnityWebRequest.Post("https://six-crepe.glitch.me/login_doctor", form);
        yield return www.SendWebRequest();



        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");

            var N = JSON.Parse(www.downloadHandler.text);
            Debug.Log(www.downloadHandler.text);
            if (N["status"].Equals("success"))
            {
                Debug.Log("Insides" + N["status"]);

                session.userName = username;
                Debug.Log("DR Usernme");
                Debug.Log(username);

                SceneManager.LoadScene("doctorHome");

            }
            else
            {
//                EditorUtility.DisplayDialog("Failed", "Invalid Username or Passoword, Please try again", "Ok");
            }


        }
    }


}

