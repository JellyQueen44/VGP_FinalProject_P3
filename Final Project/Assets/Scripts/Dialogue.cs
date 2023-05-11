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
    public GameObject mysPerson;
    
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        //Getting components and initiates the dialogue start
        textComponent.text = string.Empty;
        StartDialogue();
        gameObject.SetActive(true);

        playerController = GameObject.Find("Capsule").GetComponent<PlayerController>();
        mysteryScript = GameObject.Find("Sphere").GetComponent<MysteryPerson>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && playerController.mpCollider == true)
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

    void StartDialogue()
    {
        //Starts the dialogue
        index = 0;
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
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);

            playerController.mpCollider = false;
        }
    }
}
