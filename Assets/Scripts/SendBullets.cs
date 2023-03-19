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
    private bool isPlayer, addOffset, inPlace, flipDirection, flipBulletDirection, isMovingTurret;
    [SerializeField]
    private Material blueLaser;
    [SerializeField]
    AudioSource audioSource; 
    [SerializeField]
    AudioClip gunshot;
    private Transform player;

    private float lastShot = 0f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        lastShot += Time.deltaTime;
        if (!isPlayer) {
            MyUpdate();
        }
        
    }

    public void MyUpdate() {
        if (lastShot >= cooldown && Vector3.Distance(player.position, transform.position) < 15f) {
            lastShot = 0f;
            float rotationOffset = addOffset ? 20f : 0f;
            rotationOffset += flipDirection ? 180f : 0f;
            float bulletDirection = flipBulletDirection ? -1f : 1f;
            Vector3 positionOffset = inPlace ? Vector3.zero : transform.forward + bulletDirection * transform.up * 3f;

            GameObject bullet = Instantiate(this.bullet);
            bullet.transform.position = transform.position + positionOffset;
            bullet.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, rotationOffset, 0f));
            if (isMovingTurret) {
                bullet.transform.rotation = Quaternion.Euler(bullet.transform.rotation.eulerAngles + new Vector3(0f, 90f, 0f));
            }
            if (isPlayer) {
                bullet.GetComponent<Kill>().isPlayer = true;
                bullet.GetComponent<MeshRenderer>().material = blueLaser;
                audioSource.PlayOneShot(gunshot);
            }
        }
    }
}
