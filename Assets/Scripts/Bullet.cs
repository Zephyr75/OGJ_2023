using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifeTime = 3f;
    private float speed = 20f;
    private float maxLifeTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if (lifeTime >= maxLifeTime) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);    
    }

}
