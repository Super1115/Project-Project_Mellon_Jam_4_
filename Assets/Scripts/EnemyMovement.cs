using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] float moveSpeed = 1f;
    void Start()
    {
      myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       myRigidBody.velocity = new Vector2(moveSpeed, 0f);
    }

   void OnTriggerExit2D(Collider2D other) {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }

   void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Pets"){
        FlipEnemyFacing();
        //Destroy(other.gameObject);
    }
       
    }
    
    

    void FlipEnemyFacing(){
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x))*0.25f, 0.25f);
    
    }
}
