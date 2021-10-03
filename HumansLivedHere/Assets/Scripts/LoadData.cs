using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadData : MonoBehaviour
{
    
    public void SavePlayer()
    {

        SaveSystem.SavePlayer(GameObject.FindWithTag("Player").GetComponent<PlayerMovement>());

    }

    public void LoadPlayer()
    {
        
        StartCoroutine(LoadScene());

    }

    IEnumerator LoadScene()
        {
            PlayerData data = SaveSystem.loadPlayer();
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(data.SceneName);
            while(!asyncOperation.isDone)
            {
            if(asyncOperation.progress >= 0.9f)
            {
                Debug.Log("Loading done!");
                GameObject player = GameObject.FindWithTag("Player");
                Debug.Log(player.gameObject.name);
                PlayerMovement PM = player.GetComponent<PlayerMovement>();
                Vector3 position;
                position.x = data.position[0];
                position.y = data.position[1];
                position.z = data.position[2];
                player.transform.position = position;
                PM.redKey.keyCollected = data.keys[0];
                PM.blueKey.keyCollected = data.keys[1];
                PM.greenKey.keyCollected = data.keys[2];
                PM.yellowKey.keyCollected = data.keys[3];
        }
        }
            yield return null;
        }




}
