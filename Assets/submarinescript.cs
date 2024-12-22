using UnityEngine;
using UnityEngine.InputSystem;

public class SubmarineScript : MonoBehaviour
{
    private AudioSource collisionsound; // For collision sound
    public Rigidbody2D myrigidbody;
    public float strength;
    public logicscript logic;
    public bool living = true;

    private Touchscreen touchscreen;
    private Mouse mouse;

    void Start()
    {
        // Adjust properties based on the platform
        #if UNITY_ANDROID
            transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
            myrigidbody.gravityScale = 0.5f;
            strength = 2.5f;
        #elif UNITY_STANDALONE_WIN
            transform.localScale = new Vector3(0.03973735f, 0.03973735f, 0.03973735f);
            myrigidbody.gravityScale = 1f;
            strength = 3.5f;
        #endif

        // Fetching components
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicscript>();
        collisionsound = GetComponent<AudioSource>();

        // Ensuring collision sound doesn't play at the start
        if (collisionsound.isPlaying)
        {
            collisionsound.Stop();
        }

        // Initialize Input System components
        touchscreen = Touchscreen.current;
        mouse = Mouse.current;
    }

    void Update()
    {
        // Handling touch or mouse input
        if (living)
        {
            // If using touch input
            if (touchscreen != null && touchscreen.primaryTouch.press.isPressed)
            {
                // Apply upward force when touch starts
                myrigidbody.linearVelocity = Vector2.up * strength;
            }
            // If using mouse click
            else if (mouse != null && mouse.leftButton.isPressed)
            {
                // Apply upward force when mouse is clicked
                myrigidbody.linearVelocity = Vector2.up * strength;
            }
        }

        // Check if the submarine has left the screen bounds
        if (living && !IsSubmarineInBounds())
        {
            // Trigger game over if the submarine is out of bounds
            logic.gameover();
            living = false;
        }
    }

    private bool IsSubmarineInBounds()
    {
        // Get the camera's bounds
        Camera mainCamera = Camera.main;
        Vector3 submarinePos = transform.position;

        // Convert the submarine position to screen space
        Vector3 screenPos = mainCamera.WorldToViewportPoint(submarinePos);

        // Check if the submarine is within the screen bounds (between 0 and 1)
        return screenPos.x >= 0 && screenPos.x <= 1 && screenPos.y >= 0 && screenPos.y <= 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Triggering game over logic
        logic.gameover();
        living = false;

        // Playing collision sound if not already playing
        if (collisionsound != null && !collisionsound.isPlaying)
        {
            collisionsound.Play();
        }
    }
}
