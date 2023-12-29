using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;
    ScoreKeeper scorekeeper;

    void Awake()
    {
        scorekeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGame()
    {
        if(scorekeeper != null){
            scorekeeper.ResetScore();
        }else{
            scorekeeper = FindObjectOfType<ScoreKeeper>();
            scorekeeper.ResetScore();
        }
        SceneManager.LoadScene("Game");
        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
