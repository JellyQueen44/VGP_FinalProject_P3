using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public GameManager gameManagerSensor;

    public bool canSpawnBall = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerSensor = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Triggers initial event when a ball collides
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("BBall"))
        {
            Destroy(other.gameObject);
            
            canSpawnBall = true;
            gameManagerSensor.ExampleEvent();

            Destroy(gameObject);
        }
    }
}