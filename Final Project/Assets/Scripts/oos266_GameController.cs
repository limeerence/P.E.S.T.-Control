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
    [SerializeField] public Sprite health0;
    [SerializeField] public Sprite health1;
    [SerializeField] public Sprite health2;
    [SerializeField] public Sprite health3;
    [SerializeField] public Sprite health4;
    [SerializeField] public Sprite health5;

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
        switch (health)
        {
            case 0:
                GameOver();
                break;
            case 1:
                healthBar.sprite = health1;
                break;
            case 2:
                healthBar.sprite = health2;
                break;
            case 3:
                healthBar.sprite = health3;
                break;
            case 4:
                healthBar.sprite = health4;
                break;
            case 5:
                healthBar.sprite = health5;
                break;
            default:
                break;
        }
    }

    public void GameOver()
    {
        healthBar.sprite = health0;
        gameOverPanel.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.pnf839_CharCont>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        Debug.Log("GAME OVER!!");
    }

}