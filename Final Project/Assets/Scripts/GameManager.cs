using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public MysteryPerson mysteryScript;
    public Dialogue dialogueScript;
    public float spawnRange = 5.0f;

    public GameObject bouncyBall;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Capsule").GetComponent<PlayerController>();
        mysteryScript = GameObject.Find("Sphere").GetComponent<MysteryPerson>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExampleEvent()
    {
        if (!dialogueScript.dialogueAvailable)
        {
            dialogueScript.dialogueAvailable = true;

            dialogueScript.startingLine = 4;
            dialogueScript.endingLine = 1;

            dialogueScript.StartDialogue();
            mysteryScript.ColliderSwitch();
        }
    }

    public void SpawnBouncyBall()
    {
        Instantiate(bouncyBall, GenerateSpawnPosition(), bouncyBall.transform.rotation);
    }

    public Vector3 GenerateSpawnPosition()
    {
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        float spawnPosX = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);

        return randomPos;
    }

}
