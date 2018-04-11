using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(playerMotor))]
public class playerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float lookSpeed = 3f;
    [SerializeField]
    private float thrusterForce = 1000;

    [Header("joint options")]
    [SerializeField]
    private float jointSpring = 20;
    [SerializeField]
    private float jointMaxForce = 40;

    private playerMotor motor;
    private ConfigurableJoint joint;

    private void Start()
    {
        motor = GetComponent<playerMotor>();
        joint = GetComponent<ConfigurableJoint>();
        setJointSettings(jointSpring);
    }

    private void Update()
    {
        //stuff to move around
        float Xmove = Input.GetAxis("Horizontal");
        float Zmove = Input.GetAxis("Vertical");

        Vector3 moveHorizontal = transform.right * Xmove;
        Vector3 moveVertical = transform.forward * Zmove;

        Vector3 velocity = (moveHorizontal + moveVertical) * speed;

        motor.Move(velocity);


        // turns player around
        float yRotate = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRotate, 0f).normalized * lookSpeed;

        motor.Rotate(rotation);

        //camera rotation
        float xRot = Input.GetAxisRaw("Mouse Y");

        float CameraRotationX = xRot * lookSpeed;

        motor.RotateCamera(CameraRotationX);

        //thruster force
        Vector3 force = Vector3.zero;
        if (Input.GetButton("Jump"))
        {
            force = Vector3.up * thrusterForce;
            setJointSettings(0);
        }
        else
        {
            setJointSettings(jointSpring);
        }
        motor.thruster(force);
    }

    private void setJointSettings(float _jointSpring)
    {
        joint.yDrive = new JointDrive { positionSpring = _jointSpring, maximumForce = jointMaxForce };
    }
}
