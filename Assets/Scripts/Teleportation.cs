using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleportation : MonoBehaviour
{
    public GameObject maxiMap;
    List<string> startImgNames;

    public void teleport()
    {
        string cur_loc_ball = VRImageLoader.vrImage.name;
        string cur_spot = VRImageLoader.adjList[cur_loc_ball][5];
        GameObject cur_spot_obj = GameObject.FindGameObjectWithTag(cur_spot);
        GameObject curSpot = GameObject.Find(cur_loc_ball);
        //curSpot.GetComponent<Image>().color = Color.white;
        //curPin.GetComponent<Image>().color = Color.white;
        cur_spot_obj.GetComponent<Image>().color = Color.black;
        startImgNames = VRImageLoader.startImgNames;
        string currentTag = gameObject.tag;
        gameObject.GetComponent<Image>().color = Color.red;
        TeleportController.active[int.Parse(cur_spot)] = false;
        maxiMap.SetActive(false);
        VRImageLoader.ImageLoader(startImgNames[int.Parse(currentTag)]);
        GameObject teleSpot = GameObject.Find(startImgNames[int.Parse(currentTag)]);
        //Debug.Log(startImgNames[int.Parse(currentTag)]);
        teleSpot.GetComponent<Image>().color = Color.red;
    }
}
