using UnityEngine;
using System.Collections;

public class Sopla : MonoBehaviour {

    public bool xWind;
    public bool yWind;
    public bool resetSpeedY;  //indica si resetea su velocidad al tocar Wind
    public bool moveable; // permite/bloquea el movimiento

    public float maxSpeedX;
    public float dx;    
    public float maxSpeedY;
    public float dy;

    public float KMaxSpeedX;
    public float Kdx;

    public Rigidbody2D Winded;

    private float KxVel;
    

    void Start()
    {
        KxVel = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("wind") && moveable)
        {
            if (Winded.isKinematic)
            {
                KxVel = Mathf.Min(KxVel + Kdx, KMaxSpeedX);
            }
            int yg = Winded.velocity.y < maxSpeedY && yWind ? 1 : 0;
            int xg = Winded.velocity.x < maxSpeedX && xWind ? 1 : 0;

            if (resetSpeedY && yg < 0)
                yg = 1;

            Winded.AddForce(transform.up * yg * dy + transform.right * xg * dx);
        }
        if (other.CompareTag("stoper"))
        {
            KxVel = 0;
            moveable = false;
        }
    }

    void Update()
    {
        if (Winded.isKinematic)
        {
            Winded.gameObject.transform.Translate(transform.right * KxVel);
            KxVel = Mathf.Max(0, KxVel - Kdx * 1/100);
        }
    }
}
