using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsTower : MonoBehaviour
{
   

    [SerializeField]
    private float cameraMoveSpeed;

    public bool moving;


    // Update is called once per frame
    void Update()
    {
        if(moving)
            transform.position += new Vector3 (0f, cameraMoveSpeed * Time.deltaTime, 0f);
    }
}
