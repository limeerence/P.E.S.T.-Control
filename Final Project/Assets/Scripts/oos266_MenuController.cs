using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class oos266_MenuController : MonoBehaviour
{
    [SerializeField] public GameObject gamePanel;
    [SerializeField] public GameObject pausePanel;

    private int mainmenuIndex = 0;
    private int level1Index = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != mainmenuIndex)
        {
            gamePanel.SetActive(false);
            pausePanel.SetActive(true);
            PauseGame();
        }

        if (SceneManager.GetActiveScene().buildIndex == mainmenuIndex)
        {
            Cursor.visible = true;
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
}
