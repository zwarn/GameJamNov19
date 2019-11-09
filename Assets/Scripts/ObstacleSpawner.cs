using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private static ObstacleSpawner instance;
    private GameObject leftBlock;
    private GameObject rightBlock;
    private GameObject middleBlock;
    [SerializeField] private Transform rightObstacle;
    [SerializeField] private Transform middleObstacle;
    [SerializeField] private Transform leftObstacle;
    [SerializeField] private Transform obstacleHolder;

    public static int toyCount = 0;

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
        leftBlock = ToyChooser.GetInstance().getRandomToy();
        rightBlock = ToyChooser.GetInstance().getRandomToy();
        middleBlock = ToyChooser.GetInstance().getRandomToy();
        rightBlock = Instantiate(rightBlock, rightObstacle.position, Quaternion.identity, obstacleHolder);
        leftBlock = Instantiate(leftBlock, leftObstacle.position, Quaternion.identity, obstacleHolder);
        middleBlock = Instantiate(middleBlock, middleObstacle.position, Quaternion.identity, obstacleHolder);

        ToyChooser.GetInstance().ReinitAvailableIndices();
    }

    public void DestroyOtherBlocks(GameObject pickedBlock)
    {
        if (leftBlock.name != pickedBlock.name)
        {
            Destroy(leftBlock);
        }

        if (rightBlock.name != pickedBlock.name)
        {
            Destroy(rightBlock);
        }

        if (middleBlock.name != pickedBlock.name)
        {
            Destroy(middleBlock);
        }

        toyCount++;
    }

    public static ObstacleSpawner Instance { get => instance; }
}
