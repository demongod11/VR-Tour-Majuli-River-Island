using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickbutton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject videopanel;
    void Start()
    {
        // videopanel.SetActive(false);
    }
    public void click()
    {
        if(videopanel.activeSelf)
        {
            Debug.Log("inactive");
            videopanel.SetActive(false);
        }
        else{
            Debug.Log("once");
            Debug.Log(videopanel.activeSelf);
            videopanel.SetActive(true);
            Debug.Log(videopanel.activeSelf);
        }
        // Debug.Log("loading");
        // Loader.Load(Loader.Scene.SampleScene);
    }
    public void closeclick()
    {
        videopanel.SetActive(false);
    }
    public void skipclick()
    {
        Loader.Load(Loader.Scene.SampleScene);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
