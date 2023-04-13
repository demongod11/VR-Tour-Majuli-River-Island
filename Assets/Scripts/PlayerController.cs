using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int old_x, x_left, x_right, x_down, x_up;
    GameObject playerObj;
    Dictionary<string, List<string>> adjList;
    Dictionary<int, string> imgMap;
    Dictionary<string, int> corMap;
    string imgName, rightImgName, downImgName, leftImgName, upImgName;
    private void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        adjList = VRImageLoader.adjList;
        imgMap = VRImageLoader.imgMap;
        corMap = VRImageLoader.corMap;
        old_x = (int)playerObj.transform.position.x;
        imgName = imgMap[old_x];
        rightImgName = adjList[imgName][0];
        downImgName = adjList[imgName][1];
        leftImgName = adjList[imgName][2];
        upImgName = adjList[imgName][3];

        if(rightImgName != "-1")
        {
            x_right = corMap[rightImgName];
        }
        if (downImgName != "-1")
        {
            x_down = corMap[downImgName];
        }
        if (leftImgName != "-1")
        {
            x_left = corMap[leftImgName];
        }
        if (upImgName != "-1")
        {
            x_up = corMap[upImgName];
        }
    }

    public void ShiftRight()
    {

        playerObj.transform.position = new Vector3(x_right, 0, 0);
    }

    public void ShiftLeft()
    {
        playerObj.transform.position = new Vector3(x_left, 0, 0);
    }

    public void ShiftUp()
    {
        playerObj.transform.position = new Vector3(x_up, 0, 0);
    }

    public void ShiftDown()
    {
        playerObj.transform.position = new Vector3(x_down, 0, 0);
    }
}
