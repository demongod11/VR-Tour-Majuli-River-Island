using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressmap : MonoBehaviour
{
    private Image image;
    // Update is called once per frame
    private void Awake()
    {
        image=transform.GetComponent<Image>();
    }
    private void Update()
    {
        image.fillAmount=Loader.GetLoadingProgress();
    }
}
