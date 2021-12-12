using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class level06 : MonoBehaviour
{
   static  int i;
    int imgscore=0;

    Texture2D myTexture;
          public Button button;
    public Button option_1;
    public Button option_2;
    public Button option_3;
    public Button option_4;
    public Button next1;
        public Text Text;

    List<string> images =new List<string>();
   
    List<List<string>> options = new List<List<string>>();

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        imgscore = 0;
        images.Add("0");
        images.Add("1");
        images.Add("6");
        images.Add("15");
        images.Add("10");
        images.Add("8");
        images.Add("9");
        images.Add("3");
        images.Add("2");
        images.Add("4");

        options.Add(new List<string> { "2","4","0","6"});
        options.Add(new List<string> { "1","8","3","2" });
       options.Add(new List<string> { "0","8","5","6" });
       options.Add(new List<string> { "7","15","3","5" });
       options.Add(new List<string> { "17","13","11","10" });
       options.Add(new List<string> { "1","8","9","3" });
       options.Add(new List<string> { "10","8","3","9" });
       options.Add(new List<string> { "12","14","3","2" });  
       options.Add(new List<string> { "9","8","4","2" });
       options.Add(new List<string> { "4","3","7","8" });
        myTexture = Resources.Load("0") as Texture2D;
        GameObject rawImage = GameObject.Find("RawImage");
        rawImage.GetComponent<UnityEngine.UI.RawImage>().texture = myTexture;
           

        option_1 = GameObject.Find("option_1").GetComponent<Button>();
        option_2 = GameObject.Find("option_2").GetComponent<Button>();
        option_3 = GameObject.Find("option_3").GetComponent<Button>();
        option_4 = GameObject.Find("option_4").GetComponent<Button>();

        option_1.GetComponentInChildren<Text>().text = options[0][0];
        option_2.GetComponentInChildren<Text>().text = options[0][1];
        option_3.GetComponentInChildren<Text>().text = options[0][2];
        option_4.GetComponentInChildren<Text>().text = options[0][3];
       
    next1 = GameObject.Find("next1").GetComponent<Button>();
         next1.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
    

    }
       public void cscene(string scenename)
{
    Application.LoadLevel(scenename);
    
}
    public void StudentButtonClick(string name)
    {

        if (i <= images.Count)
                    {
            int no = int.Parse(name);


            if (options[i][no - 1].ToLower() == images[i].ToLower().ToLower())
            {
                Debug.Log("corrrect");
                imgscore = imgscore + 10;
                                                                    
                               }
            else
            {
                Debug.Log("Wrong" + options[i][no - 1] + images[i]);

            }

            
            i = i + 1;
            if (i < images.Count)
            {


                myTexture = Resources.Load(images[i]) as Texture2D;
                GameObject rawImage = GameObject.Find("RawImage");
                rawImage.GetComponent<UnityEngine.UI.RawImage>().texture = myTexture;

                option_1.GetComponentInChildren<Text>().text = options[i][0];
                option_2.GetComponentInChildren<Text>().text = options[i][1];
                option_3.GetComponentInChildren<Text>().text = options[i][2];
                option_4.GetComponentInChildren<Text>().text = options[i][3];
            }
            else
            {
                Debug.Log("Game fininshed, Final score is " + imgscore);

                Common common = new Common();
                common.setScore(session.userName, "level_02", imgscore.ToString());


                option_1.gameObject.SetActive(false);
                option_2.gameObject.SetActive(false);
                option_3.gameObject.SetActive(false);
                option_4.gameObject.SetActive(false);
 
                GameObject rawImage = GameObject.Find("RawImage");
                rawImage.SetActive(false);
                       
                GameObject scoreText = GameObject.Find("Text");
                scoreText.GetComponent<UnityEngine.UI.Text>().text = "Your Score is " + imgscore.ToString();
                 next1.gameObject.SetActive(true);          
             
               }
           
        }

    }
}

