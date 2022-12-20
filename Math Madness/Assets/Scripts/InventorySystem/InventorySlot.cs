using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
    // Keep track of current item in the slot
    private Consumable cur_consumable;

    // Keep track of this slot's audio source
    private AudioSource audio_source;

    // Get sound clips to play
    public AudioClip speed_clip;
    public AudioClip slow_clip;

    // Get a reference to the icon to display
    public Image icon;
    public Button slotButton;

    void Start() {
        audio_source = gameObject.GetComponent<AudioSource>();
    }

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
            // Play audio
            if (cur_consumable.name == "Speed") {
                audio_source.PlayOneShot(speed_clip);
            } else if (cur_consumable.name == "Slow") {
                audio_source.PlayOneShot(slow_clip);
            }

            cur_consumable.Consume();

            if (cur_consumable.name != "Key") {
                PlayerInventory.instance.Remove(cur_consumable);
            }
        }
    }
}
