using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement Variables
    [SerializeField] private float maxForwardSpeed;
    [SerializeField] private float maxBackwardSpeed;
    [SerializeField] private float maxStrafeSpeed;

    private Rigidbody   playerRigidbody;
    private Vector3     playerVelocity;
    private Vector3     playerMotion;

    // Camera Variables
    [SerializeField] private float maxLookUpAngle;
    [SerializeField] private float maxLookDownAngle;

    private Transform   head;
    private Vector3     headRotation;

    void Start()
    {
        playerRigidbody     = GetComponent<Rigidbody>();
        head                = GetComponentInChildren<Camera>().transform;
        Cursor.lockState    = CursorLockMode.Locked;
    }

    private void Update()
    {
        UpdateRotation();
        UpdateHead();
    }

    private void FixedUpdate()
    {
            UpdateVelocity();
            UpdatePosition();
    }

    private void UpdateRotation()
    {
        float rotation = Input.GetAxis("Mouse X");

        transform.Rotate(0f, rotation, 0f);
    }

    private void UpdateHead()
    {
        headRotation = head.localEulerAngles;

        headRotation.x -= Input.GetAxis("Mouse Y");

        if (headRotation.x > 180f)
            headRotation.x = Mathf.Max(maxLookUpAngle, headRotation.x);
        else
            headRotation.x = Mathf.Min(maxLookDownAngle, headRotation.x);

        head.localEulerAngles = headRotation;
    }

    private void UpdateVelocity()
    {
        float forwardAxis   = Input.GetAxis("Vertical");
        float strafeAxis    = Input.GetAxis("Horizontal");

        if (forwardAxis >= 0f)
            playerVelocity.z = forwardAxis * maxForwardSpeed;
        else
            playerVelocity.z = forwardAxis * maxBackwardSpeed;

        playerVelocity.x = strafeAxis * maxStrafeSpeed;

        if (playerVelocity.magnitude > maxForwardSpeed)
            playerVelocity = playerVelocity.normalized * (forwardAxis > 0 ? maxForwardSpeed : maxBackwardSpeed);
    }

    private void UpdatePosition()
    {
        playerMotion = transform.TransformVector(playerVelocity * Time.fixedDeltaTime);

        playerRigidbody.position += playerMotion;
    }

}
