using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendBullets : MonoBehaviour
{
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private bool isPlayer, addOffset;
    [SerializeField]
    private bool flipDirection = false;

    private float lastShot = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastShot += Time.deltaTime;
        if (lastShot >= cooldown && !isPlayer) {
            lastShot = 0f;
            GameObject bullet = Instantiate(this.bullet);
            if (addOffset) {
                bullet.transform.position = transform.position + transform.forward + transform.up * 3f;
            } else {
                bullet.transform.position = transform.position + transform.forward - transform.up * 3f;
            }

            float offset = 0f;

            if (addOffset) {
                offset = 20f;
            }

            if (flipDirection) {
                bullet.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 180f + offset, 0f));
            } else {
                bullet.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, offset, 0f));
            }
        }
        
    }

    public void UpdatePlayer() {
        if (lastShot >= cooldown) {
            lastShot = 0f;
            GameObject bullet = Instantiate(this.bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
        }
    }
}
