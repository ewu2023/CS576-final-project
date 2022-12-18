using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour {
    public float duration; // How long the effect will last
    public float time_scale;
    public string powerup_name; // Name of powerup/effect

    // Internal state
    internal GameObject player;
    internal float time_picked_up;
    internal float expiration_time;

    // Timer-based version
    internal float cur_time = -1.0f;
    private PowerupUI player_UI;

    // Apply effect
    public abstract void ApplyEffect();

    // Remove effect
    public abstract void RemoveEffect();

    // Keep track of how long power up is active
    private IEnumerator Tick() {
        while (cur_time < duration) {
            // Calculate how much time remains for the powerup
            float time_remaining = duration - cur_time;

            // Compute minutes and seconds left
            int minutes_left = (int) time_remaining / 60;
            int seconds_left = (int) time_remaining % 60;

            // Update player's timer
            player_UI.UpdateTimer(minutes_left, seconds_left);

            // Wait one tick then increment
            yield return new WaitForSeconds(1.0f * time_scale);
            cur_time += 1.0f;
        }

        // Once timer ends, remove effect and destroy game object
        RemoveEffect();
        player_UI.timer_text.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }

    // Check if effect duration has expired
    bool HasExpired(float cur_time) {
        return cur_time >= expiration_time;
    }

    // Hide power up
    void HidePowerup() {
        // Disable game object
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        this.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
    }

    // ** Unity Engine **

    void OnTriggerEnter(Collider other) {
        if (other.name == "PlayerCapsule") {
            // Mark time picked up
            cur_time = 0.0f;

            // Disable power up
            HidePowerup();

            // Apply effect to player
            this.player = other.gameObject;
            ApplyEffect();

            // Start effect timer
            player_UI = other.gameObject.GetComponent<PowerupUI>();
            player_UI.powerup_name = this.powerup_name;
            player_UI.timer_text.gameObject.SetActive(true);
            StartCoroutine(Tick());
        }
    }
}
