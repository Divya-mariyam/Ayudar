using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ListCreator : MonoBehaviour
{

    [SerializeField]
    private Transform SpawnPoint = null;

    [SerializeField]
    private GameObject item = null;

    [SerializeField]
    private RectTransform content = null;

    [SerializeField]
    public int numberOfItems = 3;

    public string[] itemNames = null;
    public List<string> studentUsernames = null;
    public List<string> studentGenders = null;
    public List<string> studentDobs = null;

   // public List<string> studentHeights = null;
    public List<string> m_DropOptions;

    public string doctorUserName;
   IEnumerator Start()
      {

        Debug.Log(session.userName);
        doctorUserName = session.userName;

        WWWForm form = new WWWForm();
        Debug.Log("USERNAME");
        Debug.Log(doctorUserName);
        form.AddField("doctorName", doctorUserName);
        UnityWebRequest www = UnityWebRequest.Post("https://six-crepe.glitch.me/list_student", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");

            var N = JSON.Parse(www.downloadHandler.text);
            JSONArray arr = (JSONArray)N;
            m_DropOptions = new List<string>();
            for (int i = 0; i < arr.Count; i++)
            {
                m_DropOptions.Add(arr[i]["childName"]);
                studentUsernames.Add(arr[i]["username"]);
                studentGenders.Add(arr[i]["childGender"]);
                studentDobs.Add(arr[i]["dob"]);

               // studentHeights.Add(arr[i]["height"]);

                Debug.Log(arr[i]["childName"]);
            }

            Debug.Log(arr.Count);
        }
        numberOfItems = m_DropOptions.Count;
        content.sizeDelta = new Vector2(0, numberOfItems * 190);
        for (int i = 0; i < numberOfItems; i++)
        {
            float spawnY = i * 60;
            //newSpawn Position
            Vector3 pos = new Vector3(SpawnPoint.position.x, -spawnY, SpawnPoint.position.z);
            //instantiate item
            GameObject SpawnedItem = Instantiate(item, pos, SpawnPoint.rotation);
            //setParent
            SpawnedItem.transform.SetParent(SpawnPoint, false);
            //get ItemDetails Component
            ItemDetails itemDetails = SpawnedItem.GetComponent<ItemDetails>();
            //set name
            itemDetails.name.text = m_DropOptions[i];
            itemDetails.dob.text = studentDobs[i];
            itemDetails.gender.text = studentGenders[i];
            itemDetails.username.text = studentUsernames[i];
           // itemDetails.height.text = studentHeights[i];

            //set image



        }
    }


    public void loadStudentProfile(string studentUsername)
    {

    }
}