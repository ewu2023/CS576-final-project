using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private bool[] itemspawned;
    // Start is called before the first frame update
    void Start()
    {
        itemspawned = new bool[transform.childCount];
        for (int i = 0; i < itemspawned.Length; i++)
        {
            itemspawned[i] = false;
        }
        InvokeRepeating("SpawnItem", 0.1f, 10.0f);
    }

    // Takes in a child # associated with a location
    void SpawnItem()
    {
        int location = Random.Range(0, transform.childCount);
        if (!itemspawned[location])
        {
            itemspawned[location] = true;
            transform.GetChild(location).GetComponent<ItemSpawner>().SpawnItem(location);
        }
    }

    public void freeLocation(int location)
    {
        itemspawned[location] = false;
    }

}
