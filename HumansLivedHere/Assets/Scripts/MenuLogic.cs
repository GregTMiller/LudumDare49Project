using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu != null)
        {
            pauseUnpauseGame();
        }
    }

    public void pauseUnpauseGame()
    {
            if(Time.timeScale == 0)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 1;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 0;
            }
    }


    public void quitGame()
    {

        Application.Quit();

    }

    public void loadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);


    }

    public void hideUnhideObject(GameObject target)
    {
        if(target.activeInHierarchy == true)
        {
            target.GetComponent<MenuAnimationLogic>().closeMenu();

        }
        else if(target.activeInHierarchy == false)
        {
            target.SetActive(true);
            target.GetComponent<MenuAnimationLogic>().openMenu();
        }


    }
}
