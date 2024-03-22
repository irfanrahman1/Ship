using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using Vector2 = UnityEngine.Vector2;
//using System.Diagnostics;
//using System.Numerics;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private float colliderRadius;

    // Declare a private Rigidbody2D field to store the component reference
    private Rigidbody2D rb2D;

    // Declare and initialize the thrustDirection field
    private Vector2 thrustDirection = new Vector2(1, 0);

        // Define the thrust force as a constant
    private const float ThrustForce = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        // Assign the Rigidbody2D component to the private field
        rb2D = GetComponent<Rigidbody2D>();

        // Retrieve the CircleCollider2D component attached to the ship
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
        if (circleCollider != null)
        {
            // Store the collider's radius
            colliderRadius = circleCollider.radius;
        }
        else
        {
            UnityEngine.Debug.LogError("CircleCollider2D component missing from the ship.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Check if the Thrust input is being pressed.
        if (Input.GetButton("Thrust"))
        {
            // Apply a force in the direction of thrustDirection, scaled by ThrustForce.
            rb2D.AddForce(thrustDirection * ThrustForce, ForceMode2D.Force);
        }
    }


    /// <summary>
    /// Called when the GameObject goes out of the camera's view.
    /// </summary>
    void OnBecameInvisible()
    {
        Vector3 newPosition = transform.position;

        // Horizontal Wrapping
        if (newPosition.x > 0)
        {
            newPosition.x = ScreenUtils.ScreenLeft - colliderRadius;
        }
        else if (newPosition.x < 0)
        {
            newPosition.x = ScreenUtils.ScreenRight + colliderRadius;
        }

        //// Vertical Wrapping (if applicable)
        //if (newPosition.y > 0)
        //{
        //    newPosition.y = ScreenUtils.ScreenBottom - colliderRadius;
        //}
        //else if (newPosition.y < 0)
        //{
        //    newPosition.y = ScreenUtils.ScreenTop + colliderRadius;
        //}

        transform.position = newPosition;
    }

}
