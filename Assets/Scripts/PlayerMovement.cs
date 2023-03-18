using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed, maxSpeed;
    [SerializeField]
    private Transform body;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // if (Input.GetKey(KeyCode.W)) {
        //     transform.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
        // }
        // if (Input.GetKey(KeyCode.S)) {
        //     transform.GetComponent<Rigidbody>().AddForce(transform.forward * -10);
        // }
        // if (Input.GetKey(KeyCode.A)) {
        //     transform.GetComponent<Rigidbody>().AddForce(transform.right * -10);
        // }
        // if (Input.GetKey(KeyCode.D)) {
        //     transform.GetComponent<Rigidbody>().AddForce(transform.right * 10);
        // }


        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // rotate the moveDirection 90 degrees on the y axis
        moveDirection = Quaternion.Euler(0, -90, 0) * moveDirection;

        
        //rotate the player to face the direction of movement
        if (moveDirection != Vector3.zero) {
            body.rotation = Quaternion.Slerp(body.rotation, Quaternion.LookRotation(moveDirection), 0.15F);
        }


        if (transform.GetComponent<Rigidbody>().velocity.magnitude < maxSpeed) {
            transform.GetComponent<Rigidbody>().AddForce(moveDirection * speed);
        }

        
    }

    
}
