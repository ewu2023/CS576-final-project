using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinItem : MonoBehaviour
{
    public float scale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(
                               scale + 0.2f * Mathf.Abs(Mathf.Sin(4.0f * Time.time)),
                               scale + 0.2f * Mathf.Abs(Mathf.Sin(4.0f * Time.time)),
                               scale + 0.2f * Mathf.Abs(Mathf.Sin(4.0f * Time.time))
                               );
        transform.Rotate(new Vector3(0.0f,20.0f,0.0f) * Time.deltaTime);
    }
}
