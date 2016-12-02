using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;

    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    public GameObject player;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if(bounds)
        {
            float clampX = Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x);
            float clampY = Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y);
            float clampZ = Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z);
            transform.position = new Vector3(clampX, clampY, clampZ);
        }
    }
	
    public void SetMinCamPosition()
    {
        minCameraPos = transform.position;
    }

    public void SetMaxCamPosition()
    {
        maxCameraPos = transform.position;
    }
}
