using System.Collections;
using System.Collections.Generic;                                       
using UnityEngine;

public class level3 : MonoBehaviour
{ AudioSource myaudio;

    // Start is called before the first frame update
    void Start()
    {
myaudio=GetComponent<AudioSource>();
//myaudio.clip=Resources.Load<AudioClip>("BELL");
myaudio.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
