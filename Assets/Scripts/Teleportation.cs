using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject maxiMap, closeButton;
    List<string> startImgNames;

    public void mapActivate()
    {
        maxiMap.SetActive(true);
        closeButton.SetActive(true);
    }

    public void mapDeactivate()
    {
        closeButton.SetActive(false);
        maxiMap.SetActive(false); 
    }

    public void teleport()
    {
        startImgNames = VRImageLoader.startImgNames;
        string currentTag = gameObject.tag;
        closeButton.SetActive(false);
        maxiMap.SetActive(false);
        VRImageLoader.ImageLoader(startImgNames[int.Parse(currentTag)]);
    }
}
