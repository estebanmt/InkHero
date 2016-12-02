using UnityEngine;
using System.Collections;

public class AbueloScript : MonoBehaviour {

    private Animator anim;
    private Transform t;
    private bool aplastado = false;

    public Transform aplastador;
    public float aplastadorDistance;
    public float aplastadoPosition;
    public float standPosition;

	// Use this for initialization
	void Start () {

        anim = gameObject.GetComponent<Animator>();
        t = gameObject.GetComponent<Transform>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(transform.position, aplastador.position) > aplastadorDistance)
        {
            aplastado = false;
            t.position = new Vector3(t.position.x, standPosition, t.position.z);
        }
        else
        {
            aplastado = true;
            t.position = new Vector3(t.position.x, aplastadoPosition, t.position.z);
        }

        anim.SetBool("Aplastado", aplastado);
	}

    //void OnTriggerStay2D(Collider2D c)
    //{
    //    if (c.tag.Equals("Rock"))
    //    { 
    //        aplastado = true;
    //        t.position = new Vector3(t.position.x, aplastadoPosition, t.position.z);
    //    }   
    //}

    //void OnTriggerExit2D(Collider2D c)
    //{
    //    if (c.tag.Equals("Rock"))
    //    {
    //        aplastado = false;
    //        t.position = new Vector3(t.position.x, standPosition, t.position.z);
    //    }
    //}

    //void OnTriggerEnter2D(Collider2D c)
    //{
    //    if (c.tag.Equals("Rock"))
    //    {
    //        aplastado = true;
    //        t.position = new Vector3(t.position.x, aplastadoPosition, t.position.z);
    //    }
    //}
}
