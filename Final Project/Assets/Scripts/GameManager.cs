using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController playerController;
    private MysteryPerson mysteryScript;
    private Dialogue dialogueScript;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Capsule").GetComponent<PlayerController>();
        mysteryScript = GameObject.Find("Sphere").GetComponent<MysteryPerson>();
        dialogueScript = GameObject.Find("Dialogue Box").GetComponent<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ExampleEvent()
    {
        if (!dialogueScript.dialogueAvailable)
        {
            dialogueScript.dialogueAvailable = true;
            dialogueScript.startingLine = 4;
            dialogueScript.endingLine = 1;

            dialogueScript.StartDialogue();
            mysteryScript.EnableCollider();
        }
    }
}
