using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class survay : MonoBehaviour
{

    string studentUsername, type;
    public List<string> keywords = null;
    public List<string> questions = null;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        keywords = new List<string>();
        questions = new List<string>();

        keywords.Add("Username");
        questions.Add("Student Name");

        keywords.Add("type");
        questions.Add("Survay Type");

 

        studentUsername = session.studentUserName;
        type = session.survayName;

        WWWForm form = new WWWForm();
        form.AddField("studentName", studentUsername);
        form.AddField("type", type);

        UnityWebRequest www = UnityWebRequest.Post("https://six-crepe.glitch.me/list_survay", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");

            var N = JSON.Parse(www.downloadHandler.text);
            Debug.Log(www.downloadHandler.text);
            GameObject.Find("jsonText").GetComponent<UnityEngine.UI.Text>().text = replaceModule(www.downloadHandler.text.Replace(",","\n").Replace("{","").Replace("}","").Replace("\"","").Replace("type:emotions","").Replace(":"," :  ").Replace("following","\u25C9  Struggle to follow spoken directions or explanations, especially when there are no illustrations? ").Replace("spoken_understating","\u25C9  Have difficulty understanding spoken language when there is a lot of background noise?").Replace("understand_jokes","\u25C9  Have difficulty following verbal jokes or a story read aloud by an adult?").Replace("follow_conversations","\u25C9  Struggle to participate in extended conversations or miss parts of conversations?").Replace("frustration","\u25C9  Express anxiety or frustration?").Replace("aches","\u25C9  Complain of aches, pains or other discomforts?").Replace("feels","\u25C9  Say she/he feels stupid or not as smart as other kids?").Replace("resisting","\u25C9  Resist authority? {e.g., argue or frequently disobey parents and/or teachers}").Replace("symbol_confusion","\u25C9  Confuse math symbols and/or operations? (e.g., addition, subtraction, multiplication, division)").Replace("comparing_difficulty","\u25C9  Have difficulty comparing between largest and smallest numbers?").Replace("depending_finger","\u25C9  Computing math shows dependence on finger counting and other tricks?").Replace("object_counting","\u25C9  Can count, but has difficulty counting objects?").Replace("mispronounce","\u25C9  Mispronounce (or used to) only certain words (e.g., says amunul for animal, poothtaste for toothpaste)?").Replace("unfamilier_word","\u25C9  Have difficulty reading unfamiliar words or guess at them?").Replace("loud_reading","\u25C9  Pause, repeat or make mistakes when reading aloud?").Replace("strugle","\u25C9  Struggle to understand what he or she has read?").Replace("avoid_reading","\u25C9  Avoid reading for pleasure?").Replace("spelling_error","\u25C9  Make spelling errors in homework assignments?").Replace("handwriting","\u25C9  Have messy handwriting?").Replace("truble_punctuation","\u25C9  Have trouble with punctuation and capitalization?").Replace("resist","\u25C9  Resist writing tasks?").Replace("on_paper","\u25C9  Have difficulty getting thoughts down on paper?").Replace("copying_text","\u25C9  Have difficulty copying text?").Replace("writing_task","\u25C9  Have trouble completing writing tasks independently?"));

            //JSONArray arr = (JSONArray)N;




        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void backButtonz()
    {
        SceneManager.LoadScene("studentProfileHome");
    }


    string replaceModule(string data)
    {
        string newString=data;
        for (int i=0; i < questions.Count; i++)
        {
            newString = newString.Replace(keywords[i], questions[i]);
        }



        return newString;

    }

}
