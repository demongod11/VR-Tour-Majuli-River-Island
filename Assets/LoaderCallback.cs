using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool isFirstupdate = true;


    // Update is called once per frame
    private void Update()
    {
        if(isFirstupdate)
        {
            isFirstupdate=false;
            Loader.LoaderCallback();
        }
    }
}
