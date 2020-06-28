using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShowText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

{

    public Text statValue;
    public bool displayInfo;
   
    [SerializeField]
    private float fadeTime;
    // Start is called before the first frame update
    void Start()
    {
        statValue.color = Color.clear;
    }

    void Update()
    {
        FadeText();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        displayInfo = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        displayInfo = false;
    }

    public void FadeText()
    {
        if(displayInfo)
        {
        statValue.color = Color.Lerp (statValue.color, Color.white, fadeTime * Time.deltaTime);
        }
        else
        {
        statValue.color = Color.Lerp (statValue.color, Color.clear, fadeTime * Time.deltaTime);
        }
    }
}
