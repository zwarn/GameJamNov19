using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private static ObstacleSpawner instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SpawnNextRandomBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
        // if (Input.anyKeyDown)
    }

    public void SpawnNextRandomBlock()
    {
        GameObject block = ToyChooser.GetInstance().getRandomToy();
        Instantiate(block, transform.position, Quaternion.identity, transform);
    }

    public static ObstacleSpawner Instance { get => instance; }
}
