using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private float horsePower = 0;

    private const float turnSpeed = 45f;  
    private float horizontalInput;
    private float verticalInput;

    private Rigidbody carRb;
    [SerializeField] GameObject centreOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;


    private void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = centreOfMass.transform.position;
    }

    void FixedUpdate()
    {
        //Get Input from player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            //Move the vehicle forward
            carRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);
            //Turning the vehicle
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);


            //Print speed
            speed = Mathf.Round(carRb.velocity.magnitude * 2.237f); // 3.6 for kph
            speedometerText.SetText("Speed: " + speed + "mph");

            //print RPM
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach(WheelCollider wheel  in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if(wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
