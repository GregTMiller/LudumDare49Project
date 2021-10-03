using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogueUI : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text textLabel;
    public DialogueObject testObject;
    public bool IsOpen {get; private set;}
    private TypeWritterEffect typewritter;
    private ResponceHandlier responceChecker;
    public Image profileSlot;
    public TMP_Text name;
    // Start is called before the first frame update
    void Start()
    {
        typewritter = GetComponent<TypeWritterEffect>();
        responceChecker = GetComponent<ResponceHandlier>();
        closeDialogue();
    }

    public void ShowDialogue(DialogueObject DO)
    {
        IsOpen = true;
        profileSlot.sprite = DO.Profile;
        name.text = DO.SpeakerName;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(DO));

    }

    private IEnumerator StepThroughDialogue(DialogueObject DO)
    {

        for (int i = 0; i < DO.Dialogue.Length; i++)
        {

            string dialogue = DO.Dialogue[i];
            yield return typewritter.Run(dialogue,textLabel);
            if(i == DO.Dialogue.Length - 1 && DO.hasResponces) break;
            yield return new WaitUntil(() => Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.JoystickButton0));
        }

        if(DO.hasResponces)
        {

            responceChecker.ShowResponce(DO.Response);

        }
        else
        {
            closeDialogue();
        }

    }

    private void closeDialogue()
    {
        IsOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = "";
    }
}
