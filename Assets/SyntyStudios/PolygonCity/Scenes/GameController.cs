using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] prefabs;
    public Transform[] targets;

    public static GameController instance;
    //public Transform[] wayPoints;

    public int numOfPedestrians;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        SpawnPedestrians(numOfPedestrians);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPedestrians(int num)
    {
        for (int i = 0; i < num; i++)
        {
            int spawnPoint_num = Random.Range(0, spawnPoints.Length);
            int prefab_num = Random.Range(0, prefabs.Length);

            Instantiate(prefabs[prefab_num], spawnPoints[spawnPoint_num].position, spawnPoints[spawnPoint_num].rotation);
        }
    }
}
