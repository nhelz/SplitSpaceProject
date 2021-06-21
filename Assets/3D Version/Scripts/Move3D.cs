using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3D : MonoBehaviour
{
    [Header("Movement Settings")]
    //Speed is how quickly the player moves, movementSmoothing is a value passed into the smoothDamp method to calculate how to spread it out over time. I'd keep it at 0.05f, it's a good value.
    public float speed;
    public float movementSmoothing = 0.05f;
    public float maxJumpCooldown;
    //The player's current direction is stored as a Vector2 and is constantly updated with the Horizontal and Vertical axes
    private Vector3 direction { get; set; }
    //Reference to gameObj's rigidbody to set its velocity for movement
    private Rigidbody rb;
    //m_velocity is the "current velocity" param passed into Vector2.SmoothDamp. This is set at 0 because the player's velocity should start at 0--then, each time we set the velocity with SmoothDamp, it updates m_velocity.
    private Vector3 m_velocity = Vector3.zero;
    float jumpCooldown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        if (jumpCooldown > 0f)
        {
            jumpCooldown -= Time.deltaTime;
            if (jumpCooldown < 0f)
            {
                jumpCooldown = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb.velocity.y == 0f)
            {
                jumpCooldown = maxJumpCooldown;
                rb.AddForce(new Vector3(0f, 5f, 0f), ForceMode.Impulse);
            }
        }
        //Debug.Log(direction);
    }

    private void FixedUpdate()
    {
        //Target velocity is calculated by taking the speed, time (to adjust for differing framerates), and direction into account
        Vector3 targetVelocity = new Vector3(speed * 10 * direction.x * Time.fixedDeltaTime, rb.velocity.y, speed * 10 * direction.z * Time.fixedDeltaTime);
        //Set the velocity using the SmoothDamp function to ensure a smooth movement experience
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_velocity, movementSmoothing);
    }
}
