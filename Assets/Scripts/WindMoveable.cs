using UnityEngine;
using System.Collections;

public class WindMoveable : MonoBehaviour {

    public bool lockedX, lockedY; // indican si la coord del objeto es bloqueada (no cambia)

    public float power;
    public float maxSpeedX;
    public float maxSpeedY;

    public bool resetSpeedY;

    public Rigidbody2D rb2d;

    private WindScript ws;
    private float speed;
    

	// Use this for initialization
	void Start ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("wind"))
        {
            ws = collider.gameObject.GetComponent<WindScript>();
            rb2d.AddForce(ws.direction*power);
        }
        

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float speedX;
        float speedY;

        if (resetSpeedY)
            if (rb2d.velocity.y < 0)
                rb2d.velocity = new Vector2(rb2d.velocity.x, 2);


        if (rb2d.velocity.x > maxSpeedX)
            speedX = maxSpeedX;
        else if (-rb2d.velocity.x > maxSpeedX)
            speedX = -maxSpeedX;
        else
            speedX = rb2d.velocity.x;

        if (rb2d.velocity.y > maxSpeedY)
            speedY = maxSpeedY;
        else
            speedY = rb2d.velocity.y;

        if (lockedX)
            speedX = 0;
        if (lockedY)
            speedY = 0;
        
        rb2d.velocity = new Vector2(speedX, speedY);
    }
}
