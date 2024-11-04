using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public Vector3 direction = Vector3.zero;
    public Vector3 rotation = Vector3.zero;

    public float ascentPower = 10f;
    public float rotationSpeed = 100f;


    // Start is called before the first frame update
    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(rb.rotation * Vector3.up * direction.z * ascentPower, ForceMode.Acceleration);


        Quaternion deltaRotation = Quaternion.Euler(-rotation.z * rotationSpeed * Time.fixedDeltaTime,
                                                   rotation.y * rotationSpeed * Time.fixedDeltaTime,
                                                   -rotation.x * rotationSpeed * Time.fixedDeltaTime);
    
        rb.MoveRotation(rb.rotation * deltaRotation);


    }



    private void FixedUpdate()
    {
        direction.z = Input.GetAxis("Vertical"); //force
        rotation.y = Input.GetAxis("Horizontal"); //turn right and left from origin
        rotation.z = Input.GetAxis("Mouse X"); // right left slalom
        rotation.x = Input.GetAxis("Mouse Y"); //forward and backMovement
    }

}
