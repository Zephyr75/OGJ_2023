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
    private bool isPlayer, addOffset, inPlace, flipDirection, flipBulletDirection;

    private float lastShot = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastShot += Time.deltaTime;
        if (!isPlayer) {
            MyUpdate();
        }

        // if (lastShot >= cooldown && !isPlayer) {
        //     lastShot = 0f;
        //     GameObject bullet = Instantiate(this.bullet);
        //     if (addOffset) {
        //         bullet.transform.position = transform.position + transform.forward + transform.up * 3f;
        //     } else {
        //         if (inPlace) {
        //             bullet.transform.position = transform.position;
        //         } else {
        //             bullet.transform.position = transform.position + transform.forward - transform.up * 3f;
        //         }
        //     }

        //     float offset = 0f;

        //     if (addOffset) {
        //         offset = 20f;
        //     }

        //     if (flipDirection) {
        //         bullet.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 180f + offset, 0f));
        //     } else {
        //         bullet.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, offset, 0f));
        //     }
        // }
        
    }

    public void MyUpdate() {
        if (lastShot >= cooldown) {
            lastShot = 0f;
            float rotationOffset = addOffset ? 20f : 0f;
            rotationOffset += flipDirection ? 180f : 0f;
            float bulletDirection = flipBulletDirection ? -1f : 1f;
            Vector3 positionOffset = inPlace ? Vector3.zero : transform.forward + bulletDirection * transform.up * 3f;

            GameObject bullet = Instantiate(this.bullet);
            bullet.transform.position = transform.position + positionOffset;
            bullet.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, rotationOffset, 0f));
        }
    }
}
