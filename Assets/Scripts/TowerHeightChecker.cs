using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHeightChecker : MonoBehaviour
{



    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private LayerMask blockLayer;

    [SerializeField]
    private SpriteRenderer groundSprite;

    [SerializeField]
    private float numberOfRays, blockVelocityThreshhold, cameraMoveThreshhold;


    [SerializeField]
    private FloatReference towerHeight;


    [SerializeField]
    private CameraFollowsTower cameraFollow;

    private float distanceToGround;




    [SerializeField]
    private GameObject ground;



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }




    private void Update()
    {
        MeasureHeight();
    }


    private void MeasureHeight()
    {

        Vector2 rayOrigin = transform.position + new Vector3(-spriteRenderer.bounds.extents.x, -spriteRenderer.bounds.extents.y, 0.0f);

        float groundHeight = groundSprite.transform.position.y + groundSprite.bounds.extents.y;
        distanceToGround = ground.transform.position.y + spriteRenderer.transform.position.y;


        float shortestRay = distanceToGround;

        Debug.DrawRay(rayOrigin, Vector2.down * distanceToGround, Color.red);


        for (int i = 0; i < numberOfRays; i++)
        {

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, Mathf.Infinity, blockLayer);





            if (hit)
            {
                

                    //checkOtherToo
                    Rigidbody2D blockRigidBoy = hit.transform.gameObject.GetComponent<Rigidbody2D>();

                    if (blockRigidBoy.velocity.x < blockVelocityThreshhold && blockRigidBoy.velocity.y < blockVelocityThreshhold)
                    {
                        if (hit.distance < shortestRay)
                        {
                            shortestRay = hit.distance;
                            CheckToMoveCamera(shortestRay);
                        }

                    }

               
            }

            float nextRaySpacing = (spriteRenderer.bounds.size.x) / (numberOfRays - 1f);
            rayOrigin += Vector2.right * nextRaySpacing;
        }



        towerHeight.value = distanceToGround - shortestRay;
    }

    private void CheckToMoveCamera(float distance)
    {
        if (distance < cameraMoveThreshhold)
            cameraFollow.moving = true;
        else
            cameraFollow.moving = false;

    }
}




