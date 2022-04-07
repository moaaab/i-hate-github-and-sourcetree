using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doortrigger : MonoBehaviour
{
    public Animator animatorDoor;
    
    void Start()
    {
        animatorDoor = transform.parent.gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("tja");
            animatorDoor.SetBool("DoorOpen", true);
        }
        

    }
    private void OnTriggerExit(Collider other)
    {
        animatorDoor.SetBool("DoorOpen", false);
    }
}
