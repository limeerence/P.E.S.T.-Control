using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class WaveAction
{
    public string name;
    public float delay = 5f;
    public Transform prefab;
    public int spawnCount;
}

[System.Serializable]
public class Wave
{
    public string name;
    public List<WaveAction> actions;
    private bool spawn;
}



public class nko631_enemySpawner : MonoBehaviour
{
    [SerializeField] private oos266_GameController controller;
  /*  public float difficultyFactor = 0.5f;
    public List<Wave> waves;
    private Wave m_CurrentWave;
    public int currentEnemys;
    private bool inProgressWave = false;
    GameObject canvas;
    public Text CurrentE;
    */
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int nEnemiesInWave = 2;
    [SerializeField] private float spawnWaveTime = 5f;
    [SerializeField] private float spawnEnemyInWaveTime = 2f;
    public Transform[] enemySpawnPoints;

    //[SerializeField] private GameManager gameController;

    public GameObject[] spawnClones;
    private float timer = 4f;
    public bool isWaveSpawning = false;
    public static int waveNum = 0;
    public static int num;

    void Start() {
        if (!controller) {
            controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<oos266_GameController>();
        }
        //StartCoroutine(SpawnLoop());
    }

    public void Update()
    {
        //CurrentE.text = "Current Enemies: " + currentEnemys;
        if (nEnemiesInWave == 4)
        {
            isWaveSpawning = false;
            //gameController.wavesRemaining = 0;
            //Debug.Log(gameController.wavesRemaining);
        }
        else
        {
            //Debug.Log(gameController.wavesRemaining);
            //once the timer reaches 0, it'll start spawning again
            if (timer <= 0)
            {
                StartCoroutine(SpawnWave());
                timer = spawnWaveTime;
            }
            //if not spawning, it'll make the timer go
            if (!isWaveSpawning)
                timer -= Time.deltaTime;
            //timerText.text = ((int)timer).ToString();

        }
    }

    IEnumerator SpawnWave()
    {
        //this will spawn the amount of enemies
        isWaveSpawning = true;
        nEnemiesInWave++;
        for (int i = 0; i < nEnemiesInWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnEnemyInWaveTime);
        }
        isWaveSpawning = false;
        waveNum++;
        //waveNumText.text = "Wave: " + waveNum;
    }
    public void SpawnEnemy()
    {
        //Instantiate(enemyPrefab, transform); //- edit out for a little bit
        num = Random.Range(0, 5);
        // spawns a clone of a given prefab, in order to create multiple instances that can be spawned and deleted 
         spawnClones[0] = Instantiate(enemyPrefab, enemySpawnPoints[num].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }

  //  public Wave CurrentWave { get { return m_CurrentWave; } }
   // private float m_DelayFactor = 5.0f;

/*    IEnumerator SpawnLoop()
    {
        m_DelayFactor = 5.0f;
        while (true)
        {

            foreach (Wave W in waves)
            {
                m_CurrentWave = W;
                foreach (WaveAction A in W.actions)
                {
                    if (!inProgressWave)
                    {
                        for (int i = 0; i < A.spawnCount; i++)
                        {
                            for (int u = 0; u <= enemySpawnPoints.Length-1; u++)
                            {
                                Instantiate(A.prefab, enemySpawnPoints[u]);
                                currentEnemys++;
                            }
                            inProgressWave = true;
                            yield return new WaitForSeconds(A.delay);
                        }
                    }

                    if (inProgressWave)
                    {

                        if (currentEnemys > 0)
                        {
                            StartCoroutine(wait());
                        }
                        else
                        {
                            inProgressWave = false;

                        }
                    }

                    yield return new WaitUntil(() => currentEnemys <= 0);

                }
                yield return null;
            }
            m_DelayFactor *= difficultyFactor;
            yield return null;

        }
    }*/

 /*   public void FixedUpdate()
    {
        if (currentEnemys == 0)
        {
            Debug.Log("no enmieskgjfk");
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
            inProgressWave = false;
        }
    }*/

   /* public void updateCurrent(int subHealth)
    {
        currentEnemys += subHealth;

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }*/


}