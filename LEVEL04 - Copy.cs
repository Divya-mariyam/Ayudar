using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LEVEL04 : MonoBehaviour
{
    static  int i;
    int imgscore;

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
    void Start()
    {
        i = 0;
        imgscore = 0;
        images.Add("2 DOGS");
        images.Add("6 CAPS");
        images.Add("5 BALLS");
        images.Add("6 FISHES");
        images.Add("3 FLOWERS");
        images.Add("5 ICECREAMS");
        images.Add("1 TEDDY");
        images.Add("4 TOYS");

        images.Add("7 PENS");
        images.Add("2 CARS");   


     options.Add(new List<string> { "6 DOGS", "5 DOGS", "2 DOGS", "3 DOGS" });
     options.Add(new List<string> { "6 CAPS", "8 CAPS", "1 CAPS", "4 CAPS" });
     options.Add(new List<string> { "2 BALLS", "9 BALLS", "5 BALLS", "1 BALLS" });
     options.Add(new List<string> { "3 FISHES", "4 FISHES", "6 FISHES", "2 FISHES" });
     options.Add(new List<string> { "5 FLOWERS", "7 FLOWERS", "8 FLOWERS", "3 FLOWERS" });
     options.Add(new List<string> { "10 ICECREAMS", "2 ICECREAMS", "5 ICECREAMS", "7 ICECREAMS" });
     options.Add(new List<string> { "1 TEDDY", "6 TEDDYS", "2 TEDDYS", "4 TEDDYS" });
     options.Add(new List<string> { "6 TOYS", "4 TOYS", "5 TOYS", "8 TOYS" });

     options.Add(new List<string> { "6 PENS", "7 PENS", "8 PENS", "4 PENS" });
     options.Add(new List<string> { "3 CARS", "4 CARS", "2 CARS", "8 CARS" });

        myTexture = Resources.Load("2 DOGS") as Texture2D;
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
            if (options[i][no-1].ToLower() == images[i].ToLower().ToLower())
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
              //  Debug.Log("Game fininshed, Final score is " + imgscore);
                option_1.gameObject.SetActive(false);
                option_2.gameObject.SetActive(false);
                option_3.gameObject.SetActive(false);
                option_4.gameObject.SetActive(false);
                Common common = new Common();
                common.setScore(session.userName, "level_04", imgscore.ToString());

                GameObject rawImage = GameObject.Find("RawImage");
                rawImage.SetActive(false);
                
                next1.gameObject.SetActive(true);          
             
}
                    }
                    }
}
