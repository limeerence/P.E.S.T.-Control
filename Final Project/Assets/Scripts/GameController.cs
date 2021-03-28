using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int jumpIntensity = 6;
    public int health = 5;

    void Update()
    {
        if (health <= 0) {
            //GameOver();
            Debug.Log("Taking damage");
        }
    }

}