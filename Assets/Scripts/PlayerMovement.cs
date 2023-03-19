using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed, maxSpeed, rollSpeed;
    [SerializeField]
    private Transform body;
    [SerializeField]
    private GameObject shootingPoint, gun;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    TextMeshProUGUI text;

    private bool isRolling = false, isShooting = false, hasGun = false, isDead = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) {
            return;
        }

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        moveDirection = Quaternion.Euler(0, -90, 0) * moveDirection;

        if (moveDirection != Vector3.zero && !isRolling) {
            body.rotation = Quaternion.Slerp(body.rotation, Quaternion.LookRotation(moveDirection), 0.15F);
            anim.SetFloat("State", 1);
        }
        else {
            anim.SetFloat("State", 0);
        }


        if (transform.GetComponent<Rigidbody>().velocity.magnitude < maxSpeed && Time.timeScale != 0f) {
            transform.GetComponent<Rigidbody>().AddForce(moveDirection * speed);
        }

        float fire2 = Input.GetAxis("Fire2");

        // if fire 1 is pressed
        if ((fire2 > 0 || Input.GetButtonDown("Fire3")) && !isRolling && hasGun) {
            anim.SetBool("Shoot", true);
            isShooting = true;  
        }
        else if ((fire2 <= 0 || Input.GetButtonUp("Fire3")) && !isRolling && hasGun) {
            anim.SetBool("Shoot", false);
            isShooting = false;
        }

        if (isShooting) {
            shootingPoint.GetComponent<SendBullets>().MyUpdate();
        }

        // dash if jump is pressed
        if (Input.GetButtonDown("Fire1") && !isRolling && !isShooting) {
            anim.SetTrigger("Roll");
            StartCoroutine(Roll(moveDirection));
        }
        
    }

    IEnumerator Roll(Vector3 direction) {
        isRolling = true;
        float rollTime = 1f;
        float rollTimer = 0f;


        transform.GetComponent<CapsuleCollider>().center = new Vector3(0, .3f, 0);
        transform.GetComponent<CapsuleCollider>().height = .5f;

        while (rollTimer < rollTime) {
            rollTimer += Time.deltaTime;
            transform.GetComponent<Rigidbody>().AddForce(direction * rollSpeed);
            yield return null;
        }
        isRolling = false;

        yield return new WaitForSeconds(.3f);
        
        transform.GetComponent<CapsuleCollider>().center = new Vector3(0, 1.1f, 0);
        transform.GetComponent<CapsuleCollider>().height = 2.2f;
    }

    public void KillPlayer() {
        if (isDead) {
            return;
        }
        anim.SetTrigger("Death");
        StartCoroutine(Death());
        isDead = true;
    }

    public void GetGun() {
        hasGun = true;
        gun.SetActive(true);
    }

    IEnumerator Death() {
        string line = "You had no chance...";
        text.text = "";
        foreach (char letter in line.ToCharArray()) {
            text.text += letter;
            yield return new WaitForSeconds(0.1f);
        }

        Application.LoadLevel(Application.loadedLevel);

    }

    
}
