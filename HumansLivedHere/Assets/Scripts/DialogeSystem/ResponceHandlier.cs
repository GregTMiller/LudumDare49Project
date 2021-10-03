using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResponceHandlier : MonoBehaviour
{
    public RectTransform resBox;
    public GameObject resButtonTemplete;
    public RectTransform resHolder;

    private DialogueUI DUI;

    List<GameObject> tempStorage = new List<GameObject>();
    void Start()
    {
        DUI = GetComponent<DialogueUI>();
    }

    public void ShowResponce(Response[] responces)
    {
        float resBoxHeight = 0f;

        foreach(Response res in responces)
        {

            GameObject responceButton = Instantiate(resButtonTemplete.gameObject,resHolder);
            responceButton.gameObject.SetActive(true);
            responceButton.gameObject.GetComponentInChildren<TMP_Text>().text = res.responceText;
            responceButton.gameObject.GetComponent<Button>().onClick.AddListener(() => OnPickedResponce(res));
            tempStorage.Add(responceButton);     

        }
        resHolder.gameObject.SetActive(true);

    }

    void OnPickedResponce(Response resTarget)
    {

        foreach(GameObject target in tempStorage)
        {
            
            Destroy(target);

        }
        tempStorage.Clear();

        DUI.ShowDialogue(resTarget.DialogueObject);
        

    }
}
