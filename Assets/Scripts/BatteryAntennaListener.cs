using UnityEngine;

public class BatteryAntennaListener : MonoBehaviour
{
    public float speed = 2.0f;
    private Antenna_Notifier antenna;
    private Transform playerTransform;
    private Rigidbody rb;
    private bool followPlayer = false;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        antenna = GameObject.FindWithTag("Antenna").GetComponent<Antenna_Notifier>();
        antenna.OnFollowPlayer += FollowPlayer;
        antenna.OnStopFollowingPlayer += StopFollowingPlayer;
    }

    void FixedUpdate()
    {
        if (rb == null) return;
        if (followPlayer)
        {
            Vector3 directionVector = playerTransform.position - transform.position;
            rb.MoveRotation(Quaternion.LookRotation(directionVector));
            rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);            
        }
    }

    void FollowPlayer()
    {
        followPlayer = true;
        GetComponent<Renderer>().material.color = Color.green;
    }

    void StopFollowingPlayer()
    {
        followPlayer = false;
    }

    void OnDisable()
    {
        antenna.OnFollowPlayer -= FollowPlayer;
        antenna.OnStopFollowingPlayer -= StopFollowingPlayer;
    } 
}
