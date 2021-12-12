using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class level02 : MonoBehaviour
{  static  int i;
   public int mathscore,o,l,q;
   string a,b,w,k;
    public Button button;
    public Button option_1;
    public Button option_2;
    public Button option_3;
    public Text Text;
    List<string> symbols =new List<string>();
    List<List<string>> options = new List<List<string>>();

    void Start()
    { 

         symbols.Add("+");
         symbols.Add("-");
         i=0;    
         
                  click();
        
    }

 void click()
 {
      
      
          GameObject scoreText = GameObject.Find("Text_A");
  scoreText.GetComponent<UnityEngine.UI.Text>().text = Random.Range(5,10)+"";
          GameObject scoreText2 = GameObject.Find("Text_B");
  scoreText2.GetComponent<UnityEngine.UI.Text>().text = Random.Range(1,5)+"";
          GameObject scoreText3 = GameObject.Find("Text_C");
  scoreText3.GetComponent<UnityEngine.UI.Text>().text = symbols[Random.Range(0,2)];
 
    string w1= scoreText3.GetComponent<UnityEngine.UI.Text>().text;
    string a1= scoreText.GetComponent<UnityEngine.UI.Text>().text;
    string b1 = scoreText2.GetComponent<UnityEngine.UI.Text>().text;    
    
    int.TryParse(a1, out o);
    int.TryParse(b1, out l); 
   if(w1 == "+")
      {
                q = o+l; 
      }    
   else
      {    
        q  = o-l;      
      } 

 


option_1 = GameObject.Find("option_1").GetComponent<Button>();
option_2 = GameObject.Find("option_2").GetComponent<Button>();
option_3 = GameObject.Find("option_3").GetComponent<Button>();
     
     k=Random.Range(0,3).ToString();
     
     if(k == "0")
     {

        option_1.GetComponentInChildren<Text>().text =Random.Range(1,10)+"";
        option_2.GetComponentInChildren<Text>().text =q.ToString();
        option_3.GetComponentInChildren<Text>().text = Random.Range(11,20)+"";
     }
      if(k == "1")
     {

        option_1.GetComponentInChildren<Text>().text =q.ToString();
        option_2.GetComponentInChildren<Text>().text =Random.Range(1,10)+"";
        option_3.GetComponentInChildren<Text>().text = Random.Range(11,20)+"";
     } 
     if(k == "2")
     {

        option_1.GetComponentInChildren<Text>().text =Random.Range(1,10)+"";
        option_2.GetComponentInChildren<Text>().text =Random.Range(11,20)+"";
        option_3.GetComponentInChildren<Text>().text =q.ToString();
     }     
 }
 
    void Update()
    {
        
    }

 public void StudentButtonClick(string name)
{
   mathscore=0; 
   GameObject scoreText = GameObject.Find("Text_A");
   GameObject scoreText2 = GameObject.Find("Text_B"); 
   GameObject scoreText3 = GameObject.Find("Text_C"); 
    w= scoreText3.GetComponent<UnityEngine.UI.Text>().text;
    a= scoreText.GetComponent<UnityEngine.UI.Text>().text;            
    b= scoreText2.GetComponent<UnityEngine.UI.Text>().text;

    int o1,o2,ans;
    
     int.TryParse(a, out o1);
     int.TryParse(b, out o2); 
  
     if(w == "+")
      {
               ans  = o1+o2; 
      }    
     else
      {    
       ans  = o1-o2;      
      } 

   GameObject name1= GameObject.Find(name);
string h= name1.GetComponentInChildren<Text>().text;

   int no = int.Parse(h);
   int bb = q;

Debug.Log(no + "-----" + ans + "-----" + w);

if (ans==no)
{
    Debug.Log("correct");
    mathscore = mathscore + 10;
   
}

else
{
     Debug.Log("wrong");
}

if(i<=4)
{  

     click();
     i=i+1;

}
else
{
                option_1.gameObject.SetActive(false);
                option_2.gameObject.SetActive(false);
                option_3.gameObject.SetActive(false);
               GameObject aaa = GameObject.Find("Text_A");
               aaa.gameObject.SetActive(false);           
               GameObject aaaa = GameObject.Find("Text_B");
               aaaa.gameObject.SetActive(false);          
               GameObject aab = GameObject.Find("Text_C");
               aab.gameObject.SetActive(false);       
               GameObject aaaaa = GameObject.Find("Text_D");
       aaaaa.GetComponent<UnityEngine.UI.Text>().text = "Your Score is " + mathscore.ToString();
            Common common = new Common();
            common.setScore(session.userName, "level_02", mathscore.ToString());


        }
    }
}
