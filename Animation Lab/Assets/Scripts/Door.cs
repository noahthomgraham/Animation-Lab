using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Fields
    [SerializeField] Animator animator;
    // References


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ToggleOpenDoor()
    {
        Debug.Log("Toggling door open/closed!");
        // TODO: This is where the door will play its open and close animation.
        animator.SetTrigger("Interact");
    }
}