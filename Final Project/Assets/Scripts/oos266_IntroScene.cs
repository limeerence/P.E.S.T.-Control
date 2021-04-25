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
    [SerializeField] private Sprite scene1;
    [SerializeField] private Sprite scene2;
    [SerializeField] private Sprite scene3;
    [SerializeField] private Sprite scene4;
    [SerializeField] private Sprite scene5;

    [SerializeField] private Button skip;

    void Start()
    {
        StartCoroutine("IntroScene");
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
        sceneImage.sprite = scene1;
        yield return new WaitForSeconds(waitForSkip);
        skip.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitForSkip);

        sceneImage.sprite = scene2;
        yield return new WaitForSeconds(waitForImage);

        sceneImage.sprite = scene3;
        yield return new WaitForSeconds(waitForImage);

        sceneImage.sprite = scene4;
        yield return new WaitForSeconds(waitForImage);

        sceneImage.sprite = scene5;
        yield return new WaitForSeconds(waitForImage);

        SceneManager.LoadScene(mainmenuIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(mainmenuIndex);
    }

}
