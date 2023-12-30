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
                Instantiate(currentWave.GetPetPrefab(i),
                    currentWave.GetStartingWayPoint().position + new Vector3(0.1f, 0),
                    Quaternion.Euler(0, 0, 0),
                    transform);
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                //count++;
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }

    }

    
}

