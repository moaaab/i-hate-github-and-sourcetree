using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    public IsDead isDead;
    private void OnCollisionEnter(Collision collision)
    {
         isDead.died = true;
    }
}
