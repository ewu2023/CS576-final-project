using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Consumable", menuName="Inventory/SlowPowerup")]
public class SlowMotionPowerup : Consumable {
    public float time_scale;
    public float duration;

    private GameObject player;

    void OnEnable() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Consume() {
        base.Consume();
        player.GetComponent<PowerupUI>().StartTimer(Effect(player));
    }

    public IEnumerator Effect(GameObject player) {
        float cur_time = 0.0f;
        PowerupUI player_UI = player.GetComponent<PowerupUI>();
        player_UI.timer_text.gameObject.SetActive(true);
        player_UI.powerup_name = this.name;

        // APPLY EFFECT HERE
        Time.timeScale = time_scale;

        while (cur_time <= duration) {
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

        // REMOVE EFFECT HERE
        Time.timeScale = 1.0f;
        player_UI.timer_text.gameObject.SetActive(false);
        player_UI.powerup_name = "";
    }
}
