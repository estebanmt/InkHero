using UnityEngine;
using System.Collections;

public class TitleScreenMove : MonoBehaviour {

    public Vector3 initialPos;
    public float speedX, speedY;

    public float limX;
	// Use this for initialization
	void Start () {

        initialPos = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 update = new Vector3(transform.position.x + speedX, transform.position.y + speedY);
        transform.position = update;

        if (transform.position.x > limX)
        {
            Vector3 newPos = new Vector3(initialPos.x, initialPos.y + Random.Range(-2, 1));
            transform.position = newPos;
        }
	}
}
