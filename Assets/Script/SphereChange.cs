using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereChange : MonoBehaviour
{
    public float Size;
    public float SizeMultiplier;
    public float JumpForce;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(Size, Size * SizeMultiplier, Size);
        gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce);

        }
    }
}
