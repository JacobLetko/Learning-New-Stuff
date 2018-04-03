using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class playerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 playerRotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;
    private Vector3 thrusterForce = Vector3.zero;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 vec)
    {
        velocity = vec;
    }

    private void FixedUpdate()
    {
        performMovement();
        performRotation();
    }

    void performMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
        if(thrusterForce != Vector3.zero)
        {
            rb.AddForce(thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }

    public void Rotate(Vector3 rote)
    {
        playerRotation = rote;
    }

    void performRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(playerRotation));
        if(cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }

    public void RotateCamera(Vector3 rotate)
    {
        cameraRotation = rotate;
    }

    public void thruster(Vector3 force)
    {
        thrusterForce = force;
    }
}
