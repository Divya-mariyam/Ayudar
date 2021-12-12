using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level05 : MonoBehaviour 
{
   Texture2D myTexture;
   InputField iField;
   
    static  int i;
    int imgscore;
 public Text result;
 public Button button;
  string myName;
  List<string> images =new List<string>();
void Start()

{    i=0; 
    imgscore = 0;
         images.Add("G"); 
         images.Add("O");
         images.Add("P");
         images.Add("I");
         images.Add("M");

         images.Add("Y"); 
         images.Add("COW");
         images.Add("C");
         images.Add("R");
         images.Add("E");


        myTexture = Resources.Load("G") as Texture2D;
        GameObject rawImage = GameObject.Find("RawImage");
        rawImage.GetComponent<UnityEngine.UI.RawImage>().texture = myTexture;
           

}
      
       public void cscene(string scenename)
{
    Application.LoadLevel(scenename);
    
}
       public void StudentButtonClick()
    {
      //Debug.Log("inside");
       GameObject InputField = GameObject.Find("iField");
       myName=InputField.GetComponent<UnityEngine.UI.InputField>().text;
        if(myName.ToLower()==images[i].ToLower())
         {
           // Debug.Log(myName);
           Debug.Log("corrrect");
            imgscore=imgscore+10;
  //          iField.GetComponent<UnityEngine.UI.Text>().text ="";
           
         }
         else
         {
             Debug.Log("Wrong");
         }
          i = i + 1;
            if (i < images.Count)
            {


                myTexture = Resources.Load(images[i]) as Texture2D;
                GameObject rawImage = GameObject.Find("RawImage");
                rawImage.GetComponent<UnityEngine.UI.RawImage>().texture = myTexture;
 //               iField.GetComponent<UnityEngine.UI.Text>().text ="";
        }
        else
        {  
          
                GameObject rawImage = GameObject.Find("RawImage");
                rawImage.SetActive(false);
                
                GameObject iField = GameObject.Find("iField");
                iField.SetActive(false);

                Common common = new Common();
                common.setScore(session.userName, "level_05", imgscore.ToString());

               Debug.Log("Form Upload Complete"); 
              
           //Common common = new Common();
            GameObject scoreText = GameObject.Find("result");
            scoreText.GetComponent<UnityEngine.UI.Text>().text = "Your Score is " + imgscore;

            GameObject button1 = GameObject.Find("Button");
            button1.SetActive(false);
            //common.setScore(session.userName, "level_05", imgscore.ToString());


        }
        // Debug.Log(myName);
    
    }

}