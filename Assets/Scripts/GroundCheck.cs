using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

    private PlayerScript player;

    void Start()
    {
        player = gameObject.GetComponentInParent<PlayerScript>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.GetComponent<Collider2D>().tag.Equals("trigger") && !col.GetComponent<Collider2D>().tag.Equals("wind"))
            player.grounded = true;
    }

    void OnTriggerStart2D(Collider2D col)
    {
        if (!col.GetComponent<Collider2D>().tag.Equals("trigger") && !col.GetComponent<Collider2D>().tag.Equals("wind"))
            player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (!col.GetComponent<Collider2D>().tag.Equals("trigger") && !col.GetComponent<Collider2D>().tag.Equals("wind"))
            player.grounded = false;
    }
}
