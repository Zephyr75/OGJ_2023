using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed, maxSpeed, rollSpeed;
    [SerializeField]
    private Transform body;
    [SerializeField]
    private Animator anim;

    private bool isRolling = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        moveDirection = Quaternion.Euler(0, -90, 0) * moveDirection;

        if (moveDirection != Vector3.zero && !isRolling) {
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
        if (Input.GetButtonDown("Fire3")) {
            anim.SetBool("Shoot", true);
        }
        else if (Input.GetButtonUp("Fire3")) {
            anim.SetBool("Shoot", false);
        }

        // dash if jump is pressed
        if (Input.GetButtonDown("Fire1")) {
            anim.SetTrigger("Roll");
            StartCoroutine(Roll(moveDirection));
        }
        
    }

    IEnumerator Roll(Vector3 direction) {
        isRolling = true;
        float rollTime = 1f;
        float rollTimer = 0f;


        transform.GetComponent<CapsuleCollider>().center = new Vector3(0, .5f, 0);
        transform.GetComponent<CapsuleCollider>().height = 1f;    

        while (rollTimer < rollTime) {
            rollTimer += Time.deltaTime;
            transform.GetComponent<Rigidbody>().AddForce(direction * rollSpeed);
            yield return null;
        }

        // yield return new WaitForSeconds(1f);
        
        transform.GetComponent<CapsuleCollider>().center = new Vector3(0, 1.1f, 0);
        transform.GetComponent<CapsuleCollider>().height = 2.2f;
        isRolling = false;
    }

    
}