using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondarySensor : MonoBehaviour
{
    public float ballCollisions;

    public GameManager gameManagerSSensor;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerSSensor = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        // keeps track of balls collided with
        if(other.gameObject.CompareTag("BBall") && ballCollisions != 50)
        {
            Destroy(other.gameObject);
            ballCollisions += 1;
            
        }else
        {
            // upon reaching 50 balls, makes example event available
            Destroy(other.gameObject);
            ballCollisions += 1;

            gameManagerSSensor.ExampleEventTwo();
        }
    }
}