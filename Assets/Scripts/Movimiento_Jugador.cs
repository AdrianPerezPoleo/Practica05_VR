using UnityEngine;

public class Movimiento_Jugador : MonoBehaviour
{
    public float speed = 2.0f;
    private Transform cameraTransform;
    private Rigidbody rb;
    private bool isMoving = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraTransform = GetComponentInChildren<Camera>().transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        float cameraAngle = cameraTransform.localEulerAngles.x; 
        if (cameraAngle > 25.0f && cameraAngle <= 90.0f)
        {
            isMoving = true;
        } else
        {
            isMoving = false;
        }
    }

    void FixedUpdate()
    {
        if (isMoving) {
            Vector3 forwardDirection = cameraTransform.forward;
            forwardDirection.y = 0;
            forwardDirection.Normalize();

            Vector3 newPosition = rb.position + (forwardDirection * speed * Time.fixedDeltaTime);
            rb.MovePosition(newPosition);            
        }
    }
}
