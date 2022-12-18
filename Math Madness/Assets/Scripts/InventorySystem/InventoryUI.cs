using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetKeyDown(KeyCode.I)) {
            inventory_open = !inventory_open;
        }

        if (inventory_open) {
            Cursor.lockState = CursorLockMode.None;
        } else {
            Cursor.lockState = CursorLockMode.Locked;
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
