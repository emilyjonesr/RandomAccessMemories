using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float speed, jumpForce;

    Movement input;
    Rigidbody2D rb;
    
    bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        input = new Movement();
        input.Controls.Enable();
        input.Controls.Jump.performed += JumpPressed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = input.Controls.MoveSubActions.ReadValue<Vector2>();
        float horizInput = inputVector.x;

        rb.AddForce(horizInput * speed * Time.deltaTime * Vector2.right);
        
    }

    void JumpPressed(InputAction.CallbackContext context)
    {
        if (context.performed && canJump)
        {
            rb.AddForce(jumpForce * Vector2.up);
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            canJump = true;
        }
    }
}



