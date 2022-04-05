using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    public Transform player;
    public Transform theCamera;
    public Transform canvas;

    Vector3 startPos = new Vector3(2.5f, 2.4f, -1.05f);
    Vector3 cameraStartPos = new Vector3(9.89f, 2.4f, -1.05f);

    public void Reset()
    {
        player.transform.position = startPos;
        theCamera.transform.position = cameraStartPos;
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
