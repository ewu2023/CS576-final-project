using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // External Variables
    public bool locked;
    public bool open;

    // Sound
    public AudioClip open_sound;
    public AudioClip close_sound;
    public AudioClip locksound;
    private AudioSource source;

    public GameObject enemy;
    public EnemyAI enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        open = false;

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
            Open();

            if(other.gameObject.name == "PlayerCapsule")
            {
                enemyScript.Pinged(transform.position);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Lock Door (only hallway)
        if (!locked && other.gameObject.name == "PlayerCapsule" && Input.GetKeyDown(KeyCode.E) && transform.parent.name.Contains("hallway door") && other.gameObject.GetComponent<PlayerInventory>().GetKey() != null)
        {
            other.gameObject.GetComponent<PlayerInventory>().Remove(other.gameObject.GetComponent<PlayerInventory>().GetKey());
            source.Stop();
            source.PlayOneShot(locksound);
            locked = true;
            Close();
            // Lock other hallway door
            if (name.Contains("Door L"))
            {
                GameObject otherdoor = transform.parent.Find("Door R").gameObject;
                otherdoor.GetComponent<Door>().Close();
                otherdoor.GetComponent<Door>().locked = true;
            }
            else if (name.Contains("Door R"))
            {
                GameObject otherdoor = transform.parent.Find("Door L").gameObject;
                otherdoor.GetComponent<Door>().Close();
                otherdoor.GetComponent<Door>().locked = true;
            }
            
        }
        // Unlock Door (any locked door)
        else if (locked && other.gameObject.name == "PlayerCapsule" && Input.GetKeyDown(KeyCode.E) && other.gameObject.GetComponent<PlayerInventory>().GetKey() != null)
        {
            other.gameObject.GetComponent<PlayerInventory>().Remove(other.gameObject.GetComponent<PlayerInventory>().GetKey());
            source.Stop();
            source.PlayOneShot(locksound);
            locked = false;
            Open();
            // Unlock other hallway door
            if (name.Contains("Door L"))
            {
                GameObject otherdoor = transform.parent.Find("Door R").gameObject;
                otherdoor.GetComponent<Door>().Open();
                otherdoor.GetComponent<Door>().locked = false;
            }
            else if (name.Contains("Door R"))
            {
                GameObject otherdoor = transform.parent.Find("Door L").gameObject;
                otherdoor.GetComponent<Door>().Open();
                otherdoor.GetComponent<Door>().locked = false;
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
            Close();
        }
    }

    public void Close()
    {
        if (open && name.Contains("Door L"))
        {
            transform.Rotate(0f, 90.0f, 0.0f, Space.World);
            open = false;
        }
        else if (open && name.Contains("Door R"))
        {
            transform.Rotate(0f, -90.0f, 0.0f, Space.World);
            open = false;
        }
    }

    public void Open()
    {
        if (!open && name.Contains("Door L"))
        {
            transform.Rotate(0f, -90.0f, 0.0f, Space.World);
            open = true;
        }
        else if (!open && name.Contains("Door R"))
        {
            transform.Rotate(0f, 90.0f, 0.0f, Space.World);
            open = true;
        }
    }
}
