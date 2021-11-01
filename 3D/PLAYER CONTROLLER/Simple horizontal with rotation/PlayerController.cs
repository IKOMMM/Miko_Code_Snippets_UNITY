using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRidgibody;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerTurnSpeed = 360;
    private Vector3 playerInput;   

    private void Update()
    {
        GatherInput();
        Look();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void GatherInput()
    {
        playerInput = new Vector3(Input.GetAxisRaw("Horizontal") , 0, Input.GetAxisRaw("Vertical"));
    }

    void Look()
    {
        if(playerInput != Vector3.zero)
        {
            var relative = (transform.position + playerInput) - transform.position;
            var rotation = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, playerTurnSpeed * Time.deltaTime);
        }
        
    }

    void Move()
    {
        playerRidgibody.MovePosition(transform.position + (transform.forward * playerInput.magnitude) * playerSpeed * Time.deltaTime);
    }
}
