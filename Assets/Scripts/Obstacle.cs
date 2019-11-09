using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private bool dragging = false;
    private bool isDragable = true;
    private float distance;
    private Rigidbody2D rigidbody2D;
    private bool hasObjectSpawned = false;

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
        }
    }
 
    void OnMouseUp()
    {
        dragging = false;
        isDragable = false;
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
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!hasObjectSpawned)
        {
            ObstacleSpawner.Instance.SpawnNextRandomBlock();
            hasObjectSpawned = true;
        }
    }
}
