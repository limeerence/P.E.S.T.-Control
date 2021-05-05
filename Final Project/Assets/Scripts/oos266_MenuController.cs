using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class oos266_MenuController : MonoBehaviour
{
    [SerializeField] public GameObject gamePanel;
    [SerializeField] public GameObject pausePanel;

    private int mainmenuIndex = 1;
    private int level1Index = 2;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == mainmenuIndex)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != mainmenuIndex)
        {
            gamePanel.SetActive(false);
            pausePanel.SetActive(true);
            PauseGame();
        }

    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(level1Index);
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainmenuIndex);
    }

    public void RetryLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void level1Enemies()
    {
        SceneManager.LoadScene(2);
    }

    public void level1Boss()
    {
        SceneManager.LoadScene(3);
    }

    public void level2Enemies()
    {
        SceneManager.LoadScene(4);
    }

    public void level2Boss()
    {
        SceneManager.LoadScene(5);
    }

    public void level3Enemies()
    {
        SceneManager.LoadScene(6);
    }

    public void level3Boss()
    {
        SceneManager.LoadScene(7);
    }
}
