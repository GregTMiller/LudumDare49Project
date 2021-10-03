using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{

    public int keyID;
    public Animation anim;
    Vector3 startPosition;
    public AudioSource sfxTrigger;
    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        switch (keyID)
        {
            case 0:
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            break;
            case 1:
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
            break;
            case 2:
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
            break;
            case 3:
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);
            break;
        }
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
            sfxTrigger.PlayOneShot(sound, 0.5f);
            other.GetComponent<PlayerMovement>().collectKey(keyID);
            anim.CrossFade("Shrink", 0.3F, PlayMode.StopSameLayer); 

        }
    }

    public void destroySelf()
    {
        Destroy(gameObject);
    }
}
