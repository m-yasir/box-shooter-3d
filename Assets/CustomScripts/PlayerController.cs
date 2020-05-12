using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementMultiplier = 1.0f; // Movement Speed controller
    public float gravityMultiplier = 9.8f; // Player fall Speed controller

    private CharacterController myController;

    private void Start()
    {
        myController = gameObject.GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        // create transform vectors for horizontal and vertical movement
        Vector3 moveZ = Input.GetAxis("Vertical") * Vector3.forward * movementMultiplier * Time.deltaTime;
        Vector3 moveX = Input.GetAxis("Horizontal") * Vector3.right * movementMultiplier * Time.deltaTime;

        // transform object's coordinates
        Vector3 movement = transform.TransformDirection(moveX + moveZ);

        // Apply gravity
        movement.y -= gravityMultiplier;

        myController.Move(movement);
    }
}
