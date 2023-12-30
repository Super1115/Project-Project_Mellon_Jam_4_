using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] Health playerHealth;

    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scorekeeper;
    int value;
    

    void Awake(){
        scorekeeper = FindObjectOfType<ScoreKeeper>();
       
    }

    void Start(){
        value  = playerHealth.GetHealth();
        
    }


    void Update()
    {
        if(playerHealth == null){
            value = 0;
        }else{
            value = playerHealth.GetHealth();
        }
        
        
        scoreText.text = scorekeeper.GetScore().ToString("000000000");
    }
}
