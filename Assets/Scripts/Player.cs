using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(10f,10f);
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    [SerializeField] GameObject charm;
    [SerializeField] Transform gun;
    float gravityScaleAtStart;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    bool isAlive = true;
    bool isClicking = false;
    AudioPlayer audioPlayer;

    void Awake(){
        audioPlayer = FindObjectOfType<AudioPlayer>();
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
         if (!isAlive)
        {
            return;
        }
        isClicking = false;
        Run();
        FlipSprite();
        Die();
    }

     void OnMove(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
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
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void OnFire(InputValue value){
        if (!isAlive)
        {
            return;
        }
        if(value.isPressed){
            audioPlayer.PlayShootingClip();
        }  
        Instantiate(charm, gun.position, transform.rotation);
         //audioPlayer.PlayShootingClip();
        
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed * 0.35f, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);

    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x)*0.25f, 0.25f);
        }

    }

    void Die()
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Hazards"))){
            isAlive = false;
            //myAnimator.SetTrigger("Dying");
            myRigidbody.velocity = deathKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}
