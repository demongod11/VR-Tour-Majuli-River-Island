using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class VRImageLoader : MonoBehaviour
{
    public TextAsset imageListTextAsset; // Text file containing the image list and their coordinates
    public GameObject vrImagePrefab; // Prefab for the VR image
    public GameObject LeftButtonPrefab; // Prefab for the VR image
    public GameObject RightButtonPrefab; // Prefab for the VR image
    public Shader shader;

    void Start()
    {
        string[] lines = imageListTextAsset.text.Split('\n');
        GameObject rawanapar = new GameObject();
        rawanapar.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        rawanapar.name = "Rawanapar";
        GameObject canvasObj = GameObject.FindWithTag("canvas");
        foreach (string line in lines)
        {
            if (!string.IsNullOrEmpty(line))
            {
                string[] values = line.Split(',');
                string imageName = values[0].Trim();
                float latitude = float.Parse(values[1].Trim());
                float longitude = float.Parse(values[2].Trim());
                float altitude = float.Parse(values[3].Trim());
                float yaw = float.Parse(values[4].Trim());

                Vector3 position = new Vector3(latitude, altitude, longitude);

                // Create a new VR image at the specified position and rotation
                GameObject vrImage = Instantiate(vrImagePrefab, position, Quaternion.Euler(0, yaw, 0));
                GameObject leftButton = Instantiate(LeftButtonPrefab, position + new Vector3(-0.5f,0,0), Quaternion.Euler(0, 0, 0));
                GameObject rightButton = Instantiate(RightButtonPrefab, position + new Vector3(0.5f, 0, 0), Quaternion.Euler(0, 0, 0));
                vrImage.transform.SetParent(rawanapar.GetComponent<Transform>(),false);
                leftButton.transform.SetParent(canvasObj.GetComponent<Transform>(), false);
                rightButton.transform.SetParent(canvasObj.GetComponent<Transform>(), false);

                // Load and apply the texture to the VR image
                string imageUrl = Application.dataPath + "/Images/Rawanapar/" + imageName + ".JPG";
                Material material = new Material(shader);

                // Load the image from the specified URL
                StartCoroutine(LoadImage(imageUrl, texture =>
                {
                    // Set the albedo texture property of the material
                    material.SetTexture("_MainTex", texture);

                    // Assign the material to a game object or renderer
                    vrImage.GetComponent<Renderer>().material = material;
                    vrImage.name = imageName;
                }));
            }
        }
 
    }

    IEnumerator LoadImage(string url, System.Action<Texture2D> callback)
    {
        // Create a new WWW object to load the image from the URL
        WWW www = new WWW(url);

        // Wait for the download to complete
        yield return www;

        // Create a new texture using the downloaded data
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(www.bytes);

        // Invoke the callback with the loaded texture
        callback(texture);
    }
}
