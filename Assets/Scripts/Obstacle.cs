﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private bool dragging = false;
    private bool isDragable = true;
    private float distance;
    private Rigidbody2D rigidbody2D;
    private bool hasObjectSpawned = false;
    private static bool objectSpawnReady = true;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
 
    void OnMouseDown()
    {
        if (isDragable)
        {
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            dragging = true;
            ObstacleSpawner.Instance.DestroyOtherBlocks(gameObject);
        }
    }
 
    void OnMouseUp()
    {
        dragging = false;
        isDragable = false;
        
        StartCoroutine(WaitForSpawnDelay());

        rigidbody2D.gravityScale = 1.0f;
    }
 
    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3(rayPoint.x, transform.position.y);
        }
    }
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (!hasObjectSpawned)
    //     {
    //         hasObjectSpawned = true;
    //         StartCoroutine(WaitForSpawnDelay());
    //     }
    // }

    private IEnumerator WaitForSpawnDelay()
    {
        yield return new WaitForSeconds(1.5f);
        ObstacleSpawner.Instance.SpawnNextRandomBlock();
    }
}