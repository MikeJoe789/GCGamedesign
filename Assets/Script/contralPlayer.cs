using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class contralPlayer : MonoBehaviour
{
    public float moveForce = 3;
    public float maxSpeed = 25;
    private Rigidbody myRigidbody;
    public GameObject child;
    public float rotateSpeed = 1;
    public float rotationSensitivity = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(myRigidbody.velocity.magnitude) < maxSpeed)
        {
            myRigidbody.AddForce((Input.GetAxis("Horizontal") * moveForce), 0, (Input.GetAxis("Vertical") * moveForce));
        }

        //rotation
        Vector3 moveDirection = new Vector3(myRigidbody.velocity.x, 0, myRigidbody.velocity.z);
        if (moveDirection.magnitude > rotationSensitivity)
        {
            child.transform.rotation = Quaternion.Slerp(child.transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * rotateSpeed);
        }
    }
}
