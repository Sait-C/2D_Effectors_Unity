using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] WheelJoint2D backWheel;
    [SerializeField] WheelJoint2D frontWheel;
    [SerializeField] int speed = 1500;
    [SerializeField] float rotationSpeed = 80;

    float movement = 0f;
    float rotation = 0f;

    void Update()
    {
        movement = Input.GetAxisRaw("Vertical") * speed;
        rotation = Input.GetAxisRaw("Horizontal") * rotationSpeed;
    }

    void FixedUpdate()
    {
        if(movement == 0f)
        {
            backWheel.useMotor = false;
            frontWheel.useMotor = false;
        }else
        {
            backWheel.useMotor = true;
            frontWheel.useMotor = true;
            JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = 10000 };
            backWheel.motor = motor;
            frontWheel.motor = motor;
        }

        rb.AddTorque(-rotation * Time.fixedDeltaTime);
    }
}
