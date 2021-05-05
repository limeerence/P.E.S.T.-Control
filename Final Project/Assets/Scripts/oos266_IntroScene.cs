using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class oos266_IntroScene : MonoBehaviour
{
    private int mainmenuIndex = 1;
    private int waitForImage = 10;
    private int waitForSkip = 5;

    [SerializeField] private Image sceneImage;
    [SerializeField] private Sprite[] scenes;

    [SerializeField] private Button skip;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine("IntroScene");
        } else
        {
            StartCoroutine("EndScene");
        }
            
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMenu();
        }

    }

    IEnumerator IntroScene()
    {
        sceneImage.sprite = scenes[0];
        yield return new WaitForSeconds(waitForSkip);
        skip.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitForSkip);

        sceneImage.sprite = scenes[1];
        yield return new WaitForSeconds(waitForImage);

        sceneImage.sprite = scenes[2];
        yield return new WaitForSeconds(waitForImage);

        sceneImage.sprite = scenes[3];
        yield return new WaitForSeconds(waitForImage);

        sceneImage.sprite = scenes[4];
        yield return new WaitForSeconds(waitForImage);

        SceneManager.LoadScene(mainmenuIndex);
    }

    IEnumerator EndScene()
    {
        sceneImage.sprite = scenes[0];
        yield return new WaitForSeconds(4);
        skip.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);

        sceneImage.sprite = scenes[1];
        yield return new WaitForSeconds(6);

        sceneImage.sprite = scenes[2];
        yield return new WaitForSeconds(7);

        sceneImage.sprite = scenes[3];
        yield return new WaitForSeconds(3);

        sceneImage.sprite = scenes[4];
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(mainmenuIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(mainmenuIndex);
    }

}
