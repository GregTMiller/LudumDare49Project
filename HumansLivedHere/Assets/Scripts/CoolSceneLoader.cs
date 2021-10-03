using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoolSceneLoader : MonoBehaviour
{
    public string sceneID;
    public bool Loading;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            if(Loading)
            {
                SceneManager.LoadSceneAsync(sceneID, LoadSceneMode.Additive);
            }
            else
            {
                SceneManager.UnloadSceneAsync(sceneID);
            }
            
        }
    }
}
