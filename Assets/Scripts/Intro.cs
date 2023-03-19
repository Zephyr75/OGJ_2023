using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Intro : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    AudioSource audioSource; 
    [SerializeField]
    AudioClip mainTheme, alarm;

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
        yield return new WaitForSeconds(1f);
        audioSource.PlayOneShot(alarm);
        yield return new WaitForSeconds(5f);
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find("Player").GetComponent<Rigidbody>().isKinematic = false;
        List<string> texts = new List<string>();
        texts.Add(" You will not escape alive, subject 2077... ");
        texts.Add("I am in your mind, subject 2077...");
        text.text = "";
        int i = 0;
        foreach (string line in texts) {
            if (i == 1) {
                audioSource.PlayOneShot(mainTheme);
            }
            foreach (char letter in line.ToCharArray()) {
                text.text += letter;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(2f);
            text.text = "";
            i++;
        }

    }
}
