using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerup {
    public float duration {get; set;} // Max duration for which effect will last
    public GameObject player {get; set;} // Get reference to player object

    public void ApplyEffect(); // Apply effect to player
}
