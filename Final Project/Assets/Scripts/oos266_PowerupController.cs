using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oos266_PowerupController : MonoBehaviour
{
    [SerializeField] private oos266_GameController controller;

    private void Awake()
    {
        if (!controller)
        {
            controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<oos266_GameController>();
        }
        //destroy timer
        //StartCoroutine("CountDown");
    }

    private void Update()
    {
        //make powerups spin
        transform.Rotate(0, 70 * Time.deltaTime, 0);

        //disable hearts if full health
        if (gameObject.tag == "powerHealth" && controller.health >= 5)
        {
            gameObject.GetComponent<MeshCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
    }
}
