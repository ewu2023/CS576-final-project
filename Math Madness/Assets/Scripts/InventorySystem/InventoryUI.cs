using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class InventoryUI : MonoBehaviour {
    private bool inventory_open;

    internal PlayerInventory inventory;

    // Get reference to UI components
    public GameObject inventory_ui;
    private InventorySlot[] slots;

    void Start() {
        inventory = PlayerInventory.instance;
        inventory_open = false;

        // Add callback to delegate
        inventory.onItemChangedCallback += UpdateUI;

        // Get inventory slots
        slots = inventory_ui.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Debug.Log("Pressed slot 0");
            slots[0].Use();
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Debug.Log("Pressed slot 1");
            slots[1].Use();
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Debug.Log("Pressed slot 2");
            slots[2].Use();
        }
    }

    void UpdateUI() {
        for (int i = 0; i < slots.Length; i++) {
            // Check if a new item was added
            if (i < inventory.inventory.Count) {
                slots[i].AddConsumable(inventory.inventory[i]);
            } else {
                // If there is no item in the current slot, clear it
                slots[i].ClearSlot();
            }
        }
    }
}
