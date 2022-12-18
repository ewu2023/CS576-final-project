using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    public int numBooks;
    private bool[] location_has_book;
    // Start is called before the first frame update
    void Start()
    {
        location_has_book = new bool[transform.childCount];
        for (int i = 0; i < location_has_book.Length; i++)
        {
            location_has_book[i] = false;
        }

        if (numBooks > transform.childCount)
        {
            numBooks = transform.childCount;
        }

        for (int i = 0; i < numBooks; i++)
        {
            List<int> locations = new List<int>();
            // Get locations that do not have books yet
            for (int j = 0; j < location_has_book.Length; j++)
            {
                if (location_has_book[j] == false)
                {
                    locations.Add(j);
                }
            }
            // Pick a random location
            int index = Random.Range(0, locations.Count);
            int location = locations[index];

            // Set that location to active to generate a random book location
            location_has_book[location] = true;
            transform.GetChild(location).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
