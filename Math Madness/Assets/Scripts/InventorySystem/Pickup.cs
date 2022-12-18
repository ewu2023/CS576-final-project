using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    public Consumable consumable;
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "PlayerCapsule") {
            Debug.Log("Picking up item");

            // Add to player's inventory
            if (PlayerInventory.instance.Add(consumable)) {
                Destroy(gameObject);
            }
        }
    }
}