using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class oos266_IntroScene : MonoBehaviour
{
    private int mainmenuIndex = 1;
    private int waitForImage = 10;

    [SerializeField] private Image sceneImage;
    [SerializeField] private Sprite scene1;
    [SerializeField] private Sprite scene2;
    [SerializeField] private Sprite scene3;
    [SerializeField] private Sprite scene4;
    [SerializeField] private Sprite scene5;

    void Start()
    {
        StartCoroutine("IntroScene");
    }

    IEnumerator IntroScene()
    {
        sceneImage.sprite = scene1;
        yield return new WaitForSeconds(waitForImage);

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

}
