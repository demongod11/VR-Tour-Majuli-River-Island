using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        string cur_loc_ball = VRImageLoader.vrImage.name;
        string cur_spot = VRImageLoader.adjList[cur_loc_ball][5];
        GameObject cur_spot_obj = GameObject.FindGameObjectWithTag(cur_spot);
        cur_spot_obj.GetComponent<Image>().color = Color.black;
        startImgNames = VRImageLoader.startImgNames;
        string currentTag = gameObject.tag;
        gameObject.GetComponent<Image>().color = Color.red;
        closeButton.SetActive(false);
        maxiMap.SetActive(false);
        VRImageLoader.ImageLoader(startImgNames[int.Parse(currentTag)]);
    }
}
