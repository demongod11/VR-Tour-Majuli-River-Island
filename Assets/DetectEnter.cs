using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnter : MonoBehaviour
{
    // Start is called before the first frame update
    public bool activeButton=false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activeButtonFunction(){
        activeButton=true;
        Debug.Log("activated");
    }
    public void inActiveButtonFunction(){
        activeButton=false;
        Debug.Log("deactivated");
    }
}
