using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool GameHasEnded = false;
    public GameObject deathScreen;

    public void EndGame()
    {  
        if (!GameHasEnded)
        {
            GameHasEnded = true;
            Debug.Log("gameover");
            Time.timeScale = 0f;
            deathScreen.SetActive(true);
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        deathScreen.SetActive(false);
    }

    public void LevelClear()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
