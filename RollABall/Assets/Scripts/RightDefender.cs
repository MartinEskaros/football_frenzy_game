using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDefender : MonoBehaviour
{
    private float speed = 1f;
    public float amplitude = 9f;
    Vector3 startPos;
    float elapsedTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = elapsedTime + Time.deltaTime * Time.timeScale * speed;
        transform.position = startPos + Vector3.left * (amplitude * Mathf.Sin(elapsedTime));
    }
}
