using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scorekeeper;

    void Awake(){
        scorekeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        scoreText.text = "You scored:\n" + scorekeeper.GetScore();
    }
}
