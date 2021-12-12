using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemDetails : MonoBehaviour
{

    //Item Name
    public Text name = null;
    public Text dob = null;
    public Text gender = null;
    public Text phone = null;
    public Text username = null;



    //Item Image

    public void loadStudent()
    {
        session.studentUserName = username.text;
        session.studentName = name.text;
        session.studentDOB = dob.text;
        session.studentGender = gender.text;


        SceneManager.LoadScene("studentProfileHome");
        //Debug.Log(name.text);
        
    }


}