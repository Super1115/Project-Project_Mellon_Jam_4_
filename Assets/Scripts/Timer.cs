using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteTheLevel = 60f;
    public float fillFraction;
    float timerValue = 30f;
    LevelManager levelManager;

    void Awake(){
        levelManager = FindObjectOfType<LevelManager>();
    }
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer(){
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
       
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteTheLevel;
            }
            else
            {
                levelManager.LoadGameOver();
            }

        }    

}
