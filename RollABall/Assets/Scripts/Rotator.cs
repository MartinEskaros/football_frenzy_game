using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float speed  = 3f;
    public float amplitude = 0.15f;
    Vector3 startPos;
    float elapsedTime = 0f;
    // Update is called once per frame

    private void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        elapsedTime = elapsedTime + Time.deltaTime * Time.timeScale * speed;
        transform.position = startPos +  Vector3.up * (amplitude*Mathf.Sin(elapsedTime)) ;
        transform.Rotate(new Vector3(15, 30, 45)*Time.deltaTime);   //no matter the fps, you get a smooth effect.
                                                                    //really it does 1/fps so then u multiply by fps then u get 1. 
        
    }
}
