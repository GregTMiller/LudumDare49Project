using UnityEngine;


[CreateAssetMenu(fileName = "DialogueObject", menuName = "Tools/DialogueObject", order = 0)]
public class DialogueObject : ScriptableObject 
{
    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] private Response[] responces;
    [SerializeField] private Sprite profile;
    [SerializeField] private string speakerName;

    public string[] Dialogue => dialogue;

    public bool hasResponces => Response != null && Response.Length > 0;
    
    public Response[] Response => responces;

    public Sprite Profile => profile;
    
    public string SpeakerName => speakerName;
}
