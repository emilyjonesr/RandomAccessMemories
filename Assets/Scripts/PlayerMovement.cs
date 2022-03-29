using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public bool facingRight;
    public float speed, jumpForce;
    public Animator animator;

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
        animator.SetFloat("Speed", Mathf.Abs(horizInput));
        rb.AddForce(horizInput * speed * Time.deltaTime * Vector2.right);
        properFlip();
        
    }

    void properFlip()
    {
        float horizInput_flip = input.Controls.MoveSubActions.ReadValue<Vector2>().x;
        if((horizInput_flip< 0 && facingRight) || (horizInput_flip > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }


    void JumpPressed(InputAction.CallbackContext context)
    {
        if (context.performed && canJump)
        {
            animator.SetBool("isJumping", true);
            rb.AddForce(jumpForce * Vector2.up);
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            animator.SetBool("isJumping",false);
            canJump = true;
        }
    }


}



