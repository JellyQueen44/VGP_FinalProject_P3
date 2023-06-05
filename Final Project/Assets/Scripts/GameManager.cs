using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public MysteryPerson mysteryScript;
    public Dialogue dialogueScript;
    public float spawnRange = 5.0f;

    public GameObject[] bouncyBall;
    public GameObject indicator;

    // Start is called before the first frame update
    void Start()
    {
        indicator.SetActive(true);

        playerController = GameObject.Find("Capsule").GetComponent<PlayerController>();
        mysteryScript = GameObject.Find("Sphere").GetComponent<MysteryPerson>();
    }

    public void ExampleEvent()
    {
        //Starts the Lost First Ball dialogue Event
        if (!dialogueScript.dialogueAvailable)
        {
            dialogueScript.dialogueAvailable = true;
            indicator.SetActive(true);

            dialogueScript.startingLine = 11;
            dialogueScript.endingLine = 4;

            dialogueScript.StartDialogue();
            mysteryScript.ColliderSwitch();
        }
    }

    // Starts the 50 Balls (or more) Lost event
    public void ExampleEventTwo()
    {
        if (!dialogueScript.dialogueAvailable)
        {
            dialogueScript.dialogueAvailable = true;
            indicator.SetActive(true);

            dialogueScript.startingLine = 14;
            dialogueScript.endingLine = 1;

            dialogueScript.StartDialogue();
            mysteryScript.ColliderSwitch();
        }
    }

    // Spawns bouncy balls at a given position from an array
    public void SpawnBouncyBall()
    {
        int bouncyIndex = Random.Range(0, bouncyBall.Length);

        Instantiate(bouncyBall[bouncyIndex], GenerateSpawnPosition(), bouncyBall[bouncyIndex].transform.rotation);
    }

    // Gives the bouncy balls a random spawn location 
    public Vector3 GenerateSpawnPosition()
    {
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        float spawnPosX = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);

        return randomPos;
    }

}