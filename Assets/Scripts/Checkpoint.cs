using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Transform player;
    public CheckPointCounter counter;

    private void OnTriggerEnter(Collider other)
    {
        counter.checkPoint++;
        Destroy(gameObject);
    }
}
