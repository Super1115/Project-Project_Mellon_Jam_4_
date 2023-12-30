using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0f, 1f)] float shootingVolume = 1f;

    [SerializeField] AudioClip musicClip;
    [SerializeField][Range(0f, 1f)] float musicVolume = 1f;
    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
      int instanceCount = FindObjectsOfType(GetType()).Length;
      if(instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            //instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayNextSong(AudioClip clip, float volume){
        PlayClip(clip,volume);
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayMusicClip()
    {
        PlayClip(musicClip, musicVolume);
    }

    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
