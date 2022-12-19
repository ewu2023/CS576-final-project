using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

[CreateAssetMenu(fileName="New Consumable", menuName="Inventory/Consumable")]
public class Consumable : ScriptableObject {
    // Properties
    new public string name = "New Consumable";
    public string description;
    public Sprite icon = null;

    public virtual void Consume() {
        Debug.Log("Using " + name);
    }
}
