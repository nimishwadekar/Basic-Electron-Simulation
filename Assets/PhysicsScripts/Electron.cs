using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron : MonoBehaviour
{
    const float MASS = 9.1e-31f;
    const float CHARGE = 1.6f;

    public float length, potentialDifference, constant;

    Rigidbody rb;
    Vector3 force, initPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        force = Vector3.zero;
        initPos = transform.position;
        initPos.x = -10;
    }

    private void Update()
    {
        force.x = constant * potentialDifference / length * CHARGE;
        rb.AddForce(force);
        if (transform.position.x >= 10) transform.position = initPos;
    }
}
