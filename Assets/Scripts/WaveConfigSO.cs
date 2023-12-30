using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config SO", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> petPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenPetSpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

     public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }


    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }

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
