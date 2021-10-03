using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyThis : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if(sceneName == "TitleScreen" || sceneName == "Credits")
        {
            Destroy(this.gameObject);

        }
    }
}
