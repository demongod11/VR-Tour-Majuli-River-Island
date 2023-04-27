using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Triggermap : MonoBehaviour
{
    
    public GameObject mapobj;

    public void OnTriggerMap()
    {
        if(!mapobj.activeSelf)
        {
            mapobj.SetActive(true);
        }
        else if(mapobj.activeSelf)
        {
            mapobj.SetActive(false);
        }
        Debug.Log("button pressed");
        
    }
}
