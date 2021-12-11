using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
public void quitapp()
  {
  Debug.Log("App Closed");
  Application.Quit();
  }
}
