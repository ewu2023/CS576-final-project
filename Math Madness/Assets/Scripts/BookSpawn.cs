using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpawn : MonoBehaviour
{
    public GameObject book;
    public float xradius;
    public float zradius;

    public string question;
    public int answer;

    private QuestionManager qm;
    // Start is called before the first frame update
    void Start()
    {
        GameObject book_to_spawn = Instantiate(book, this.transform) as GameObject;
        float xrel_coord = Random.Range(-xradius, xradius);
        float zrel_coord = Random.Range(-zradius, zradius);
        book_to_spawn.transform.localPosition = new Vector3(xrel_coord, 0.8f, zrel_coord);
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].name == "PlayerCapsule")
            {
                Book book_script = book_to_spawn.GetComponent<Book>();
                book_script.player_transform = players[i].transform;
                book_script.question = question;
                book_script.answer = answer;
            }
        }

        //Inserts the newly created books into tthe list
        qm = GameObject.Find("_GM").GetComponent<QuestionManager>();
        qm.books.Add(book_to_spawn.GetComponent<Book>());


    }

    // Update is called once per frame
    void Update()
    {
    }
}
