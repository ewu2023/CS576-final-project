using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    #region singleton pattern
    public static PlayerInventory instance;
    void Awake() {
        if (instance != null) {
            Debug.LogWarning("Error, an instance of player inventory already exists!");
            return;
        }

        instance = this;
    }
    #endregion

    public List<Consumable> inventory = new List<Consumable>();
    public int capacity = 3;

    // Use for inventory changes
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public bool Add(Consumable c) {
        if (inventory.Count >= capacity) {
            Debug.Log("Not enough room in inventory");
            return false;
        }

        // When something attempts to add to the inventory,
        // invoke all associated methods 
        inventory.Add(c);
        
        if (onItemChangedCallback != null) {
            onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(Consumable c) {
        inventory.Remove(c);

        if (onItemChangedCallback != null) {
            onItemChangedCallback.Invoke();
        }
    }

    public Consumable GetKey() {
        for (int i = 0; i < inventory.Count; i++) {
            Consumable cur_item = inventory[i];
            if (cur_item.name == "Key") {
                return cur_item;
            }
        }
        return null;
    }
}
