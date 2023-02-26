using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.Rendering;
using System.Runtime.CompilerServices;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI scoreText;
    public GameObject noGoalText;
    public GameObject goalText;
    public GameObject winTextObject;
    private Rigidbody rb;
    GameObject[] allPickups;
    private float movementX;
    private float movementY;
    private int count;
    private int score;
    Vector3 originalPos;
    [SerializeField] private AudioClip pickUp;
    [SerializeField] private AudioClip goal;
    [SerializeField] private AudioClip sewy;    //not implemented yet
    [SerializeField] private AudioClip opponent;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioSource pickupAudio;
    [SerializeField] private AudioClip collectedPickups;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();     //sets rb by getting a reference of the rigidbody component of the playerSphere we added.
        count = 0;
        SetCountText();
        SetScoreText();
        noGoalText.SetActive(false);
        winTextObject.SetActive(false);
        goalText.SetActive(false);
        originalPos = gameObject.transform.position;
        allPickups = GameObject.FindGameObjectsWithTag("PickUp");
            
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();          //
        movementX = movementVector.x;
        movementY = movementVector.y;
        
    }
    void SetCountText()
    {
        countText.text = "Collect 3 Cubes to Score: " + count.ToString();
        if(count > 2)
        {
            winTextObject.SetActive(true);
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); 
    }
    void resetScore()
    {
        score = 0;
    }
    void RemoveCountText()
    {
        winTextObject.SetActive(false);
    }
    private void resetCount()
    {
        count = 0;
        countText.text = "Collect 3 Cubes to Score: " + count.ToString();
    }
    public void SetGoalText()
    {
        if (count > 2)
        {
            goalText.SetActive(true);
        }    
    }
    public void RemoveGoalText()
    {
        goalText.SetActive(false);
    }
    public void SetNoGoalText()
    {
        noGoalText.SetActive(true);
    }
    public void RemoveNoGoalText()
    {
        noGoalText.SetActive(false);
    }
   
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);                 //in 3 planes x and z is the same as x and y in vector 2
        rb.AddForce(movement * speed);            //add force takes in a vector 3 variable

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            pickupAudio.PlayOneShot(pickUp);
            if(count == 3)
            {
                source.PlayOneShot(collectedPickups);
            }
        }
        if (other.gameObject.CompareTag("Goal") && count>2)
        {
            SetGoalText();
            score++;
            source.PlayOneShot(goal);        
            Invoke("restart", 2f);
        }else if (other.gameObject.CompareTag("Goal"))
        {
            Invoke("restart", 2f);
            SetNoGoalText();
        }
        if (other.gameObject.CompareTag("Defender"))
        {
            source.PlayOneShot(opponent);
            resetScore();
            restart();
            
        }
    }
    private void restart()
    {
        this.transform.position = originalPos;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        resetCount();
        RemoveCountText();
        RemoveGoalText();
        SetScoreText();
        RemoveNoGoalText();
            foreach (GameObject pickups in allPickups)
            {
                pickups.SetActive(true);
            }
        
        


    }
   

  

   
    
    
    



}
