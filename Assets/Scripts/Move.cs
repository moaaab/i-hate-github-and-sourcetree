using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 movement = new Vector3(0, 0, 3);
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = movement;
    }
}
