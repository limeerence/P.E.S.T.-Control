using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nko631_powerupSpawner : MonoBehaviour
{
    public GameObject[] powerups;
    public Transform[] powerupSpawners;

    private void Start()
    {
        int pupSpawnersLen = powerupSpawners.Length -1;
        for (int i = 0; i <= pupSpawnersLen; i++)
        {
            int randomP = Random.Range(0, 5);                                //random number 0-4
            //Debug.Log(randomP);
            if (randomP == 4)                                                 //if it does 4 then nothing will spawn (20% chance)
            { }
            else
                Instantiate(powerups[randomP], (powerupSpawners[i]));
        }

        /*
        Instantiate(powerups[0], (powerupSpawners[0]));
        Instantiate(powerups[1], (powerupSpawners[1]));
        Instantiate(powerups[2], (powerupSpawners[2]));
        Instantiate(powerups[3], (powerupSpawners[3]));*/
    }
}
