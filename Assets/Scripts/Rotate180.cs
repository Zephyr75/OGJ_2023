using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate180 : MonoBehaviour
{

    [SerializeField]
    private float speed = 100f;
    private float direction = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // print(transform.rotation.z);

        // rotate arounx y axis 180 degrees back and forth
        if (transform.rotation.z > .5f && direction > 0f) {
            direction = -1f;
        } else if (transform.rotation.z < -.5f && direction < 0f) {
            direction = 1f;
        }

        transform.Rotate(Vector3.forward * direction * speed * Time.deltaTime);


        
    }
}
