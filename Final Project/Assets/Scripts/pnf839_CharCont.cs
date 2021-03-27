using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pnf839_CharCont : MonoBehaviour
{
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private GameController gameController;
    public float speed;
    private Vector3 camRotation;
    private Transform cam;
    private Vector3 moveDirection;

    [Range(-45, -15)]
    public int minAngle = -30;
    [Range(30, 80)]
    public int maxAngle = 45;
    [Range(50, 500)]
    public int sensitivity = 200;


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float xDirection = Input.GetAxis("Vertical");
        float zDirection = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(xDirection, 0.0f, -zDirection);
        transform.position += moveDirection;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * gameController.jumpIntensity, ForceMode.Impulse);
            Debug.Log("You are jumping");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
    }

}
