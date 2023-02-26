using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;   
        // transform.position because we are in the camera "class" already
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;    //camera position wont be set until that player has moved for that frame
    }
}
