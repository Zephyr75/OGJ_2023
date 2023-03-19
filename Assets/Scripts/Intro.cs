using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Intro : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

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
        yield return new WaitForSeconds(0f);//TODO replace by 6f
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find("Player").GetComponent<Rigidbody>().isKinematic = false;
        List<string> texts = new List<string>();
        texts.Add("You will not escape alive, subject 2077...");
        texts.Add("I am in your mind, subject 2077...");
        texts.Add("No need to run, subject 2077...");
        text.text = "";
        foreach (string line in texts) {
            foreach (char letter in line.ToCharArray()) {
                text.text += letter;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(2f);
            text.text = "";
        }
    }
}
