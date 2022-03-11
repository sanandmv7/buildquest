using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform centerOfMass;

    public float motorTorque = 1500f;
    public float maxSteer = 20f;

    public float Steer { get; set; }
    public float Throttle { get; set; }
    private Rigidbody _rigidbody;
    private Wheel[] wheels; 

    void Start()
    {
        wheels = GetComponentsInChildren<Wheel>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
    }

    void Update()
    {
        Steer = GameManager.instance.inputController.SteerInput;
        Throttle = GameManager.instance.inputController.ThrottleInput;
        
        foreach( var wheel in wheels ) {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorTorque;
        }
    }
}
