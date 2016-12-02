using UnityEngine;
using System.Collections;

public class InkBottleScript : MonoBehaviour {

    public Ink inkType;
    public AudioClip collectSound;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag.Equals("Player"))
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position, 2);
            
            DestroyObject(gameObject);
        }
    }
}
