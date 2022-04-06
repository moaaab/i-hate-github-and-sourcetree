using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    public Lives lives;
    public IsDead died;

    private void OnCollisionEnter(Collision collision)
    {
        lives.LoseLife();
        died.died = true;
    }
}
