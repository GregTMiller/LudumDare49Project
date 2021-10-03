using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCCheck : MonoBehaviour
{
    public GameObject TT;
    public string toolTipText;
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

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            TT.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            TT.SetActive(false);

        }
    }
}
