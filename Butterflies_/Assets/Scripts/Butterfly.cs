using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    public float flySpeed = 3f;
    private Rigidbody rb; 
    public float rotateSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //flying movement
        Fly();

        //roatate movement
        Rotate();
    }
    void Fly()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * flySpeed);
        }
    }

    private void Rotate()
    {
        rb.freezeRotation = true;
        float inputAxis = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.back * inputAxis * rotateSpeed);
        rb.freezeRotation = false;
    }
}
