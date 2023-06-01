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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("BBall") && ballCollisions != 50)
        {
            Destroy(other.gameObject);
            ballCollisions += 1;
            
        }else
        {
            Destroy(other.gameObject);
            ballCollisions += 1;

            gameManagerSSensor.ExampleEventTwo();
        }
    }
}
