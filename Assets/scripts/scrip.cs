using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrip : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] public float cameraSpeed = 10;
=======
    public float cameraSpeed = 0.1f;
>>>>>>> design_choices
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Automatic movement forward
        gameObject.transform.position += Vector3.forward * Time.deltaTime * cameraSpeed;
    }
}
