using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClairController : MonoBehaviour
{
    [SerializeField] float vbegin = 4f;
    [SerializeField] float tmax = 0.867f;
    float g = -5f;

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
        //g = (-2 * vbegin) / tmax;
        //acceleration = new Vector3(0, g, 0);

        
    }

    void Update()
    {
        if (myState == State.running)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("het werkt");
                myState = State.jumping;
                velocity = new Vector3(0, vbegin, 0);
                acceleration = new Vector3(0, g, 0);
                t = 0f;
            }

        }

        if (myState == State.jumping)
        {
            t += Time.deltaTime;
            if (t > tmax)
            {
                velocity = Vector3.zero;
                acceleration = Vector3.zero;
                myState = State.running;

            }
        }

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

    }

    
}