using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifeTime;
    private float speed = 10f;
    private float maxLifeTime = 3f;
    

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.up * speed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if (lifeTime >= maxLifeTime) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        // print("Bullet hit " + other.gameObject.tag);
        if (other.gameObject.tag != "Enemy") {
            Destroy(gameObject);
            
        }
    }

}
