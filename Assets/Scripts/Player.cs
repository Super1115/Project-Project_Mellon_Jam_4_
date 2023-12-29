using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    //private float scaleX = 0.25f;
    //private float scaleY = 0.25f;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;

    [SerializeField] GameObject charm;

    [SerializeField] Transform spell;

    [SerializeField] GameObject magician;
    float gravityScaleAtStart;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;

    Vector2 resize;

    void Awake(){
        
    }
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale; 
        
    }

    void Update()
    {
        
        Run();
        FlipSprite();
    }

     void OnMove(InputValue value)
    {

        moveInput = value.Get<Vector2>();

    }

    void OnJump(InputValue value)
    {
        if (!myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Midground")))
        {
            return;
        }
        if (value.isPressed)
        {
            Debug.Log("Jumping");
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void OnFire(InputValue value){
        Instantiate(charm, spell.position, transform.rotation);
    }

    void Run()
    {
        if(moveInput.x > 0){
             transform.localScale = new Vector2(0.25f,0.25f);
        }else if(moveInput.x < 0){
             transform.localScale = new Vector2(0.25f,0.25f);
        }
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
        
       

    }

    void FlipSprite()
    {
        
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        transform.localScale = new Vector2(0.25f,0.25f);
        if (playerHasHorizontalSpeed)
        {
            //transform.localScale = new Vector2(0.25f,0.25f);
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 0.25f);
            
        }

    }
}
