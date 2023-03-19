using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Animator playerAnim, anim;
    [SerializeField]
    private Transform playerBody, body;

    List<Vector3> positions = new List<Vector3>();
    List<Vector3> rotations = new List<Vector3>();
    List<float> states = new List<float>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int fps = (int)(1.0f / Time.smoothDeltaTime);

        positions.Add(player.position);
        states.Add(playerAnim.GetFloat("State"));
        rotations.Add(playerBody.rotation.eulerAngles);
        if (positions.Count > fps) {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        if (states.Count > fps) {
            anim.SetFloat("State", states[0]);
            states.RemoveAt(0);
        }
        if (rotations.Count > fps) {
            body.rotation = Quaternion.Euler(rotations[0]);
            rotations.RemoveAt(0);
        }
        
    }
}
