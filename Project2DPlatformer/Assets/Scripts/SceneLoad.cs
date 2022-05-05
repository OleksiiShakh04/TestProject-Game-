using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{

    
    public GameObject pauseGameMenu;
    public bool gamepause = true;
  

   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (gamepause)
            
                PauseGame();

            else
                Resume();





        }
    }


    public void SceneLoadd(int index)
    {


        SceneManager.LoadScene(index);

    }



    public void ExitGame()
    {

        Application.Quit();


    }

   public void PauseGame()
    {


        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        gamepause = false;


    }

    public void Resume()
    {


        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        gamepause = true;

    }



   
}
