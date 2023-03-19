using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(collision.gameObject);
            collision.gameObject.GetComponent<PlayerMovement>().KillPlayer();
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Destroy(other.gameObject);
            other.gameObject.GetComponent<PlayerMovement>().KillPlayer();
        }
    }
}
