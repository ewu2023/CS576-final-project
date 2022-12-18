using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject player;
    // add public GameObjects for NPCs
    public GameObject enemy;
    public EnemyAI enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy");
        enemyScript = enemy.GetComponent<EnemyAI>();
    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Open door on collision
        if (other.gameObject == player || other.gameObject == enemy)
        {
            if (name.Contains("Door L"))
            {
                transform.Rotate(0f, -90.0f, 0.0f, Space.World);
            }
            else if (name.Contains("Door R"))
            {
                transform.Rotate(0f, 90.0f, 0.0f, Space.World);
            }
        }
        
        if(other.gameObject == player)
        {
            enemyScript.Pinged(transform.position);
        }
    
    }

    void OnTriggerExit(Collider other)
    {
        // Open door on collision
        if (other.gameObject == player || other.gameObject == enemy)
        {
            if (name.Contains("Door L"))
            {
                transform.Rotate(0f, 90.0f, 0.0f, Space.World);
            }
            else if (name.Contains("Door R"))
            {
                transform.Rotate(0f, -90.0f, 0.0f, Space.World);
            }
        }
    }
}
