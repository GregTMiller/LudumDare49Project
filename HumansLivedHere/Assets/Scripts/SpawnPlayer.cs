using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject camera;
    public GameObject mainCamera;
    public GameObject canvasHolder;
    void Start()
    {
        if(GameObject.FindWithTag("Player"))
        {
            Debug.Log ("Already Exists!");
        }
        else
        {

            StartUp();

        }
    }

    void StartUp()
    {
        GameObject playerPrefab = Instantiate(player, transform.position, Quaternion.identity);
        GameObject playerCamera = Instantiate(camera, transform.position, Quaternion.identity);
        Instantiate(canvasHolder, transform.position, Quaternion.identity);
        Instantiate(mainCamera, transform.position, Quaternion.identity);
        CinemachineVirtualCamera cameraRef = playerCamera.GetComponent<CinemachineVirtualCamera>();
        cameraRef.Follow = playerPrefab.transform;
        cameraRef.LookAt = playerPrefab.transform;

    }
}
