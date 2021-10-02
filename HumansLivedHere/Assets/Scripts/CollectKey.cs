using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{

    public int keyID;
    public Animation anim;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
        anim.Play("Bobbing");
    }

    // Update is called once per frame
    void LateUpdate() {
        transform.localPosition += startPosition;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {

            other.GetComponent<PlayerMovement>().collectKey(keyID);
            anim.CrossFade("Shrink", 0.3F, PlayMode.StopSameLayer); 

        }
    }

    public void destroySelf()
    {
        Destroy(gameObject);
    }
}
