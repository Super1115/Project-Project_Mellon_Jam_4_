using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;
    WaveConfigSO currentWave;
    void Start()
    {
        StartCoroutine(SpawnPetWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnPetWaves()
    {
        
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetPetCount(); i++)
                {
                    Vector2 position = currentWave.GetPetPrefab(i).transform.position + new Vector3(-1f,0.5f,0);
                    Instantiate(currentWave.GetPetPrefab(i),
                        position,
                        Quaternion.Euler(0,0,0),
                        transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
    }
}
