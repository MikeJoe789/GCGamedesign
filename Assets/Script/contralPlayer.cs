using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class contralPlayer : MonoBehaviour
{
    public float moveForce;
    public float maxSpeed;
    private Rigidbody myRigidbody;
    public GameObject child;
    public float rotateSpeed;
    public float rotationSensitivity;
    public Animator playerAnimator;

    public float jumpForce;
    public GroundCheck groundCheck;
    // public GameObject groundCheck;
    public GameObject myParticle;

    // Start is called before the first frame update
    void Start()
    {
        moveForce = 5;
        maxSpeed = 30;
        jumpForce = 100;
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(myRigidbody.velocity.magnitude) < maxSpeed)
        {
            myRigidbody.AddForce((Input.GetAxis("Horizontal") * moveForce), 0, (Input.GetAxis("Vertical") * moveForce));
        }

        //particle start
        if (Mathf.Abs(myRigidbody.velocity.magnitude) > 0)
        {
            myParticle.SetActive(true);
        }
        else if (Mathf.Abs(myRigidbody.velocity.magnitude) == 0)
        {
            myParticle.SetActive(false);
        }

        // particle end
        //rotation
        Vector3 moveDirection = new Vector3(myRigidbody.velocity.x, 0, myRigidbody.velocity.z);
        if (moveDirection.magnitude > rotationSensitivity)
        {
            child.transform.rotation = Quaternion.Slerp(child.transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * rotateSpeed);
        }
        // jump start
        if (Input.GetButtonDown("Jump") && groundCheck.isGround)
        {
            myRigidbody.AddForce(0, jumpForce, 0);
        }
        // jump end




        // plaerAnimator.SetFloat("Speed", moveDirection.mag
        playerAnimator.SetFloat("Speed", moveDirection.magnitude);
        playerAnimator.SetFloat("vertiacalSpeed", myRigidbody.velocity.y);
        playerAnimator.SetBool("isGround", groundCheck.isGround);
    }
}
