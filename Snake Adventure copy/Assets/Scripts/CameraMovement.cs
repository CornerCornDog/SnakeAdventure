using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject snakeHead;
    public Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera.position = new Vector3(snakeHead.transform.position.x, snakeHead.transform.position.y, camera.position.z);
    }
}
