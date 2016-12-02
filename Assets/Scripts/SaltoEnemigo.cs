using UnityEngine;
using System.Collections;

public class SaltoEnemigo : MonoBehaviour {

	public bool grounded = false;
	public float jumpPower = 400f;
	private Rigidbody2D rb2d;
    private float tiempo_piso = 0f;
    public float tiempo_limite_piso = 1f;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (grounded)
		{
            tiempo_piso += Time.deltaTime;
            if (tiempo_piso >= tiempo_limite_piso)
            {
                rb2d.AddForce(Vector2.up * jumpPower*10);
                tiempo_piso = 0f;
            }
			
		}
	}
}