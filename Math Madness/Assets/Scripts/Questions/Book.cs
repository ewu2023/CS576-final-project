using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour {
    public Transform player_transform;
    public float radius;

    internal bool near_book;

    // Store question and answer
    public string question;
    public int answer;

    void Start() {
        near_book = false;
        player_transform = GameObject.Find("PlayerCapsule").transform;
    }

    void Update() {
        Vector3 player_pos = player_transform.position;
        float distance = (transform.position - player_pos).magnitude;
        if (distance <= radius) {
            near_book = true;
        } else {
            near_book = false;
        }
    }

    // Debugging
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
