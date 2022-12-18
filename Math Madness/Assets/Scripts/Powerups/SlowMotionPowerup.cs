using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionPowerup : Powerup {
    public override void ApplyEffect() {
        Time.timeScale = 0.5f;
    }

    public override void RemoveEffect() {
        Time.timeScale = 1.0f;
    }
}
