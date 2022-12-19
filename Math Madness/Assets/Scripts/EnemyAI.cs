using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    public int priority;
    
    public Vector3 target;
    private float speed;
    private float timeToMove;
    private float framesToMove;

    public Transform[] books;

    // Start is called before the first frame update
    void Start()
    {
        this.agent = base.GetComponent<NavMeshAgent>(); //Get the Nav Mesh Agent
        speed = 25.0f;
        this.agent.speed = speed;
        this.timeToMove = 2.0f;
        this.target = books[Random.Range(0, books.Length)].position;
        this.agent.SetDestination(target); 
    }

    // Update is called once per frame
    void Update()
	{
		if (timeToMove > 0f) 
		{
			timeToMove -= 1f * Time.deltaTime;
		}
		else
		{
			this.Move(); 
		}
    }

   	void FixedUpdate()
	{
		if (framesToMove > 0f) 
		{
			framesToMove -= 1f;
			this.agent.speed = speed;
		}
		else
		{
			this.agent.speed = 0f;
		}

		Vector3 direction = this.player.position - this.transform.position; 
		RaycastHit raycastHit;
		if (Physics.Raycast(this.transform.position, direction, out raycastHit, float.PositiveInfinity) & raycastHit.transform.tag == "Player")
		{
            this.target = this.player.position;
			this.agent.SetDestination(target); 
		    this.priority = 0;
		}
		else
		{
			this.priority = 1;
		}
	}

    private void Move()
    {
        Vector3 diff = (this.transform.position - this.target);
        diff.y = 0;

        if (diff.magnitude <= 0.75f) {  
			this.target = books[Random.Range(0, books.Length)].position;
            this.agent.SetDestination(target); 
            this.priority = 2;
		}
        this.framesToMove = 10f;
		this.timeToMove = 3.0f;
    }

    public void Pinged(Vector3 pingLocation)
    {
        if (this.priority > 0)
        {
            this.target = pingLocation;
            this.agent.SetDestination(target);
			this.priority = 1;
        }
    }
   
}
