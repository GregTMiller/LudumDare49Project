using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject DO;

    private void OnTriggerEnter2D(Collider2D other) 
    {

        if(other.CompareTag("Player") && other.TryGetComponent(out PlayerMovement player))
        {

            player.interact = this;

        }

    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        
        if(other.CompareTag("Player") && other.TryGetComponent(out PlayerMovement player))
        {

            if(player.interact is DialogueActivator DA && DA == this)
            {

                player.interact = null;

            }

        }

    }

    public void Interact (PlayerMovement player)
    {

        player.DUI.ShowDialogue(DO);
        player.interact = null;

    }


}
