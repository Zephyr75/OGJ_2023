using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed, maxSpeed;
    [SerializeField]
    private Transform body;
    [SerializeField]
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        moveDirection = Quaternion.Euler(0, -90, 0) * moveDirection;

        if (moveDirection != Vector3.zero) {
            body.rotation = Quaternion.Slerp(body.rotation, Quaternion.LookRotation(moveDirection), 0.15F);
            anim.SetFloat("State", 1);
        }
        else {
            anim.SetFloat("State", 0);
        }


        if (transform.GetComponent<Rigidbody>().velocity.magnitude < maxSpeed) {
            transform.GetComponent<Rigidbody>().AddForce(moveDirection * speed);
        }

        // if fire 1 is pressed
        if (Input.GetButtonDown("Fire1")) {
            anim.SetTrigger("Slash");
        }
        
    }

    
}
