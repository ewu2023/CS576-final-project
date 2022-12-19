using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // Items
    public GameObject key;
    public GameObject slow;
    public GameObject speed;
    public AudioClip getkey_sound;
    public AudioClip powerdown_sound;
    public AudioClip electriczap_sound;

    // Internal
    private List<GameObject> items;
    private int location_num;
    private int index;
    private List<AudioClip> sounds;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        items = new List<GameObject>();
        items.Add(key);
        items.Add(slow);
        items.Add(speed);

        source = GetComponent<AudioSource>();
        sounds = new List<AudioClip>();
        sounds.Add(getkey_sound);
        sounds.Add(powerdown_sound);
        sounds.Add(electriczap_sound);
    }

    public void SpawnItem(int location)
    {
        location_num = location;
        index = Random.Range(0, items.Count);
        GameObject item = Instantiate(items[index], this.transform) as GameObject;
        item.transform.position = transform.position;
    }

    public void freeLocation()
    {
        source.PlayOneShot(sounds[index]);
        transform.parent.gameObject.GetComponent<ItemManager>().freeLocation(location_num);
    }
}
