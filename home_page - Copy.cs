using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class home_page : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void parent()
    {
        SceneManager.LoadScene("login");

    }
    public void doctor()
    {
        SceneManager.LoadScene("dr_login");
    }
    public void quitapp()
  {
  Debug.Log("App Closed");
  Application.Quit();
  }
}
