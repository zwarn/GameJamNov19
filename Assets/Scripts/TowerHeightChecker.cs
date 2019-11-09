using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHeightChecker : MonoBehaviour
{



    private Collider2D collider;

    [SerializeField]
    private float numberOfRays, blockVelocityThreshhold, towerHeight;



    private float distanceToGround;




    [SerializeField]
    private GameObject ground;


    //[SerializeField]
    //private float ;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        distanceToGround = collider.transform.position.y - ground.transform.position.y;
    }




    private void Update()
    {
        MeasureHeight();
    }


    private void MeasureHeight()
    {

        Bounds boxBounds = collider.bounds;
        Vector2 rayOrigin = new Vector2(boxBounds.center.x - boxBounds.extents.x, boxBounds.center.y - (boxBounds.extents.y+ 0.1f));
        

        float shortestRay = distanceToGround;



        for (int i = 0; i < numberOfRays; i++)
        {

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, Mathf.Infinity);


            Debug.DrawRay(rayOrigin, Vector2.down * distanceToGround, Color.red);



            if (hit)
            {
                if (hit.transform.tag == "block")
                {
                    
                    //checkOtherToo
                    Rigidbody2D blockRigidBoy = hit.transform.gameObject.GetComponent<Rigidbody2D>();

                    if (blockRigidBoy.velocity.x < blockVelocityThreshhold && blockRigidBoy.velocity.y < blockVelocityThreshhold)
                    {                       
                        if (hit.distance < shortestRay)
                            shortestRay = hit.distance;

                    }

                }
            }

            float nextRaySpacing = (boxBounds.extents.x * 2.0f) / (numberOfRays - 1f);
            rayOrigin += Vector2.right * nextRaySpacing;
        }



        towerHeight = distanceToGround - shortestRay;







    }





}




