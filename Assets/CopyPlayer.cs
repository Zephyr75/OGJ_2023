using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPlayer : MonoBehaviour
{

    [SerializeField]
    private int fraction;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Animator playerAnim, anim;
    [SerializeField]
    private Transform playerBody, body;

    private bool isActive = false;

    List<Vector3> positions = new List<Vector3>();
    List<Vector3> rotations = new List<Vector3>();
    List<float> states = new List<float>();


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Activate());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) {
            return;
        }

        int fps = (int)(1.0f / Time.smoothDeltaTime);
        
        positions.Add(player.position);
        states.Add(playerAnim.GetFloat("State"));
        rotations.Add(playerBody.rotation.eulerAngles);
        if (positions.Count > fps * fraction / 10) {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        if (states.Count > fps * fraction / 10) {
            anim.SetFloat("State", states[0]);
            states.RemoveAt(0);
        }
        if (rotations.Count > fps * fraction / 10) {
            body.rotation = Quaternion.Euler(rotations[0]);
            rotations.RemoveAt(0);
        }
        
    }

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(3.0f);
        isActive = true;
    }
}
