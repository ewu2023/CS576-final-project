using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullyAI : MonoBehaviour
{

    public Vector3[] spawns;
    public float timeToWait;
    public GameObject player;

    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCapsule");
        isActive = false;
        timeToWait = Random.Range(30f, 60f); 
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToWait > 0f) 
		{
			timeToWait -= Time.deltaTime;
		}
		else if (!isActive)
		{   
			this.transform.position = spawns[Random.Range(0, 3)];
            while((this.transform.position - player.transform.position).magnitude < 20.0f )
            {
                this.transform.position = spawns[Random.Range(0, 2)];
            }
            this.GetComponent<MeshRenderer>().enabled = true;
            isActive = true;
		}
    }
}