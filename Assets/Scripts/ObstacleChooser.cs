using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleChooser : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.white;
    private bool dragging = false;
    private bool isDragable = true;
    private float distance;
    [SerializeField] private Rigidbody2D rigidbody2D;

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = mouseOverColor;
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
    }
 
    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
    }
}
