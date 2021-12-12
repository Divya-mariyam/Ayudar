using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class drHome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(session.userName);
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadStudentNames()
    {
        SceneManager.LoadScene("student_list");
    }
}
