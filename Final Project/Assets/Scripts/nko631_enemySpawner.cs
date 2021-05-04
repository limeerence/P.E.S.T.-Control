using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class WaveAction
{
    public string name;
    public float delay;
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
    public float difficultyFactor = 0.5f;
    public List<Wave> waves;
    private Wave m_CurrentWave;
    public int currentEnemys;
    private bool inProgressWave = false;
    GameObject canvas;
    public Text CurrentE;
    public Transform[] enemySpawnPoints;

    public void Update()
    {
        CurrentE.text = "Current Enemies: " + currentEnemys;
    }

    public Wave CurrentWave { get { return m_CurrentWave; } }
    private float m_DelayFactor = 1.0f;

    IEnumerator SpawnLoop()
    {
        m_DelayFactor = 1.0f;
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
    }

    public void FixedUpdate()
    {
        if (currentEnemys == 0)
        {
            Debug.Log("no enmieskgjfk");
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
            inProgressWave = false;
        }
    }

    public void updateCurrent(int subHealth)
    {
        currentEnemys += subHealth;

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }


    void Start()
    {
        if (!controller)
        {
            controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<oos266_GameController>();
        }
        StartCoroutine(SpawnLoop());
    }
}