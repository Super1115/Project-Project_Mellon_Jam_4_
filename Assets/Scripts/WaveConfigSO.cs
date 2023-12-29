using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config SO", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
     [SerializeField] List<GameObject> petPrefabs;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenPetSpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;


    public int GetPetCount()
    {
        return petPrefabs.Count;
    }

    public GameObject GetPetPrefab(int index)
    {
        return petPrefabs[index];
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
        
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenPetSpawns - spawnTimeVariance,
        timeBetweenPetSpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
