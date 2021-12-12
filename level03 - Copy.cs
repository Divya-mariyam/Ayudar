using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level03 : MonoBehaviour
{  int score;

   AudioSource audios;
   Texture2D myTexture;
   public int i;
   List<string> images =new List<string>();
   public AudioSource[] sound;
   public AudioSource sound1;
     public AudioSource sound2;
     public AudioSource sound3;
     public AudioSource sound4;
   public Button button;
    public Button option_1;
    public Button option_2;
    public Button option_3;
    public Button option_4;
     public Button next1;
    public Text result;
    List <string> answers = new List<string>();
  List<List<string>> options = new List<List<string>>();
   

    void Start()
    {


        score=0;
        i = 0;
        images.Add("qn");
        images.Add("qn");
        images.Add("qn");
        images.Add("qn");
        images.Add("qn");
       
        audios =  GetComponent<AudioSource>();
       
        //tmp.clip=Resources.Load<AudioClip>("BELL");
        answers.Add("BELL");
        answers.Add("HEN");
        answers.Add("CATS");
        answers.Add("GOAT");
        answers.Add("DOGS"); 
        answers.Add("HORN"); 
         answers.Add("ELEPHANT"); 
          answers.Add("CROW"); 
           answers.Add("ALARM");
            answers.Add("WATER");  
        // sound1.play(); 
        options.Add(new List<string> { "DOG", "CAT", "GOAT", "BELL" });
        options.Add(new List<string> { "ELEPHANT", "DOG", "FISH", "HEN" });
        options.Add(new List<string> { "HORSE", "CATS", "SQUIRREL", "DOG" });
        options.Add(new List<string> { "GOAT", "TIGER", "BELL", "LION" });
        options.Add(new List<string> { "GOAT", "CAT", "DOGS", "LION" });
        options.Add(new List<string> { "HEN", "ELEPHANT", "DOGS", "HORN" });
        options.Add(new List<string> { "SNAKE", "ELEPHANT", "CROW", "BELL" });
        options.Add(new List<string> { "GOAT", "WATER", "DOGS", "CROW" });
        options.Add(new List<string> { "ALARM", "ELEPHANT", "PIANO", "HORN" });
        options.Add(new List<string> { "GOAT", "HEN", "WATER", "BELL" });
        myTexture = Resources.Load("qnmark") as Texture2D;
        GameObject rawImage = GameObject.Find("RawImage");
        rawImage.GetComponent<UnityEngine.UI.RawImage>().texture = myTexture;

             next1 = GameObject.Find("next1").GetComponent<Button>();
         next1.gameObject.SetActive(false);
        option_1 = GameObject.Find("option_1").GetComponent<Button>();
        option_2 = GameObject.Find("option_2").GetComponent<Button>();
        option_3 = GameObject.Find("option_3").GetComponent<Button>();
        option_4 = GameObject.Find("option_4").GetComponent<Button>();

        option_1.GetComponentInChildren<Text>().text = options[0][0];
        option_2.GetComponentInChildren<Text>().text = options[0][1];
        option_3.GetComponentInChildren<Text>().text = options[0][2];
        option_4.GetComponentInChildren<Text>().text = options[0][3]; 
        nextQstn();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
       public void cscene(string scenename)
{
    Application.LoadLevel(scenename);
    
}
    void nextQstn()
    {
        if(i==(answers.Count))
        {
                GameObject scoreText = GameObject.Find("result");
            //    scoreText.GetComponent<UnityEngine.UI.Text>().text = "Your Score is " + score.ToString();
            Common common = new Common();
            common.setScore(session.userName, "level_03", score.ToString());
                GameObject rawImage = GameObject.Find("RawImage");
                rawImage.SetActive(false);
                option_1.gameObject.SetActive(false);
                option_2.gameObject.SetActive(false);
                option_3.gameObject.SetActive(false);
                option_4.gameObject.SetActive(false);
              
                 next1.gameObject.SetActive(true);    
        }
        else
        {
        //i = Random.Range(0,4);
        audios.clip=Resources.Load<AudioClip>(answers[i]);
        audios.Play();      
        option_1.GetComponentInChildren<Text>().text = options[i][0];
        option_2.GetComponentInChildren<Text>().text = options[i][1];
        option_3.GetComponentInChildren<Text>().text = options[i][2];
        option_4.GetComponentInChildren<Text>().text = options[i][3]; 
         i = i+ 1;
        }


    }

  public void  opion_click ( string option)
  {
 //Debug.Log(options[i-1][int.Parse(option)] +  answers[i-1]);
  

  if ( options[i-1][int.Parse(option)] == answers[i-1])
     {
         Debug.Log("Corect");
         score=score+10;
     }
     else{
         Debug.Log("False");
    }
  
    Debug.Log("your score is " + score);

    
  
  nextQstn(); 

  GameObject scoreText = GameObject.Find("TextResult");
    scoreText.GetComponent<UnityEngine.UI.Text>().text = "Your Score is " + score.ToString();
  }

 public void StudentButtonClick()
{
    audios.clip=Resources.Load<AudioClip>(answers[i-1]);
        audios.Play();      
}
 
}
