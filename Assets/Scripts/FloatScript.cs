using UnityEngine;
using System.Collections;

public class FloatScript : MonoBehaviour {
    private Vector3 axis;

    private Vector3 pos;

    public float frequency;
    public float magnitude;
    public float fase = 0f;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;

        axis = transform.up;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = pos + axis * Mathf.Sin(fase + Time.time * frequency) * magnitude;

    }
}
