using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


public class Tooltip : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject TT;
    public string toolTipText;
    public bool isUnlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        var textbox = GetComponentsInChildren<TextMeshProUGUI>();

        foreach (TextMeshProUGUI textInsert in textbox)
            textInsert.text = toolTipText;
        TT.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        TT.SetActive(true);
    }

    private void OnMouseExit() 
    {
        TT.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(isUnlocked == true)
            TT.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TT.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        Debug.Log("I have no idea what this is for, but it crashes if I don't have it.");
    }
}
