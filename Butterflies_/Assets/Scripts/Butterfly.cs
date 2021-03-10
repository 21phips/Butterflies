using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Butterfly : MonoBehaviour
{
    public float flySpeed = 3f;
    private Rigidbody rb; 
    public float rotateSpeed = 2.0f;
    bool isAlive = true;
    int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            //flying movement
            Fly();

            //roatate movement
            Rotate();
        }
        
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bad")
        {
            //Die
            isAlive = false;
            //Reset
            SceneManager.LoadScene(currentLevel);
        
        }
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
