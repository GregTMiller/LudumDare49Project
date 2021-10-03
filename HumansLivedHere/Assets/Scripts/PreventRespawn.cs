using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventRespawn : MonoBehaviour
{
    public int newKeyID;
    public GameObject keyPrefab;
    CollectKey thisKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

        if(GameObject.FindWithTag("Player"))
        {
            GameObject playerHolder = GameObject.FindWithTag("Player");
            if(playerHolder.GetComponent<PlayerMovement>().checkKey(newKeyID) != true)
            {
                GameObject target = Instantiate(keyPrefab, transform.position, Quaternion.identity);
                thisKey = target.GetComponent<CollectKey>();
                thisKey.keyID = newKeyID;
                Destroy(this.gameObject);

            }
        }

    }

    
}
