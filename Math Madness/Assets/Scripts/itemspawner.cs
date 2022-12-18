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
    private List<GameObject> items = new List<GameObject>();
    private bool[] itemspawned;

    // Start is called before the first frame update
    void Start()
    {
        items.Add(key);
        items.Add(slow);
        items.Add(speed);

        itemspawned = new bool[transform.childCount];
        for (int i = 0; i < itemspawned.Length; i++)
        {
            itemspawned[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpawnItem();
    }

    public void SpawnItem()
    {
        int location = Random.Range(0, transform.childCount);
        if (!itemspawned[location])
        {
            itemspawned[location] = true;
            GameObject item = Instantiate(items[Random.Range(0, items.Count)]) as GameObject;
            item.transform.position = transform.GetChild(location).position;
        }
    }
}
