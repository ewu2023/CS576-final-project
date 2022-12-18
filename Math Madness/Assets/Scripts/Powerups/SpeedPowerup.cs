using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class SpeedPowerup : Powerup {
    public float SpeedFactor;
    private FirstPersonController controller;

    // Initialize power up name
    void Start() {
        powerup_name = "Speed";
    }
    public override void ApplyEffect() {
        if (controller == null) {
            controller = player.GetComponent<FirstPersonController>();
        }

        controller.MoveSpeed *= SpeedFactor;
        controller.SprintSpeed *= SpeedFactor;
    }

    public override void RemoveEffect() {
        controller.MoveSpeed /= SpeedFactor;
        controller.SprintSpeed /= SpeedFactor;
    }
}
