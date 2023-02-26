using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalie : MonoBehaviour
{
    // Start is called before the first frame update
    public float min = 2f;
    public float max = 3f;

    void Start()
    {
        min = transform.position.x;
        max = transform.position.x + 4;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 7, max - min) + min, transform.position.y, transform.position.z);
        //only thing that changes here is the x component of the vector, which ping pongs back and forth.
    }
}
