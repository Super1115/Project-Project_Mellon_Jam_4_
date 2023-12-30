using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] float charmSpeed = 20f;

    [SerializeField] float timePetCharmed = 5f;

    [SerializeField] int pointsForPetCollected = 100;
    Player player;
    float xSpeed;

    Coroutine coroutine;
   
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
        if(other.tag == "Pets"){
           coroutine= StartCoroutine(CharmPet());
           FindObjectOfType<ScoreKeeper>().ModifyScore(pointsForPetCollected);
           Destroy(other.gameObject);
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
