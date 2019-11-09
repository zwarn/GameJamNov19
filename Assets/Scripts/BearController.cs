using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour
{
    private Rigidbody2D body;

    private Collider2D collider;

    [SerializeField]
    private float numberOfRays;


    [SerializeField]
    private float jumpForce, rayLength, horizontalMoveSpeed;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();



    }




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
       

        float horizontalMovement = Input.GetAxis("Horizontal") * horizontalMoveSpeed * Time.deltaTime;


        transform.position += new Vector3(horizontalMovement, 0,0);

        IsStandingOnGround();

        CheckIfPlayerDies();
    }

    private void CheckIfPlayerDies()
    {
        Rect cameraRect = Camera.main.rect;
        if (transform.position.y < Camera.main.ScreenToWorldPoint(new Vector3(0, cameraRect.yMax)).y)
        {
            GameManager.Instance.PlayerDies();
        }
    }



    private void Jump()
    {

        if (IsStandingOnGround())
            body.AddForce(Vector2.up * jumpForce);



    }




    private bool IsStandingOnGround()
    {

        Bounds boxBounds = collider.bounds;
        Vector2 rayOrigin = new Vector2(boxBounds.center.x - boxBounds.extents.x, boxBounds.center.y - 0.05f - boxBounds.extents.y);

        bool atLeastOneRayHittingGround = false;


        for (int i = 0; i < numberOfRays; i++)
        {


            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength);


            Debug.DrawRay(rayOrigin, Vector2.down * rayLength, Color.red);


            if (hit)
            {
                atLeastOneRayHittingGround = true;
            }

            float nextRaySpacing = (boxBounds.extents.x * 2.0f) / (numberOfRays - 1f);
            rayOrigin += Vector2.right * nextRaySpacing;
        }


        return atLeastOneRayHittingGround;



    }
}
