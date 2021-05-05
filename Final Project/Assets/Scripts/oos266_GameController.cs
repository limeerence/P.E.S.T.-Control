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
    [SerializeField] private Image areaNameImage;
    [SerializeField] private Text enemiesRemainingText; //pnf839- adding this so the player could see how many enemies would be remaining
    private GameObject[] allEnemies; //pnf839 - added this for checking if enemies are still around
   // private GameObject boss; //pnf839 - added this for the boss// there was no boss 


    public bool shieldPowerUp = false;
    public bool snowflakePowerUp = false;
    public int enemiesRemaining;

    [SerializeField] public GameObject gameOverPanel;

    private void Start()
    {
        enemiesRemaining = PlayerPrefs.GetInt("Enemies Remaining: ", 2);
        StartCoroutine("AreaNamePopup");
    }

    private void Update()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy"); //pnf839- added this so that you could move on to the next level.
        enemiesRemainingText.text = "Enemies Remaining: " + allEnemies.Length;
        //boss = GameObject.FindGameObjectsWithTag("boss"); //pnf839- added this so that you could move on to the next level.
        if (allEnemies.Length == 0)
        {
            PlayerPrefs.GetInt("Enemies Remaining: ", 2);
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));            
        }
        
        /*if (boss. == 0)
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1)); //added this for when you reach the boss levels. //no need
        }*/


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

    IEnumerator AreaNamePopup()
    {
        areaNameImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        areaNameImage.gameObject.SetActive(false);
    }

    /*
    public void updateWeapon(int keypressed)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject pestMachine = player.transform.Find("pest_machine").gameObject;
        GameObject fireMachine = player.transform.Find("fire").gameObject;
        pnf839_shootingScript ss;
        ss = player.transform.Find("pest_machine").transform.Find("spawnpoint").GetComponent<pnf839_shootingScript>();
        switch (keypressed)
        {
            case 1:
                pestMachine.gameObject.active = true;
                fireMachine.gameObject.active = false;
                ss.bulletDelay = 0.5f;
                break;
            case 2:
                fireMachine.gameObject.active = true;
                pestMachine.gameObject.active = false;
                ss.bulletDelay = 0.2f;
                break;
        }
    }
    */
}