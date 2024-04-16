using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Fields
    [Header("Player Stats")]
    [Tooltip("How fast the player moves in units per second.")]
    [SerializeField] float playerSpeed;
    [Tooltip("How much force the player jumps with.")]
    [SerializeField] float jumpForce;

    // Toggles on and off depending on if the player is close enough to a door to interact with it.
    bool isNearDoor = false;

    // References
    // The Rigidbody2D component on the player.
    Rigidbody2D rb;
    // Reference to the current door the player is standing next to (if any).
    GameObject door;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(movement * Time.deltaTime * playerSpeed, 0));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.E) && isNearDoor == true && door != null)
        {
            InteractDoor();
        }
    }

    void InteractDoor()
    {
        door.GetComponent<Door>().ToggleOpenDoor();
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            isNearDoor = true;
            door = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            isNearDoor = false;
            door = null;
        }
    }
}