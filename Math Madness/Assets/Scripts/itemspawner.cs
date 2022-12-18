using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // Items
    public GameObject key;
    public GameObject slow;
    public GameObject speed;

    // Internal
    private List<GameObject> items;
    private int location_num;

    // Start is called before the first frame update
    void Start()
    {
        items = new List<GameObject>();
        items.Add(key);
        items.Add(slow);
        items.Add(speed);

    }

    public void SpawnItem(int location)
    {
        location_num = location;
        GameObject item = Instantiate(items[Random.Range(0, items.Count)], this.transform) as GameObject;
        item.transform.position = transform.position;
    }

    public void freeLocation()
    {
        transform.parent.gameObject.GetComponent<ItemManager>().freeLocation(location_num);
    }
}
