using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] public float playerGravity = 30;
    [SerializeField] public float playerFVelocity = 0.1f; //forward velocity
    [SerializeField] public bool playerGravityState = true; //true = gravity normal (falls down) - false = gravity flipped (falls up)
    [SerializeField] public float jumpForce = 15;
    public AudioSource audioJump;
    public Rigidbody rb;
    //terminal velocity fix?
    [SerializeField] float maxAcceleration = 30;
    [SerializeField] float terminalVelocity = 15;
    float idealDrag = 30 / 15;
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
            if (playerGravityState == true)
            {
                rb.velocity = new Vector3(0, jumpForce, 0);
            }
            if (playerGravityState == false)
            {
                rb.velocity = new Vector3(0, -jumpForce, 0);
            }

            GetComponent<Rigidbody>().AddTorque(transform.up * 0.1f);
            GetComponent<Rigidbody>().AddTorque(transform.right * 0.4f);
            GetComponent<Rigidbody>().AddTorque(transform.forward * 0.1f);
        }
        //reverse gravity jump
        if (Input.GetKeyDown("down"))
        {
            Debug.Log("down was pressed");
            //rb.velocity = new Vector3(0, -jumpForce, 0);
            if (playerGravityState == true)
            {
                rb.velocity = new Vector3(0, -jumpForce, 0);
                playerGravityState = false;
            }
            else if (playerGravityState == false)
            {
                rb.velocity = new Vector3(0, jumpForce, 0);
                playerGravityState = true;
            }
        }
        rb.drag = idealDrag / (idealDrag * Time.fixedDeltaTime + 1);

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
