using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseBlock : MonoBehaviour
{
    public Transform stopObject;
    public GameObject objTrig;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rb.velocity.z < 0 && transform.position.z < stopObject.position.z)
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objTrig)
        {
            Vector3 newStopPos = stopObject.position;
            newStopPos.z += 9.75f;
            stopObject.position = newStopPos;
            enabled = false;
        }
    }
}
