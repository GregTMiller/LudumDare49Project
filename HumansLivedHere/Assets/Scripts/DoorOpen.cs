using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Transform[] Postions;

    int POSIndex;
    Transform nextPOS;
    // Start is called before the first frame update
    void Start()
    {
        nextPOS = Postions[0];
    }

    void Update()
    {

        transform.position = Vector3.Lerp(transform.position,nextPOS.position, 10f * Time.deltaTime);

    }

    // Update is called once per frame
   public void moveGameObjectToTarget(int nextPOSIndex)
   {
       POSIndex = nextPOSIndex;
       nextPOS = Postions[POSIndex];


   }
}
