using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PosicionFijaSobreObjeto : MonoBehaviour
{

	// Use this for initialization
	public float x_max;
	public string etiqueta_cosa_fija = "playerGround";
	public float y_min = -15;
	private float diferencia_x;
	private float diferencia_y;
	public PlayerScript player;
	Vector3 posicion;
	private bool llego;
	private float vel_personaje;
	private Rigidbody2D rb2d;

	private Vector2 previousSpeed;
	private bool playerOnObject;
	private Vector2 deltaSpeed;

	void Start()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		previousSpeed = new Vector2(0,0);
		deltaSpeed = new Vector2(0,0);
		playerOnObject = false;
	}

	// Update is called once per frame
	void Update()
	{
		deltaSpeed += rb2d.velocity - previousSpeed;

		if (!playerOnObject)
			deltaSpeed = new Vector2(0, 0);

		if (playerOnObject)
		{
			//player.addSpeed(deltaSpeed.x, 0);
			//deltaSpeed.x = deltaSpeed.y = 0;
			player.setSpeedX(rb2d.velocity.x);
		}

		//    if (llego)
		//    {
		//        if (Input.GetButtonDown("Jump") || posicion.x > x_max || posicion.y < y_min || CrossPlatformInputManager.GetButtonDown("Jump"))
		//        {
		//            llego = false;
		//            player.set_vel_x(vel_personaje);
		//        }

		//        else
		//        {
		//            posicion.x = transform.position.x + diferencia_x;
		//            posicion.y = transform.position.y + diferencia_y;
		//            //player.set_vel_y (rb2d.velocity.y); no sirve por ahora esto
		//            float vel = player.set_position_return_vel_x(posicion.x, posicion.y, false);
		//            if (vel > 0)
		//            {
		//                vel_personaje = vel;
		//            }

		//        }

		//    }


	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.collider.tag.Equals(etiqueta_cosa_fija))
		{
			//llego = true;
			//player = c.gameObject.GetComponentInParent<PlayerScript>();
			//posicion = c.gameObject.transform.position;
			//print("posicion personaje" + c.gameObject.transform.position);
			//print("posicion" + posicion);
			//diferencia_x = posicion.x - transform.position.x;
			//diferencia_y = posicion.y - transform.position.y;
			playerOnObject = true;
		}
	}

	void OnCollisionExit2D(Collision2D c)
	{
		if (c.collider.tag.Equals(etiqueta_cosa_fija))
		{
			playerOnObject = false;
			deltaSpeed = new Vector2(0, 0);
			previousSpeed = new Vector2(0, 0);
		}
	}

	void OnCollisionStay2D(Collision2D c)
	{

	}
}
