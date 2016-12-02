using UnityEngine;
using System.Collections;

public class FingerScript : MonoBehaviour {

    //public float speed = 25f;

    private Vector2 start;
    public Vector2 end;

    private Vector2 mult;
    int count;

	void Start ()
    {
        start = transform.position;
        transform.position = start;
        count = 0;

        //transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(end, start));
	}
	

	void Update ()
    {
		bool padre_se_movio = GetComponentInParent<BoolMov> ().has_moved;
		if (padre_se_movio) {
			Destroy(gameObject);
		}

        if (count < 40)
        {
            Vector3 change = end - start;
            change = 0.025f * change;
            transform.position = transform.position + change;
        }
        if (count > 50)
        {
            transform.position = start;
            count = 0;

        }

        count++;

    }
}
