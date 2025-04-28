using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    [SerializeField]
    private Rigidbody2D myBody;

    private Animator anim;

    private SpriteRenderer sr;

    private string WALK_ANIMATION = "Walk";

    private bool isGrounded = true;

    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";



    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerKeyboardMovement();
        AnimatePlayer();
        PlayerJump();
    }

//    private void FixedUpdate()
//    {
//        
//    }

    void PlayerKeyboardMovement()
    {
       movementX = Input.GetAxisRaw("Horizontal");
    
        transform.position += new Vector3(movementX, 0f,0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        if (movementX > 0) // this is for moving to the right
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        } else if (movementX < 0) // this is for moving to the left
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
        

    }
    
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("jumping");
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // this collision parameter will be the 2nd object we are colliding with
    {
        /*
         * This code is basically asking the computer if the game object that has a collider that we landed on, does it have the ground tag?
         * This is the function you use to detect collisions between game objects
         */
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }


        if (collision.gameObject.CompareTag(ENEMY_TAG))
            // Collision 2D collects the data from any 2d collision that occurs within the game.
            // Using this data, we will make it so that it will destroy the player game object once
            //  it comes into contact with an enemy game object.
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
