using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab; 
    public int numberOfPlatforms = 10; 
    public float platformWidth = 3.0f; 
    public float spawnRangeX = 6.0f; 

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            
            float spawnX = Random.Range(-spawnRangeX, spawnRangeX);

            
            GameObject platform = Instantiate(platformPrefab, new Vector3(spawnX, i * platformWidth, 0), Quaternion.identity);

            
            platform.transform.localScale = new Vector3(platformWidth, 1, 1);
        }
    }
}
