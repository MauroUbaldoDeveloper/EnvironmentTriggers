using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTrigger : MonoBehaviour
{

    private bool playTimer;
    private float timer;

    public Rigidbody rigidbodyObjectThatWillDrop;
    public Transform transformObjectThatWillDrop;
    public Transform beginPositionOfObject;

    public float maxTimer;

    private void Update()
    {
        if (playTimer)
        {
            timer += Time.deltaTime;

            if (timer >= maxTimer)
            {
                timer = 0;
                playTimer = false;
                ResetPosition();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rigidbodyObjectThatWillDrop.useGravity = true;
            timer = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            playTimer = true;
    }

    void ResetPosition()
    {
        rigidbodyObjectThatWillDrop.useGravity = false;
        transformObjectThatWillDrop.position = beginPositionOfObject.position;
    }

}