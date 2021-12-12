using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEditor;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class egstaton : MonoBehaviour
{


    string username1;
    string password1;
    string password2;
    string childName;
    string childGender;
    string dob;
    string height;
    string weight;
    string observationType;
    string fatherName;
    string fatherOccupation;
    string motherName;
    string motherOccupation;
    string contactNumber;
    string email;
    string doctorName;



  // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(populateDoctors());
    }
    public void BackButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("login");
    }
    // Update is called once per frame
    void Update()
    {
        
    }   
    
    
    public void StudentButtonClick()
    {
        GameObject InputField = GameObject.Find("username");
        username1=InputField.GetComponent<UnityEngine.UI.InputField>().text;
        GameObject InputField2 = GameObject.Find("password");
        password1=InputField2.GetComponent<UnityEngine.UI.InputField>().text;
        GameObject InputField3 = GameObject.Find("confirmPassword");
        password2=InputField3.GetComponent<UnityEngine.UI.InputField>().text;
        childName = GameObject.Find("childName").GetComponent<UnityEngine.UI.InputField>().text;
        childGender = GameObject.Find("gender").GetComponent<Dropdown>().options[GameObject.Find("gender").GetComponent<Dropdown>().value].text;
        dob = GameObject.Find("dob").GetComponent<UnityEngine.UI.InputField>().text;
        height = GameObject.Find("height").GetComponent<UnityEngine.UI.InputField>().text;
        weight = GameObject.Find("weight").GetComponent<UnityEngine.UI.InputField>().text;
        observationType = GameObject.Find("observation").GetComponent<Dropdown>().options[GameObject.Find("observation").GetComponent<Dropdown>().value].text;
        fatherName = GameObject.Find("fatherName").GetComponent<UnityEngine.UI.InputField>().text;
        fatherOccupation = GameObject.Find("fatherOccupation").GetComponent<UnityEngine.UI.InputField>().text;
        motherName = GameObject.Find("motherName").GetComponent<UnityEngine.UI.InputField>().text;
        motherOccupation = GameObject.Find("motherOccupation").GetComponent<UnityEngine.UI.InputField>().text;
        contactNumber = GameObject.Find("contactNumber").GetComponent<UnityEngine.UI.InputField>().text;
        email = GameObject.Find("email").GetComponent<UnityEngine.UI.InputField>().text;
        doctorName = GameObject.Find("doctorName").GetComponent<Dropdown>().options[GameObject.Find("doctorName").GetComponent<Dropdown>().value].text;
        Debug.Log("username="+username1);

        register();
    }

    public IEnumerator populateDoctors()
    {
        WWWForm form = new WWWForm();
        UnityWebRequest www = UnityWebRequest.Post("https://six-crepe.glitch.me/list_doctor", form);
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
            List<string> m_DropOptions = new List<string>();
            for(int i = 0; i < arr.Count; i++)
            {
                m_DropOptions.Add(arr[i]["username"]);
            }

            GameObject.Find("doctorName").GetComponent<Dropdown>().AddOptions(m_DropOptions);
            Debug.Log(m_DropOptions);
            

           


        }
    }

    public void register(){
         WWWForm form = new WWWForm();
   if(childName=="" || username1=="" || childGender=="" || childGender=="--Gender--" || dob=="" || height=="" || weight=="" || email=="" || contactNumber=="" ||  fatherOccupation=="" || observationType=="--Type of Observation--" || observationType=="" || fatherName=="" || motherName=="" || motherOccupation=="" || contactNumber=="" || (doctorName=="--Doctor Name--" || doctorName==""))
   {GameObject.Find("dialogue").GetComponent<UnityEngine.UI.Text>().text ="Enter all Fields";}
   else if(password1 !=password2)
    {
           GameObject.Find("dialogue").GetComponent<UnityEngine.UI.Text>().text ="Passwords not match";
    } 
   
   else
   { //
 
    
   
        form.AddField("username", username1);
        form.AddField("password", password1);
        form.AddField("childName", childName);
        form.AddField("childGender", childGender);
        form.AddField("dob", dob);
        form.AddField("height", height);
        form.AddField("weight", weight);
        form.AddField("observationType", observationType);
        form.AddField("fatherName", fatherName);
        form.AddField("fatherOccupation", fatherOccupation);
        form.AddField("motherName", motherName);
        form.AddField("motherOccupation", motherOccupation);
        form.AddField("contactNumber", contactNumber);
        form.AddField("email",email);
        form.AddField("doctorname", doctorName);

   

        UnityWebRequest www = UnityWebRequest.Post("https://six-crepe.glitch.me/register_student", form);
        www.SendWebRequest();
   
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {

//            EditorUtility.DisplayDialog("Success","Your Registration is Complete" , "Ok");
            SceneManager.LoadScene("login");

            Debug.Log("Form upload complete!");
        }
  }
}
}
