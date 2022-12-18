using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        this.agent = base.GetComponent<NavMeshAgent>(); //Get the Nav Mesh Agent
        this.agent.speed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        this.agent.SetDestination(this.player.position);
    }
}
