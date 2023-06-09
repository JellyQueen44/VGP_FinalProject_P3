using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryPerson : MonoBehaviour
{
    private Collider mysteryCollider;
    private PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        mysteryCollider = GetComponent<Collider>();
        playerController = GameObject.Find("Capsule").GetComponent<PlayerController>();
    }

    public void ColliderSwitch()
    {
        //Sometimes the best ways of solvin problems, is just to turn it off and on again
        mysteryCollider.enabled = !mysteryCollider.enabled;
    }

}