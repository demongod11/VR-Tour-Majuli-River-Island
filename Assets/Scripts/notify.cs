using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class notify : MonoBehaviour
{
    // Start is called before the first frame update
    // public List<Sprite> sphereImages;  // Collection of images associated with this sphere
    public Text notificationText;  // Text component to notify player on screen

    private bool imagesAvailable = true;

    void Start()
    {
        // Create a new Canvas object and set it as the parent of the Button
        Canvas canvas = new GameObject("Canvas").AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 0;

        // Add a CanvasScaler component to the canvas to handle scaling for different resolutions
        canvas.gameObject.AddComponent<CanvasScaler>();

        // Add a GraphicRaycaster component to the canvas to handle input events
        canvas.gameObject.AddComponent<GraphicRaycaster>();

        // Create a new Button object and set its parent to the Canvas
        GameObject buttonObject = new GameObject("Button");
        buttonObject.transform.SetParent(canvas.transform, false);
        Button button = buttonObject.AddComponent<Button>();

        // Create a new Text object and set its parent to the Button
        GameObject textObject = new GameObject("Text");
        textObject.transform.SetParent(buttonObject.transform, false);
        Text text = textObject.AddComponent<Text>();

        // Set the text of the Text component
        text.text = "Click me!";

        // Set the font of the Text component
        text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");

        // Set the font size of the Text component
        text.fontSize = 20;

        // Set the alignment of the Text component
        text.alignment = TextAnchor.MiddleCenter;

        // Set the color of the Text component
        text.color = Color.black;

        // Add a white Image component to the Button
        Image image = buttonObject.AddComponent<Image>();
        image.color = Color.white;

        // Set the position and size of the Button
        RectTransform rectTransform = buttonObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.anchoredPosition = Vector2.zero;
        rectTransform.sizeDelta = new Vector2(200f, 50f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (imagesAvailable)
            {
                notificationText.text = "Images are available!";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            notificationText.text = "";
            imagesAvailable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
