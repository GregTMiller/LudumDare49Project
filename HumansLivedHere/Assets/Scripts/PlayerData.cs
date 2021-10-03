using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public bool[] keys;
    public float[] position;
    public string SceneName;

    public PlayerData (PlayerMovement player)
    {
        SceneName = player.sceneName;
        keys = new bool[4];
        keys[0] = player.redKey.keyCollected;
        keys[1] = player.blueKey.keyCollected;
        keys[2] = player.greenKey.keyCollected;
        keys[3] = player.yellowKey.keyCollected;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;


    }

    
}
