using UnityEngine;

[System.Serializable]
public class Response
{
    [SerializeField] public string responceText;
    [SerializeField] private DialogueObject DO;

    public string ResponceText => responceText;

    public DialogueObject DialogueObject => DO;

}
