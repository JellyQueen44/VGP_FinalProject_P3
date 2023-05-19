using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private PlayerController playerController;

    private MysteryPerson mysteryScript;
    private GameManager gameManagerScript;
    public GameObject mysPerson;
    public GameObject bouncyBall;
    
    private int index;
    public int startingLine;
    public int endingLine;
    
    public bool dialogueAvailable;
    public bool canSpawnBall;

    // Start is called before the first frame update
    void Start()
    {
        //Getting components and initiates the dialogue start
        textComponent.text = string.Empty;
        StartDialogue();
        dialogueAvailable = true;

        //again, just turn it off, simple solutions
        gameObject.SetActive(false);

        //Getting scripts from other objects, just about the only clean looking code
        playerController = GameObject.Find("Capsule").GetComponent<PlayerController>();
        mysteryScript = GameObject.Find("Sphere").GetComponent<MysteryPerson>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        startingLine = 1;
        endingLine = 4;
    }

    // Update is called once per frame
    void Update()
    {
        //Either goes to thext line or stops everything
        if(Input.GetKeyDown(KeyCode.E) && playerController.mpCollider == true)
        {
            

            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        //Starts the dialogue
        index = startingLine;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //Handles the speed that each letter text appears
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        // Increases the integer for the next line
        if(index < lines.Length - endingLine)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            dialogueAvailable = false;
        
        
            playerController.mpCollider = false;
            mysteryScript.ColliderSwitch();
        }

        if(index > lines.Length - 4)
        {
            gameManagerScript.SpawnBouncyBall();
        }
    }

}
