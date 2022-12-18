using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpawn : MonoBehaviour
{
    public GameObject book;
    public int xradius;
    public int zradius;
    // Start is called before the first frame update
    void Start()
    {
        GameObject book_to_spawn = Instantiate(book, this.transform) as GameObject;
        int xrel_coord = Random.Range(-xradius, xradius);
        int zrel_coord = Random.Range(-zradius, zradius);
        book_to_spawn.transform.localPosition = new Vector3(xrel_coord, 1.1f, zrel_coord);
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].name == "PlayerCapsule")
            {
                book_to_spawn.GetComponent<Book>().player_transform = players[i].transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
