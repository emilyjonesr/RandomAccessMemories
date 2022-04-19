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

  //Falling variables to track whether or not the player is falling  
    public bool fallingBool;
    private float fallingFloat = -1.0f;
    public bool jumping;
 //Collision variables to see if the player is touching the ground and can only jump again if he is
    private bool touchingGround;
    public Transform checkIfGround;
    public float checkIfGroundRadius;
    public LayerMask layerGround; 

    public float fallMult = 2.5f;
    public float lowMult = 2f;
//Save Point Variables
    public Vector3 savePoint;
    public Vector3 originalPosition;
    public Manager levelManager;
//Music 
    [SerializeField] private AudioSource jumpingSound;

    // Start is called before the first frame update
    void Start()
    {
        input = InputManager.inputActions;
        input.Controls.Enable();
        input.Controls.Jump.performed += JumpPressed;
        rb = GetComponent<Rigidbody2D>();
        savePoint = transform.position;
        originalPosition = transform.position;
        levelManager = FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks to see if the player's feet are touching the ground by making a circle over the player's feet
        touchingGround = Physics2D.OverlapCircle(checkIfGround.position, checkIfGroundRadius, layerGround);

        Vector2 inputVector = input.Controls.MoveSubActions.ReadValue<Vector2>();
        float horizInput = inputVector.x;
        animator.SetFloat("Speed", Mathf.Abs(horizInput));
        rb.AddForce(horizInput * speed * Time.deltaTime * Vector2.right);
        properFlip();
       
        if(rb.velocity.y < fallingFloat)
        {
            fallingBool = true;
        }
        else
        {
            fallingBool = false;
        }

        if (fallingBool)
        {
            FallingPerformed();
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Physics2D.gravity.y * (fallMult - 1) * Time.deltaTime * Vector2.up;
        }
        
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
        
        if (context.performed && touchingGround)
        {
            jumpingSound.Play();
            animator.SetBool("isJumping", true);
            rb.AddForce(jumpForce * Vector2.up);
        }
        
    }


    void FallingPerformed()
    {
        animator.SetBool("isJumping" , false);
        animator.SetBool("isFalling" , true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallBorder")
        {
            levelManager.Respawn();
        }
        if (other.tag == "SavePoint")
        {
            savePoint = other.transform.position;
        }
    }

    public IEnumerator KnockBack(float knockDuration, float knockPower, Vector3 knockDirection)
    {
        float timer = 0;
        rb.velocity = new Vector2(rb.velocity.x, 0);

        while (knockDuration > timer)
        {
            timer += Time.deltaTime;
            rb.AddForce(new Vector3(knockDirection.x * (Random.Range(-10.0f, 10.0f)), knockDirection.y + knockPower, transform.position.z));
        }

        yield return 0;
    }
}



