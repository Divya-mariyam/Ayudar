using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class help : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void help1()
    {
        SceneManager.LoadScene("help1");
    }
    public void help2()
    {
        SceneManager.LoadScene("help2");
    }
    public void help3()
    {
        SceneManager.LoadScene("help3");
    }
    public void help4()
    {
        SceneManager.LoadScene("help4");
    }
    public void help5()
    {
        SceneManager.LoadScene("help5");
    }


    public void backButton()
    {
        SceneManager.LoadScene("parentHome");
    }
    public void backLevel1()
    {
        SceneManager.LoadScene("level01");
    }
    public void backLevel2()
    {
        SceneManager.LoadScene("level06");
    }
    public void backLevel3()
    {
        SceneManager.LoadScene("level03");
    }
    public void backLevel4()
    {
        SceneManager.LoadScene("level04");
    }
    public void backLevel5()
    {
        SceneManager.LoadScene("level05");
    }
}
