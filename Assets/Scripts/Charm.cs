using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] float charmSpeed = 20f;

    [SerializeField] float timePetCharmed = 2f;
    Player player;
    float xSpeed;
   
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        xSpeed = player.transform.localScale.x*charmSpeed;
    }

    void Update()
    {
        myRigidBody.velocity = new Vector2(xSpeed,0f);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Mascots"){
           CharmPet();
        }
        Destroy(gameObject);
    }

     void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);

    }

     IEnumerator CharmPet()
    {
      yield return new WaitForSeconds(timePetCharmed);
    }
    
}
