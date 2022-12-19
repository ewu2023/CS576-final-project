using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
    // Keep track of current item in the slot
    private Consumable cur_consumable;

    // Get a reference to the icon to display
    public Image icon;
    public Button slotButton;

    public void AddConsumable(Consumable c) {
        cur_consumable = c;
        this.icon.sprite = c.icon;
        this.icon.enabled = true;
        slotButton.enabled = true;
        slotButton.interactable = true;
    }

    public void ClearSlot() {
        cur_consumable = null;
        this.icon.sprite = null;
        this.icon.enabled = false;
        slotButton.enabled = false;
        slotButton.interactable = false;
    }

    public void Use() {
        if (cur_consumable != null) {
            cur_consumable.Consume();
            PlayerInventory.instance.Remove(cur_consumable);
        }
    }
}
