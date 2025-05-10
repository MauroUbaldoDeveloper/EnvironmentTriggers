using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{

    private Rigidbody rdb;

    [Range(0, 30)]
    public float velocity;

    [HideInInspector]
    public KeyCode forwardKey;

    [HideInInspector]
    public KeyCode backKey;

    [HideInInspector]
    public KeyCode rightKey;

    [HideInInspector]
    public KeyCode leftKey;

    private void Start()
    {
        forwardKey = KeyCode.W;
        backKey = KeyCode.S;
        rightKey = KeyCode.D;
        leftKey = KeyCode.A;
        rdb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(forwardKey))
            Forward_Movimentation();

        if (Input.GetKey(backKey))
            Back_Movimentation();

        if (Input.GetKey(rightKey))
            Right_Movimentation();

        if (Input.GetKey(leftKey))
            Left_Movimentation();

        if (Input.GetKeyUp(forwardKey) || Input.GetKeyUp(backKey) || Input.GetKeyUp(rightKey) || Input.GetKeyUp(leftKey))
            Stop_Movimentation();
    }

    public void Forward_Movimentation()
    {
        rdb.linearVelocity = transform.TransformDirection(0, rdb.linearVelocity.y, velocity);
    }

    public void Back_Movimentation()
    {
        rdb.linearVelocity = transform.TransformDirection(0, rdb.linearVelocity.y, -velocity);
    }

    public void Left_Movimentation()
    {
        rdb.linearVelocity = transform.TransformDirection(-velocity, rdb.linearVelocity.y, 0);
    }

    public void Right_Movimentation()
    {
        rdb.linearVelocity = transform.TransformDirection(velocity, rdb.linearVelocity.y, 0);
    }

    public void Stop_Movimentation()
    {
        rdb.linearVelocity = new Vector3(0, rdb.linearVelocity.y, 0);
    }
}