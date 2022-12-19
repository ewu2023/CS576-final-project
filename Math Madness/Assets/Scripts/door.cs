using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // GameObjects that can open door

    // Sound
    public AudioClip open_sound;
    public AudioClip close_sound;
    public AudioClip locksound;
    public bool locked;
    private AudioSource source;

    public GameObject enemy;
    public EnemyAI enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy");
        enemyScript = enemy.GetComponent<EnemyAI>();

        source = GetComponent<AudioSource>();
        locked = false;
        GameObject parent = transform.parent.gameObject;
        if (parent.name.Contains("Closet") || parent.name.Contains("Main Office"))
        {
            locked = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Open door on collision
        if (locked && other.gameObject.name == "PlayerCapsule")
        {
            source.Stop();
            source.PlayOneShot(locksound);
        }
        if (!locked && other.gameObject.name == "PlayerCapsule" || other.gameObject == enemy)
        {
            source.Stop();
            source.PlayOneShot(open_sound);

            if (name.Contains("Door L"))
            {
                transform.Rotate(0f, -90.0f, 0.0f, Space.World);
            }
            else if (name.Contains("Door R"))
            {
                transform.Rotate(0f, 90.0f, 0.0f, Space.World);
            }

            if(other.gameObject.name == "PlayerCapsule")
            {
                enemyScript.Pinged(transform.position);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Lock Door (only hallway)
        if (!locked && other.gameObject.name == "PlayerCapsule" && Input.GetKeyDown(KeyCode.E) && transform.parent.name.Contains("hallway door"))
        {
            source.Stop();
            source.PlayOneShot(locksound);
            locked = true;
            if (name.Contains("Door L"))
            {
                transform.Rotate(0f, 90.0f, 0.0f, Space.World);
            }
            else if (name.Contains("Door R"))
            {
                transform.Rotate(0f, -90.0f, 0.0f, Space.World);
            }
        }
        // Unlock Door (any locked door)
        else if (locked && other.gameObject.name == "PlayerCapsule" && Input.GetKeyDown(KeyCode.E))
        {
            source.Stop();
            source.PlayOneShot(locksound);
            locked = false;
            if (name.Contains("Door L"))
            {
                transform.Rotate(0f, -90.0f, 0.0f, Space.World);
            }
            else if (name.Contains("Door R"))
            {
                transform.Rotate(0f, 90.0f, 0.0f, Space.World);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Open door on collision
        if (!locked && other.gameObject.name == "PlayerCapsule" || other.gameObject == enemy)
        {
            source.Stop();
            source.PlayOneShot(close_sound);

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
