using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject dialogueBox;
    public bool mpCollider = false;

    public float speed = 5f;
    private Rigidbody playerRb;
    private float zBound = 6.969f;
    private float xBound = 6.969f;

    private MysteryPerson mysteryScript;
    private GameManager gameManager;
    private Sensor sensorScript;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        sensorScript = GameObject.Find("Sensor").GetComponent<Sensor>();
        mysteryScript = GameObject.Find("Sphere").GetComponent<MysteryPerson>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Controls Player movement
        MovePlayer();
        ConstraintMove();

        //Player Activates the Dialogue Box (in a very scuffed way)
        if(Input.GetKeyDown(KeyCode.E) && mpCollider == true)
        {
            dialogueBox.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.B) && sensorScript.canSpawnBall)
        {
            gameManager.SpawnBouncyBall();
        }


    }
    
    // Does what it says on the tin, player movement based on input
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        
    }

    // Prevents you from moving to places you likely aren't supposed to be (In case the walls fail)
    void ConstraintMove()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
            if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
            if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //you are, in fact, making contact with the mystery person
        if(other.CompareTag("MysPerson"))
        {
            mpCollider = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("BBall"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 pushAway = collision.gameObject.transform.position - transform.position;

            ballRb.AddForce(pushAway * 10, ForceMode.Impulse);

        }

    }

}