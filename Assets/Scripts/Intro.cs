using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(activatePlayer());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator activatePlayer() {
        yield return new WaitForSeconds(4f);
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find("Player").GetComponent<Rigidbody>().isKinematic = false;
    }
}
