using UnityEngine;
using System.Collections;

public class MakeChildren : MonoBehaviour
{

    // Use this for initialization
    public string etiqueta_cosa_fija = "Player";
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag.Equals(etiqueta_cosa_fija))
        {
            print("entra ");
            c.collider.transform.parent.GetComponentInChildren<Rigidbody2D>();
            print("entra2" + c.transform);
            print("entra3" + c.transform.parent);
            c.transform.parent.parent = gameObject.transform;
            print("entra3" + c.transform.parent.parent);


        }
    }

    //private void OnCollisionEnter2D(Collision2D c)
    //{
    //    if (c.collider.tag.Equals(etiqueta_cosa_fija))
    //    {
    //        print("entra " + c.collider.transform.parent);
    //        print("entra2" + c.transform.parent);
    //        c.transform.parent.parent = gameObject.transform;
    //        print("entra3" + c.transform.parent.parent);
    //    }

    //}

    //private void OnCollisionExit2D(Collision2D c)
    //{
    //    print("sale");
    //    c.transform.parent.parent.parent = null;
    //}


}
