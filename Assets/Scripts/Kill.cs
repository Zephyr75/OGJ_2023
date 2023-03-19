using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public bool isPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player" && !isPlayer) {
            collision.gameObject.GetComponent<PlayerMovement>().KillPlayer();
        }
        if (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<CanBeKilled>() != null && isPlayer) {
            Destroy(collision.gameObject.transform.parent.parent.gameObject);
        }

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && !isPlayer) {
            other.gameObject.GetComponent<PlayerMovement>().KillPlayer();
        }
        print("Kill hit " + other.gameObject.tag);
        if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<CanBeKilled>() != null && isPlayer) {
            Destroy(other.gameObject.transform.parent.parent.gameObject);
        }
    }
}
