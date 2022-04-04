using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    public Lives lives;
    private void OnCollisionEnter(Collision collision)
    {
        lives.LoseLife();
        Destroy(gameObject);
    }
}
