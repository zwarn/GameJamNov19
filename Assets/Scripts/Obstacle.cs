using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Color mouseOverColor = Color.yellow;
    private Color originalColor = Color.white;
    private bool dragging = false;
    private bool isDragable = true;
    private float distance;
    [SerializeField] private Rigidbody2D rigidbody2D;

    void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
    }

    void OnMouseEnter()
    {
        if (isDragable)
        {
            GetComponent<Renderer>().material.color = mouseOverColor;
        }
    }
 
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = originalColor;
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
}
