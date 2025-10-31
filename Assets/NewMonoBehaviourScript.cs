using UnityEngine;
using UnityEngine.InputSystem;

public class ClairController : MonoBehaviour
{
    [SerializeField] float vbegin = 4f;
    [SerializeField] float tmax = 1.667f;
    float g;

    Animator animator;

    enum State { running, jumping };
    State myState = State.running;

    Vector3 velocity = Vector3.zero;
    Vector3 acceleration = Vector3.zero;

    float t = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Bereken g op basis van vbegin en tmax
        g = (-2 * vbegin) / tmax;
        acceleration = new Vector3(0, g, 0);

        // Start in running state
        SetAnimationState(true, false);
    }

    void Update()
    {
        // Gebruik het nieuwe Input System
        if (Keyboard.current.spaceKey.wasPressedThisFrame ||
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            HandleJumpInput();
        }

        HandleJumpState();
    }

    void HandleJumpInput()
    {
        if (myState == State.running)
        {
            myState = State.jumping;
            SetAnimationState(false, true);

            t = 0f;
            velocity = new Vector3(0, vbegin, 0);
        }
    }

    void HandleJumpState()
    {
        if (myState == State.jumping)
        {
            t += Time.deltaTime;
            velocity += acceleration * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;

            if (t >= tmax)
            {
                myState = State.running;
                SetAnimationState(true, false);

                velocity = Vector3.zero;
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
        }
    }

    void SetAnimationState(bool running, bool jumping)
    {
        if (animator != null)
        {
            animator.SetBool("running", running);
            animator.SetBool("jumping", jumping);
        }
    }
}