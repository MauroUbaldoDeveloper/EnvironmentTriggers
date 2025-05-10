using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamInput : MonoBehaviour
{

    private float headangleY;
    private float headangleX;
    private float capsuleAngle;

    public GameObject camObject;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        CamMovementX();
        CamMovementY();

        capsuleAngle = headangleY * 2;
        transform.localRotation = Quaternion.Euler(0, capsuleAngle, 0);
        camObject.transform.localRotation = Quaternion.Euler(headangleX, headangleY / 32, 0);
    }

    public void CamMovementX()
    {
        headangleY += Input.GetAxis("Mouse X") * 5;
    }

    public void CamMovementY()
    {
        headangleX -= Input.GetAxis("Mouse Y") * 5;
    }

}