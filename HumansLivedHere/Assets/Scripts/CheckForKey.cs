using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum checkType
{

    Door,
    Platform

}

public class CheckForKey : MonoBehaviour
{
    public checkType interactionType;
    public int requiredKey;
    public GameObject target;
    bool canUse;
    // Start is called before the first frame update
    void Start()
    {
        switch (requiredKey)
        {
            case 0:
            target.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            break;
            case 1:
            target.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
            break;
            case 2:
            target.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
            break;
            case 3:
            target.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);
            break;
        }
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {

            canUse = other.GetComponent<PlayerMovement>().checkKey(requiredKey);
            Debug.Log("canUse " + canUse);
            if(canUse && interactionType == checkType.Door)
            {

                target.GetComponent<DoorOpen>().moveGameObjectToTarget(1);

            }

        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {

            canUse = other.GetComponent<PlayerMovement>().checkKey(requiredKey);
            if(canUse && interactionType == checkType.Door)
            {

                target.GetComponent<DoorOpen>().moveGameObjectToTarget(0);

            }

        }
    }
}
