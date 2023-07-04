using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//public Animator anim;

public class player_movement : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float movementSpeed = 6f;
    [SerializeField] Animator anim;
    [SerializeField] private LayerMask groundLayers;

    private bool isFacingRight = true;
    private Rigidbody2D rigidBody;
    private bool doubleJump;
    //private Vector3 velocity = Vector3.zero;

    [Header("Jumping")]
    [SerializeField] private bool canAirControl = true;
    [SerializeField] private float jumpForce = 500f;
    [SerializeField] private Transform groundPosition;
    public bool isGrounded;
    const float groundedRadius = .2f;

    [Header("Events")]
    public UnityEvent OnLandEvent;

    //const float groundedRadius = .2f;

    // Awake is called when the script is loaded
    private void FixedUpdate()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        // find any ground layer colliders closer than the ground position
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundPosition.position, groundedRadius, groundLayers);
        //Debug.Log("Overlapping colliders: " + colliders.Length);
        for (int i = 0; i < colliders.Length; i++)
        {
            // if any of the colliders are not the object iself, it must be the ground
            if (colliders[i].gameObject != gameObject)
            {
                // we are now grounded
                isGrounded = true;

                // if we were not grounded before, but now are, generate the landed event
                if (!wasGrounded)
                {
                    OnLandEvent.Invoke();
                }
            }
        }
    }
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
    }

    /* Start is called before the first frame update
    void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        //bool wasGrounded = isGrounded;
        //isGrounded = false;
        if (isGrounded==true && !(Input.GetButton("Jump") || Input.GetKeyDown(KeyCode.W)))
        {
            doubleJump = false;
        }

        float xMovement = Input.GetAxis("Horizontal") * movementSpeed;
        //float yMovement = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 horizontalMove = xMovement * Time.deltaTime * Vector3.right;
        //Vector3 verticalMove = yMovement * Time.deltaTime * Vector3.up;



        if (xMovement > 0f && !isFacingRight)
        {
            Flip();
            anim.Play("walk");
        }

        else if (xMovement < 0f && isFacingRight)
        {
            Flip();
            anim.Play("walk");
        }

        else if (xMovement == 0f)
        {
            anim.Play("idle");
        }


        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && (isGrounded || doubleJump))
        {
            anim.Play("jump");
            isGrounded = false;
            doubleJump = !doubleJump;
            rigidBody.AddForce(new Vector2(0f, jumpForce));
            //Debug.Log("jump!!!!");
        }

        transform.Translate(horizontalMove);
        //transform.Translate(verticalMove);


    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
