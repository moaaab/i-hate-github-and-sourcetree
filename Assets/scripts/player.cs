using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] public float playerGravity = 30;
    [SerializeField] public float playerFVelocity = 0.1f; //forward velocity
    [SerializeField] public bool playerGravityState = true; //true = gravity normal (falls down) - false = gravity flipped (falls up)
    [SerializeField] public float jumpForce = 15;
    public Rigidbody rb;
    //new Vector3
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jump
        /*if (Input.GetKeyDown("space"))
        {
            Debug.Log("space was pressed");
            rb.velocity = new Vector3.up * playerJumpHeight;
            //playerUpVelocity = playerJumpHeight;
            playerGravityState = true;
        }


        //Gravity
        if (playerGravityState == true)
        {
            playerUpVelocity -= playerGravityValue;
        }
        if (playerGravityState == false)
        {
            playerUpVelocity += playerGravityValue;
        }
        gameObject.transform.position += Vector3.down * (-playerUpVelocity);*/

        //jump
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space was pressed");
            rb.velocity = new Vector3(0, jumpForce, 0);
            playerGravityState = true;
        }
        //reverse jump
        if (Input.GetKeyDown("down"))
        {
            Debug.Log("down was pressed");
            rb.velocity = new Vector3(0, -jumpForce, 0);
            playerGravityState = false;
        }
        //Automatic movement forward
        gameObject.transform.position += Vector3.forward * Time.deltaTime * playerFVelocity;
    }

    private void FixedUpdate()
    {
        if (playerGravityState) {
            Physics.gravity = new Vector3(0, -playerGravity, 0);
        }
        
        if (!playerGravityState) {
            Physics.gravity = new Vector3(0, playerGravity, 0);
        }
    }
}
