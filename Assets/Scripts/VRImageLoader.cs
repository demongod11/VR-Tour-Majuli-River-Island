using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class VRImageLoader : MonoBehaviour
{
    public TextAsset imageListTextAsset; 
    public GameObject vrImagePrefab; 
    public GameObject LeftButtonPrefab; 
    public GameObject RightButtonPrefab; 
    public GameObject UpButtonPrefab; 
    public GameObject DownButtonPrefab; 
    public Shader shader;
    public static Dictionary<string, List<string>> adjList;
    public static Dictionary<int, string> imgMap;
    public static Dictionary<string, int> corMap;

    void Start()
    {
        adjList = new Dictionary<string, List<string>>();
        imgMap = new Dictionary<int, string>();
        corMap = new Dictionary<string, int>();

        int x_cor = 0;
        string[] lines = imageListTextAsset.text.Split('\n');
        string first_line = lines[0].Trim();
        int cnt = -2;
        int num_spots = int.Parse(first_line);
        GameObject[] spot_obj = new GameObject[num_spots];

        GameObject canvasObj = GameObject.FindWithTag("canvas");
        foreach (string line in lines)
        {
            if(cnt == -2)
            {
                cnt++;
                continue;
            }
            if (!string.IsNullOrEmpty(line))
            {
                int flag = 0;
                for(int i=0; i<line.Length; i++)
                {
                    if(line[i] == ',')
                    {
                        flag = 1;
                        break;
                    }
                }
                if(flag == 0)
                {
                    cnt++;
                    spot_obj[cnt] = new GameObject(line);
                    spot_obj[cnt].GetComponent<Transform>().position = new Vector3(0, 0, 0);
                }
                else
                {
                    string[] values = line.Split(',');
                    string imageName = values[0].Trim();
                    List<string> value = new List<string>();
                    for (int i = 1; i < 5; i++)
                    {
                        value.Add(values[i].Trim());
                    }

                    float yaw = float.Parse(values[5].Trim());
                    adjList.Add(imageName, value);

                    imgMap.Add(x_cor, imageName);
                    corMap.Add(imageName, x_cor);

                    Vector3 position = new Vector3(x_cor, 0, 0);
                    x_cor += 2;

                    // Create a new VR image at the specified position and rotation
                    GameObject vrImage = Instantiate(vrImagePrefab, position, Quaternion.Euler(0, yaw, 0));
                    if (adjList[imageName][0] != "-1")
                    {
                        GameObject rightButton = Instantiate(RightButtonPrefab, position + new Vector3(0.5f, 0, 0), Quaternion.Euler(0, 0, 0));
                        rightButton.transform.SetParent(canvasObj.GetComponent<Transform>(), false);
                    }
                    if (adjList[imageName][1] != "-1")
                    {
                        GameObject downButton = Instantiate(DownButtonPrefab, position + new Vector3(0, -0.5f, 0), Quaternion.Euler(0, 0, 0));
                        downButton.transform.SetParent(canvasObj.GetComponent<Transform>(), false);
                    }
                    if (adjList[imageName][2] != "-1")
                    {
                        GameObject leftButton = Instantiate(LeftButtonPrefab, position + new Vector3(-0.5f, 0, 0), Quaternion.Euler(0, 0, 0));
                        leftButton.transform.SetParent(canvasObj.GetComponent<Transform>(), false);
                    }
                    if (adjList[imageName][3] != "-1")
                    {
                        GameObject upButton = Instantiate(UpButtonPrefab, position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, 0, 0));
                        upButton.transform.SetParent(canvasObj.GetComponent<Transform>(), false);
                    }

                    vrImage.transform.SetParent(spot_obj[cnt].GetComponent<Transform>(), false);

                    // Load and apply the texture to the VR image
                    string imageUrl = Application.dataPath + "/Images/" + spot_obj[cnt].name + "/" + imageName + ".JPG";
                  //  Debug.Log("/Images/" + spot_obj[cnt].name + "/" + imageName + ".JPG");
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
 
    }

    IEnumerator LoadImage(string url, System.Action<Texture2D> callback)
    {
        Debug.Log(url);
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
