using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.AI.NavMeshAgent agent;
    [SerializeField]
    private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < 20f) {
            agent.SetDestination(player.position);
        }
    }
}
