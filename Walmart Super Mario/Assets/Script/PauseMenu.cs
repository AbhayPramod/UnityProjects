using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenu;
    
    public static int hp; 

    // Update is called once per frame
    void Update()
    {
        hp = Player.currentHealth;
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Trying to pause");

            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
        

        if (hp <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
            
        }
    }


    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void Onquit()
    {
        Application.Quit();
    }         
}

    
