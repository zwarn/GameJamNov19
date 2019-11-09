using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearCollision : MonoBehaviour
{
    public float deadlyVelocity = 10f;
    public AudioSource bearJumpSource;

    // Start is called before the first frame update
    void Start()
    {
        bearJumpSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        bearJumpSource.Play();
        if (other.gameObject.CompareTag("block")
            && other.rigidbody != null
            && other.rigidbody.velocity.magnitude > deadlyVelocity)
        {
            Debug.Log("die because of velocity " + other.rigidbody.velocity.magnitude);
            Destroy(gameObject);
        }
    }
}
