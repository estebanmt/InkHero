using UnityEngine;
using System.Collections;

public class VueloEnemigo : MonoBehaviour
{

    public float movespeed;
    public float frequency;
    public float magnitude;
    public float limite_min_x;
    public float limite_max_x;
    public float fase = 0f;
    private Vector3 axis;

    private Vector3 pos;

    void Start()
    {
        pos = transform.position;

        axis = transform.up;
    }
    void Update()
    {
        pos += transform.right * Time.deltaTime * movespeed;
        transform.position = pos + axis * Mathf.Sin(fase + Time.time * frequency) * magnitude;
        if (transform.position.x <= limite_min_x || transform.position.x >= limite_max_x)
        {
            DestroyObject(gameObject);
        }
    }
}