using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimationLogic : MonoBehaviour
{
    public Animation anim;
    public string closeAnim;
    public string openAnim; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeMenu()
    {
        anim.Play(closeAnim);
    }

    public void openMenu()
    {

        anim.Play(openAnim);

    }

    public void hideObject()
    {
        gameObject.SetActive(false);
    }
}
