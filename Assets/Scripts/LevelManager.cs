using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    AudioPlayer audioPlayer;
    ScoreKeeper scorekeeper;
    [SerializeField] AudioClip clip;
    [SerializeField] float volume = 1f;

    void Awake()
    {
        scorekeeper = FindObjectOfType<ScoreKeeper>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    public void LoadGame()
    {
        if(scorekeeper != null){
            scorekeeper.ResetScore();
        }else{
            scorekeeper = FindObjectOfType<ScoreKeeper>();
            scorekeeper.ResetScore();
        }
        audioPlayer.PlayNextSong(clip, volume);
        SceneManager.LoadScene("scene_InGame");
        
    }

    public void LoadMainMenu()
    {
        audioPlayer.PlayNextSong(clip, volume);
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGameOver()
    {
       audioPlayer.PlayNextSong(clip, volume);
       SceneManager.LoadScene("GameOver");
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
