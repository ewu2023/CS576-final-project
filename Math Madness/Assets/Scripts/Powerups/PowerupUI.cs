using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupUI : MonoBehaviour {
    // Timer elements
    public Text timer_text;
    public string powerup_name;
    
    internal bool powerup_active;
    internal bool timer_started;

    // Start is called before the first frame update
    void Start() {
        powerup_active = false;
        powerup_name = "";
        timer_text.gameObject.SetActive(false);
    }

    public void UpdateTimer(int minutes, int seconds) {
        string timer_str = powerup_name + " " + "" + minutes;
        if (seconds < 10) {
            timer_str += ":0" + seconds;
        } else {
            timer_str += seconds;
        }

        timer_text.text = timer_str;
    }
}
