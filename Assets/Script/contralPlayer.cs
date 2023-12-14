using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class contralPlayer : MonoBehaviour
{
    public float frocePower;
    // public float maxPower;
    private Rigidbody myRigidbody;
    private float horizontalMove;
    private float verticalMove;
    public float rotationSpeed;
    private float verticalRotaion;

    // Start is called before the first frame update
    void Start()
    {
        frocePower=2;
        rotationSpeed = 3;
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Mathf.Abs(Input.GetAxis("Horizontal") * frocePower);
        verticalMove = Mathf.Abs(Input.GetAxis("Vertical") * frocePower);
        if( horizontalMove > 0 || verticalMove>0){
            myRigidbody.AddForce(horizontalMove,0,verticalMove);
        }
        if( verticalRotaion > 0){            
            gameObject.transform.Rotate(0f, 90.0f, 90.0f, Space.World);;
        }
    }
}
