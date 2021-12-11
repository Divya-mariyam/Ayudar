using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 using System.Collections.Generic;

public class level01 : MonoBehaviour
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
    //List<string> randomList =new List<string>();
    List<List<string>> options = new List<List<string>>();

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        imgscore = 0;
        images.Add("CAT");
        images.Add("elephant");
        images.Add("horse");
        images.Add("lion");
        images.Add("snake");
        images.Add("CAR");
        images.Add("CHICKEN");
        images.Add("EAGLE");
        images.Add("FOOTBALL");
        images.Add("PIGEON");

        options.Add(new List<string> { "DOG", "CAT", "SQUIRREL", "RAT" });
        options.Add(new List<string> { "ELEPHANT", "DOG", "FISH", "SHARK" });
        options.Add(new List<string> { "HORSE", "DOG", "SQUIRREL", "CAT" });
        options.Add(new List<string> { "BEAR", "TIGER", "RABBIT", "LION" });
        options.Add(new List<string> { "SHEEP", "FOX", "MONKEY", "SNAKE" });
        options.Add(new List<string> { "SHIP", "CYCLE", "CAR", "BIKE" });
        options.Add(new List<string> { "DEER", "FOX", "DONKEY", "CHICKEN" });
        options.Add(new List<string> { "EAGLE", "PIGEON", "FALCON", "GOOSE" });
        options.Add(new List<string> { "SHEEP", "FOX", "MONKEY", "FOOTBALL" });
        options.Add(new List<string> { "CROW", "PIGEON", "HEN", "DUCK" });

       
        myTexture = Resources.Load("CAT") as Texture2D;
        GameObject rawImage = GameObject.Find("RawImage");
        rawImage.GetComponent<UnityEngine.UI.RawImage>().texture = myTexture;
           

        option_1 = GameObject.Find("option_1").GetComponent<Button>();
        option_2 = GameObject.Find("option_2").GetComponent<Button>();
        option_3 = GameObject.Find("option_3").GetComponent<Button>();
        option_4 = GameObject.Find("option_4").GetComponent<Button>();
        
     //   var rand = new Random();
     //   var randomList = images.OrderBy (i => rand.Next()).ToList();

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
                option_1.gameObject.SetActive(false);
                option_2.gameObject.SetActive(false);
                option_3.gameObject.SetActive(false);
                option_4.gameObject.SetActive(false);
 
                GameObject rawImage = GameObject.Find("RawImage");
                rawImage.SetActive(false);
                       
                GameObject scoreText = GameObject.Find("TextRes");
                scoreText.GetComponent<UnityEngine.UI.Text>().text = "Your Score is " + imgscore.ToString();

                Common common = new Common();
                common.setScore(session.userName, "level_01", imgscore.ToString());



                next1.gameObject.SetActive(true);          
             
               }
           
        }

    }
}
