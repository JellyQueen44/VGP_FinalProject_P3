using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject dialogueBox;
    public bool mpCollider = false;

    public float speed = 5f;
    private Rigidbody playerRb;

    private MysteryPerson mysteryScript;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        mysteryScript = GameObject.Find("Sphere").GetComponent<MysteryPerson>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if(Input.GetKeyDown(KeyCode.E) && mpCollider == true)
        {
            dialogueBox.SetActive(true);
        }
    }
    
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MysPerson"))
        {
            mpCollider = true;
        }
    }
}
