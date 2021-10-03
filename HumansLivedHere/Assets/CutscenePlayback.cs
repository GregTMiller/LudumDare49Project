using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutscenePlayback : MonoBehaviour
{
    VideoPlayer cutscenePlayer;
    GameObject Player;
    GameObject Background;
    // Start is called before the first frame update
    void Start()
    {
        cutscenePlayer = this.GetComponent<VideoPlayer>();
        Player = this.gameObject.transform.parent.gameObject;
        Background = Player.gameObject.transform.parent.gameObject;
        cutscenePlayer.loopPointReached += EndReached;
    }

    // Update is called once per frame
     public void EndReached(VideoPlayer cutscenePlayer)
    {
        Debug.Log("Video Done!");
        Destroy(Player);
        Destroy(cutscenePlayer);
        Destroy(Background);
    }

}
