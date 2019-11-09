using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Camera Camera;
    public GameObject toFollow;
    void Start()
    {
        
    }

    void Update()
    {
        var position = toFollow.transform.position;
        Camera.transform.position = new Vector3(position.x, position.y, Camera.transform.position.z);
    }
}
