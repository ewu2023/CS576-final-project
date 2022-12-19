using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT IT NOT BEING USED, SAVING JUST IN CASE
public class DoorManager : MonoBehaviour
{
    private List<GameObject> interactable_doors = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gameObjects;

        gameObjects = FindObjectsOfType<GameObject>();

        for (var i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i].name.Contains("Door L") || gameObjects[i].name.Contains("Door R"))
            {
                GameObject parent = gameObjects[i].transform.parent.gameObject;
                if (parent.name.Contains("Closet") || parent.name.Contains("Main Office"))
                {
                    Debug.Log(parent.name);
                    gameObjects[i].GetComponent<Door>().locked = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < interactable_doors.Count; i++)
        {
        }
    }
}
