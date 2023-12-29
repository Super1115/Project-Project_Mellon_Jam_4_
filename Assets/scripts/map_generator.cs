using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class map_generator : MonoBehaviour
{
    public Transform SpawnPointObject;
    public GameObject Player;
    public float SpawnPointX = -7;
    public float SpawnPointY = 0;
    public Transform[] allPlatformPrefabs;


    private void Awake() {
        var random = new System.Random();
        transform.position = new Vector3(0,0);
        SpawnObject(x:SpawnPointX,SpawnPointY,SpawnPointObject);
        for (int i = 0; i < 50; i++) 
            {
                SpawnObject(transform.position.x+random.Next(5,8),random.Next(-1,1),allPlatformPrefabs[random.Next(0,allPlatformPrefabs.Length)]);
            }
    }

    private void SpawnObject(float x ,float y,Transform prefabToSpawn){
        transform.position = new Vector2(x,y);
        Instantiate(prefabToSpawn,new Vector2(transform.position.x,transform.position.y),Quaternion.identity);
    }
    void Update(){
        var random = new System.Random();
        if(transform.position.x-Player.transform.position.x<40){
            SpawnObject(transform.position.x+random.Next(5,8),random.Next(-1,1),allPlatformPrefabs[random.Next(0,allPlatformPrefabs.Length)]);
        }
    }
}
