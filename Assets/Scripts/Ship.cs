using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Ship : MonoBehaviour
{
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
}
