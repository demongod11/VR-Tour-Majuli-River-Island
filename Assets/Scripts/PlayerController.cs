using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Dictionary<string, List<string>> adjList;
    string imgName, rightImgName, downImgName, leftImgName, upImgName;

    public void ShiftRight()
    {
        imgName = VRImageLoader.vrImage.name;
        rightImgName = VRImageLoader.adjList[imgName][0];

        if (rightImgName != "-1")
        {
            VRImageLoader.ImageLoader(rightImgName);
            //miniMap(imgName,rightImgName);
        }
    }

    public void ShiftDown()
    {
        imgName = VRImageLoader.vrImage.name;
        downImgName = VRImageLoader.adjList[imgName][1];

        if (downImgName != "-1")
        {
            VRImageLoader.ImageLoader(downImgName);
            //miniMap(imgName,downImgName);
        }
    }

    public void ShiftLeft()
    {
        imgName = VRImageLoader.vrImage.name;
        leftImgName = VRImageLoader.adjList[imgName][2];

        if (leftImgName != "-1")
        {
            VRImageLoader.ImageLoader(leftImgName);
            //miniMap(imgName,leftImgName);
        }
    }

    public void ShiftUp()
    {
        imgName = VRImageLoader.vrImage.name;
        upImgName = VRImageLoader.adjList[imgName][3];

        if (upImgName != "-1")
        {
            VRImageLoader.ImageLoader(upImgName);
            //miniMap(imgName,upImgName);
        }
    }

    public void miniMap(string str1, string str2){
        GameObject curPin = GameObject.Find(str1);
        GameObject nxtPin = GameObject.Find(str2);
        curPin.GetComponent<Image>().color = Color.white;
        nxtPin.GetComponent<Image>().color = Color.red;
    }
}
