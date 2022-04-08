using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelStarter : MonoBehaviour
{
    public LevelLoader levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            levelLoader.StartGame();
        }
    }
}
