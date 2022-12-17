using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour {
    public float duration; // How long the effect will last

    // Internal state
    internal GameObject player;
    internal float time_picked_up;
    internal float expiration_time;

    // Apply effect
    public abstract void ApplyEffect();

    // Remove effect
    public abstract void RemoveEffect();

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
    void Start() {
        time_picked_up = -1.0f;
    }

    void Update() {
        // Check if powerup has been picked up
        if (time_picked_up >= 0.0f) {
            if (HasExpired(Time.time)) {
                // Remove effect on player
                RemoveEffect();

                // Destroy this game object
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.name == "PlayerCapsule") {
            // Mark time picked up and expiration time
            time_picked_up = Time.time;
            expiration_time = time_picked_up + duration;

            // Disable power up
            HidePowerup();

            // Apply effect to player
            this.player = other.gameObject;
            ApplyEffect();
        }
    }
}
