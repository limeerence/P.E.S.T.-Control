using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class oos266_GameController : MonoBehaviour
{
    public int jumpIntensity = 6;
    public int health = 5;

    [SerializeField] public Image healthBar;
    [SerializeField] public Sprite[] healthSprites;

    [SerializeField] private Image healthImage;
    [SerializeField] private Image shieldedImage;
    [SerializeField] private Image slowedImage;

    public bool shieldPowerUp = false;
    public bool snowflakePowerUp = false;

    [SerializeField] public GameObject gameOverPanel;

    private void Start()
    {
        
    }

    private void Update()
    {
       /* if (health <= 0) {
            //GameOver();
            Debug.Log("Taking damage");
        }*/
    }

    public void updateHealth(int addHealth)
    {
        health += addHealth;
        Debug.Log("Update health: " + health);
        if (health <= 0)
        {
            GameOver();
        }
        healthBar.sprite = healthSprites[health];

    }

    public void GameOver()
    {
        healthBar.sprite = healthSprites[0];
        gameOverPanel.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.pnf839_CharCont>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        Debug.Log("GAME OVER!!");
    }

    public IEnumerator healthPopup()
    {
        healthImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        healthImage.gameObject.SetActive(false);
    }

    public IEnumerator shielded()
    {
        shieldPowerUp = true;
        shieldedImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(10);
        shieldPowerUp = false;
        shieldedImage.gameObject.SetActive(false);
    }

    public IEnumerator slowed()
    {
        snowflakePowerUp = true;
        slowedImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(10);
        snowflakePowerUp = false;
        slowedImage.gameObject.SetActive(false);
    }
}