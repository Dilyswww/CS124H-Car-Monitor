using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private bool isBreaking;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    public float maxSteeringAngle = 30f;
    public float motorForce = 50f;
    public float brakeForce = 0f;


    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleSteering()
    {
        steerAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;

        brakeForce = isBreaking ? 3000f : 0f;
        frontLeftWheelCollider.brakeTorque = brakeForce;
        frontRightWheelCollider.brakeTorque = brakeForce;
        rearLeftWheelCollider.brakeTorque = brakeForce;
        rearRightWheelCollider.brakeTorque = brakeForce;
    }

    private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheelPos(WheelCollider wheelCollider, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        trans.rotation = rot;
        trans.position = pos;
    }

}

// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class NewBehaviourScript : MonoBehaviour
// {
//     private const string HORIZONTAL = "Horizontal";
//     private const string VERTICAL = "Vertical";

//     private float horizontalInput;
//     private float verticalInput;
//     private float maxSteerAngle;
//     private float currentbreakForce;
//     private bool isBreaking;

//     [SerializeField] private float motorForce;
//     [SerializeField] private float breakForce;
//     [SerializeField] private float maxSteeringAngle;

//     [SerializeField] private WheelCollider frontLeftWheelCollider;
//     [SerializeField] private WheelCollider frontRightWheelCollider;
//     [SerializeField] private WheelCollider rearLeftWheelCollider;
//     [SerializeField] private WheelCollider rearRightWheelCollider;

//     [SerializeField] private Transform frontLeftWheelTransform;
//     [SerializeField] private Transform frontRightWheelTransform;
//     [SerializeField] private Transform rearLeftWheelTransform;
//     [SerializeField] private Transform rearRightWheelTransform;

//     private void FixedUpdate() {
//         GetInput();
//         HandleMotor();
//         HandleSteering();
//         UpdateWheels();
//     }

//     private void GetInput() {
//         horizontalInput = Input.GetAxis(HORIZONTAL);
//         verticalInput = Input.GetAxis(VERTICAL);
//         isBreaking = Input.GetKey(KeyCode.Space);
//     }

//     private void HandleMotor() {
//         frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
//         frontRightWheelCollider.motorTorque = verticalInput * motorForce;
//         currentbreakForce = isBreaking ? breakForce : 0f;
//         if (isBreaking) {

//         }
//     }

//     private void ApplyBreaking() {
//         frontRightWheelCollider.breakTorque = currentbreakForce;
//         frontLeftWheelCollider.breakTorque = currentbreakForce;
//         rearRightWheelCollider.breakTorque = currentbreakForce;
//         rearLeftWheelCollider.breakTorque = currentbreakForce;
//     }

//     private voide HandleSteering() {
//         currentSteerAngle = maxSteerAngle * horizontalInput;
//         frontLeftWheelCollider.steerAngle = currentSteerAngle;
//         frontRightWheelCollider.steerAngle = currentSteerAngle;
//     }

//     private void UpdateWheels() {
//         UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
//         UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
//         UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
//         UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
//     }

//     private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform) {
//         Vector3 pos;
//         Quaternion rot;
//         wheelCollider.GetWorldPose(out pos, out rot);
//         wheelTransform.rotation = rot;
//         wheelTransform.position = pos;
//     }
// }
