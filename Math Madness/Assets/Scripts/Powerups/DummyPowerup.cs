using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPowerup : Powerup {
    public override void ApplyEffect() {
        Debug.Log("Effect applied");
    }

    public override void RemoveEffect() {
        Debug.Log("Effect Removed");
    }
}
