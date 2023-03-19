using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendBullets : MonoBehaviour
{
    [SerializeField]
    private float cooldown = 0.5f;
    [SerializeField]
    private GameObject bullet;

    private float lastShot = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastShot += Time.deltaTime;
        if (lastShot >= cooldown) {
            lastShot = 0f;
            GameObject bullet = Instantiate(this.bullet);
            bullet.transform.position = transform.position + transform.forward;
            bullet.transform.rotation = transform.rotation;

        }
        
    }
}
