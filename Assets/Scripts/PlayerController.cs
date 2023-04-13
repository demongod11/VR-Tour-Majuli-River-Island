using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float old_x;
    float old_y;
    float old_z;
    GameObject playerObj;
    private void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        old_x = GameObject.FindWithTag("Player").transform.position.x;
        old_y = GameObject.FindWithTag("Player").transform.position.y;
        old_z = GameObject.FindWithTag("Player").transform.position.z;
    }

    public void ShiftRight()
    {
        playerObj.transform.position = new Vector3(old_x + 2, old_y, old_z);
    }

    public void ShiftLeft()
    {
        playerObj.transform.position = new Vector3(old_x - 2, old_y, old_z);
    }

    public void ShiftUp()
    {
        playerObj.transform.position = new Vector3(old_x, old_y, old_z + 2);
    }

    public void ShiftDown()
    {
        playerObj.transform.position = new Vector3(old_x, old_y, old_z - 2);
    }
}
