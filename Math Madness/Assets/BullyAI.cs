using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullyAI : MonoBehaviour
{

    public Vector3[] spawns;
    public float timeToWait;
    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
        timeToWait = Random.Range(30f, 60f); 
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToWait > 0f) 
		{
			timeToWait -= 1f;
		}
		else
		{
			this.transform.position = spawns[Random.Range];
		}

    }
}
