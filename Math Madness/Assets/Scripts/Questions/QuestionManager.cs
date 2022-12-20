using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;

public class QuestionManager : MonoBehaviour {
    // Possible states player could be in
    private enum PlayerState {
        ROAMING,
        NEARBY,
        ANSWERING,
        WIN
    }

    // Keep track of books in level
    public List<Book> books;

    // Keep track of number of correct answers
    private int num_correct_answers;

    // Number of questions needed to win
    public int total_needed;

    // Get reference to player
    public GameObject player;

    // Get UI elements
    public Button interact_button;
    public GameObject background;

    public Text prompt;

    public Text try_again_text;
    public InputField player_input;

    public Text book_counter;
    private bool submitted_answer;
    private string player_answer;

    // Keep track of player state
    private PlayerState cur_player_state;

    private int cur_book = -1;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        cur_player_state = PlayerState.ROAMING;
        
        // Disable UI elements
        toggleInteractButton();
        background.SetActive(false);
        prompt.gameObject.SetActive(false);
        player_input.gameObject.SetActive(false);
        try_again_text.gameObject.SetActive(false);

        // Player has not submitted answer, so set flag to false
        submitted_answer = false;

        // Initialize books
        for (int i = 0; i < books.Count; i++) {
            Book book = books[i];
            book.player_transform = player.transform;
        }

        book_counter.text = "Books: " + "0/" + total_needed;  
    }


    // Update is called once per frame
    void Update() {
       switch (cur_player_state) {
        case PlayerState.ROAMING:
            // Check if player has won
            if (HasWon()) {
                cur_player_state = PlayerState.WIN;
                break;
            }

            // Check if there is a book nearby
            if (bookNearby()) {
                cur_player_state = PlayerState.NEARBY;
                Debug.Log("Near a book!");

                // Prompt user to answer
                toggleInteractButton();
            }

            break;

        case PlayerState.NEARBY:
            // Check if player is no longer near a book
            if (!bookNearby()) {
                cur_player_state = PlayerState.ROAMING;
                Debug.Log("No longer near a book");

                // Remove prompt for user
                toggleInteractButton();
            } else {
                // Check if player has pressed key to answer
                if (Input.GetKeyDown(KeyCode.E)) {
                    // Initialize UI
                    toggleInteractButton();
                    background.SetActive(true);

                    cur_player_state = PlayerState.ANSWERING;
                    
                    // Disable player controls
                    player.GetComponent<FirstPersonController>().enabled = false;

                    Cursor.lockState = CursorLockMode.None;

                    // Ask player the question
                    if (cur_book >= 0) {
                        Book nearest_book = books[cur_book];
                        prompt.text = nearest_book.question;
                        prompt.gameObject.SetActive(true);
                        player_input.gameObject.SetActive(true);
                    } else {
                        cur_player_state = PlayerState.ROAMING;
                    }
                }
            }

            break;

        case PlayerState.ANSWERING:
            if (submitted_answer) {
                // Check if answer is correct
                if (correctAnswer()) {
                    // Disable UI
                    background.SetActive(false);
                    prompt.gameObject.SetActive(false);
                    player_input.text = "";
                    player_input.gameObject.SetActive(false);
                    try_again_text.gameObject.SetActive(false);

                    Debug.Log("Player has answered");
                    cur_player_state = PlayerState.ROAMING;
                    
                    // Destroy book
                    Book book_to_destroy = books[cur_book];
                    books.RemoveAt(cur_book);
                    Destroy(book_to_destroy.gameObject);
                    
                    // Make player active again
                    player.GetComponent<FirstPersonController>().enabled = true;
                    Cursor.lockState = CursorLockMode.Locked;
                } else {
                    try_again_text.gameObject.SetActive(true);
                    player_input.text = "";
                }

                // Reset flag
                submitted_answer = false;
            }

            break;

        case PlayerState.WIN:
            Debug.Log("You Win!");
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("end_win");
            return;
        
        default:
            Debug.Log("Force state back to roaming");
            cur_player_state = PlayerState.ROAMING;
            break;
       } 
    }

    bool bookNearby() {
        for (int i = 0; i < books.Count; i++) {
            Book book = books[i];
            if (book.near_book) {
                cur_book = i;
                return true;
            }
        }

        cur_book = -1;
        return false;
    }

    void toggleInteractButton() {
        bool current_state = interact_button.gameObject.activeInHierarchy;
        interact_button.gameObject.SetActive(!current_state);
    }

    public void submitAnswer() {
        submitted_answer = true;
        player_answer = player_input.text;
    }

    bool correctAnswer() {
        try {
            int n = Int32.Parse(player_answer);
            Book book = books[cur_book];
            
            if (n == book.answer) {
                num_correct_answers++;
                book_counter.text = "Books: " + num_correct_answers + "/" + total_needed;
                return true;
            }

            return false;
        } catch (FormatException) {
            return false;
        }
    }

    bool HasWon() {
        return num_correct_answers == total_needed;
    }

    // For debugging: switch states
    void updateState() {
        if (Input.GetKeyDown(KeyCode.E)) {
            int state_num = (int) cur_player_state;
            state_num = (state_num + 1) % 3;
            cur_player_state = (PlayerState) state_num;
            Debug.Log("New State: " + cur_player_state);
        }
    }
}
