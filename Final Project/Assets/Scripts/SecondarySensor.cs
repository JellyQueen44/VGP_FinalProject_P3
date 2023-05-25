using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondarySensor : MonoBehaviour
{
    public GameManager gameManagerSensor;

    public bool canSpawnBall = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerSensor = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("BBall"))
        {
            Destroy(other.gameObject);
            canSpawnBall = true;
            
        }
    }
}
