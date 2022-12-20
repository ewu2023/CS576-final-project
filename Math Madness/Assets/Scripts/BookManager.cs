using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    // Prepare to read questions from json
    [System.Serializable]
    class Question {
        public string questionStr;
        public int answer;
    }

    [System.Serializable]
    class QuestionList {
        public Question[] questions;
    }

    private QuestionList easy_list = new QuestionList();
    private QuestionList med_list = new QuestionList();
    private QuestionList hard_list = new QuestionList();

    // JSON files to read questions from
    public TextAsset easyQuestions;
    public TextAsset mediumQuestions;
    public TextAsset hardQuestions;

    int GetRandomIndex(QuestionList list) {
        int size = list.questions.Length;
        return Random.Range(0, size);
    }


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

        // Read all questions
        easy_list = JsonUtility.FromJson<QuestionList>(easyQuestions.text);
        med_list = JsonUtility.FromJson<QuestionList>(mediumQuestions.text);
        hard_list = JsonUtility.FromJson<QuestionList>(hardQuestions.text);

        // Create random list of 6 questions
        List<Question> game_questions = new List<Question>();

        for (int i = 0; i < numBooks; i++) {
            if (i % 3 == 0) {
                // Pick from easy list
                game_questions.Add(easy_list.questions[GetRandomIndex(easy_list)]);
            } else if (i % 3 == 1) {
                // Pick from medium list
                game_questions.Add(med_list.questions[GetRandomIndex(med_list)]);
            } else {
                // Pick from hard list
                game_questions.Add(hard_list.questions[GetRandomIndex(hard_list)]);
            }
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
            // transform.GetChild(location).gameObject.SetActive(true);
            GameObject book_spawn_point = transform.GetChild(location).gameObject;
            BookSpawn book = book_spawn_point.GetComponent<BookSpawn>();
            book.question = game_questions[i].questionStr;
            book.answer = game_questions[i].answer;
            book_spawn_point.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
