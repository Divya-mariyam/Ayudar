using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class front : MonoBehaviour
{
    
   public void GotoMainScene()
    {
        SceneManager.LoadScene("level01");
    }
     public void GotoMenuScene()
    {
        SceneManager.LoadScene("level02");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}

