using UnityEngine;
using System.Collections;
using Line2D;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

public class Drawable : MonoBehaviour {

    public GameObject fire;
    public GameObject wind;

    public RectTransform drawSpace;

    Line2DRenderer line2d;
    bool spawn = false;
    bool drawing = false;
    bool inEditor = false;
    PlayerScript player;
    Touch touch;

    int activeTouchId;


    List<Vector3> spawnPoints = new List<Vector3>();
    Vector3 previousSpawnPoint, currentSpawnPoint;
    public float minSpawnDistance;
    public float widthMultiplier;
    public float minLineDistance;



	// Use this for initialization
	void Start ()
    {
        line2d = GetComponent<Line2DRenderer>();
        line2d.widthMultiplier = this.widthMultiplier;
        player = (PlayerScript)FindObjectOfType(typeof(PlayerScript));

#if UNITYEDITOR
        inEditor=true;
#endif

    }

	// Update is called once per frame
	void Update () {

        if (player.activeInk == Ink.None)
            return;

        //Alternative if: Input.GetMouseButtonDown(0)
        //if (Input.GetButtonDown("Fire1"))
        if (!drawing && (CrossPlatformInputManager.GetButtonDown("Draw") || (Input.GetMouseButtonDown(0) && inEditor)))
        //if (!drawing && (Input.GetMouseButtonDown(0)))
        {
            if (Input.touchCount > 0)
            {
                touch = Input.touches[Input.touchCount - 1];
                activeTouchId = touch.fingerId;
            }
            drawing = true;


            InvokeRepeating("AddPoint", 0.01f, 0.005f);
            if (!spawn)
            {
                spawn = true;
                var mousePos = Input.mousePosition;
                mousePos.z = 10; // select distance = 10 units from the camera
                Vector3 mouse = Camera.main.ScreenToWorldPoint(mousePos);

                //Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Input.touchCount > 0)
                {
                    var fingerPos = GetTouch(activeTouchId).position;
                    Vector3 datFingerPos = new Vector3(fingerPos.x, fingerPos.y, 10);
                    mouse = Camera.main.ScreenToWorldPoint(datFingerPos);
                }

                mouse.z = 0.0001f;
                line2d.points[0] = line2d.points[1] = new Line2DPoint(mouse, 1f, Color.black);
                previousSpawnPoint = line2d.points[0].pos;
                spawnPoints.Add(previousSpawnPoint);
            }
        }

        //alternative if: Input.GetMouseBUttonUp(0)
        //if (Input.GetButtonUp("Fire1"))
        //if(drawing)

        bool endTouch = false;
        if (Input.touchCount > 0)
            if (GetTouch(activeTouchId).phase == TouchPhase.Ended)
                endTouch = true;

        if (endTouch || CrossPlatformInputManager.GetButtonUp("Draw") || Input.GetMouseButtonUp(0))
        //if (endTouch || Input.GetMouseButtonUp(0))
        {
            CancelInvoke();
            ResetPoints();
            drawing = false;
            if (spawn)
            {
                SpawnInk();
                spawn = false;
                spawnPoints.Clear();
            }
        }

    }

    public void StartDrawing()
    {

    }

    void ResetPoints()
    {
        int resetPoint = 2;
        line2d.points.RemoveRange(resetPoint, line2d.points.Count - 2);
    }

    // Adds points to line2d and spawnPoints
    void AddPoint()
    {

      var mousePos = Input.mousePosition;
      mousePos.z = 10; // select distance = 10 units from the camera
      Vector3 v = Camera.main.ScreenToWorldPoint(mousePos);

        //Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.touchCount > 0) 
        {
            var fingPos = GetTouch(activeTouchId).position;
            Vector3 v3 = new Vector3(fingPos.x, fingPos.y, 10);
            v = Camera.main.ScreenToWorldPoint(v3);
        }

        v.z = 0.0001f;
        currentSpawnPoint = v;

        if(Vector3.Distance(line2d.points[line2d.points.Count-1].pos, currentSpawnPoint) > minLineDistance )
            line2d.points.Add(new Line2DPoint(v, 1f, Color.black));

        if (CheckPointCollision(currentSpawnPoint))
        {
            spawnPoints.Add(currentSpawnPoint);
            previousSpawnPoint = currentSpawnPoint;
        }


    }

    bool CheckPointCollision(Vector3 position)
    {
        foreach (Vector3 v in spawnPoints)
            if (Vector3.Distance(v, position) < minSpawnDistance)
                return false;

        return true;
    }

    // Spawns object on line depending on Ink selected
    void SpawnInk()
    {
        GameObject spawnObject = fire;

        switch(player.activeInk)
        {
            case Ink.Fire:
                spawnObject = fire;
                break;
            case Ink.Wind:
                spawnObject = wind;
                break;
            default:
                spawnObject = wind;
                break;
        }

        // para todas las tintas menos viento
        if(player.activeInk != Ink.Wind)
            foreach (Vector3 v in spawnPoints)
            {
                Instantiate(spawnObject, v, Quaternion.identity);
            }
        // para el viento
        else
        {
            Vector3 preV3 = new Vector3();
            GameObject previous = null;
            for (int i = 0; i < spawnPoints.Count; i++)
            {
                Vector3 v = spawnPoints[i];

                if (i == 0) //primero
                {
                    previous = (GameObject)Instantiate(spawnObject, v, Quaternion.identity);
                    preV3 = v;
                }
                else
                {
                    if (i == spawnPoints.Count - 1) //ultimo
                    {
                        WindScript a = previous.GetComponent<WindScript>();
                        a.direction = Vector3.Normalize(v - preV3);

                        float angle = Vector3.Angle(a.direction, new Vector3(1, 0, 0));
                        Vector3 cross = Vector3.Cross(new Vector3(1, 0, 0), a.direction);
                        if (cross.z < 0)
                            angle = -angle;
                        a.transform.Rotate(0, 0, angle);

                        previous = (GameObject)Instantiate(spawnObject, v, Quaternion.identity);

                        WindScript b = previous.GetComponent<WindScript>();
                        b.direction = a.direction;
                        angle = Vector3.Angle(b.direction, new Vector3(1, 0, 0));
                        cross = Vector3.Cross(new Vector3(1, 0, 0), b.direction);
                        if (cross.z < 0)
                            angle = -angle;
                        b.transform.Rotate(0, 0, angle);
                    }
                    else // entremedio
                    {

                        WindScript a = previous.GetComponent<WindScript>();
                        a.direction = Vector3.Normalize(v - preV3);
                        float angle = Vector3.Angle(a.direction, new Vector3(1, 0, 0));
                        Vector3 cross = Vector3.Cross(new Vector3(1, 0, 0), a.direction);
                        if (cross.z < 0)
                            angle = -angle;
                        a.transform.Rotate(0, 0, angle);

                        previous = (GameObject)Instantiate(spawnObject, v, Quaternion.identity);
                        //previous.transform.Rotate(new Vector3(0, 0, 180));
                        preV3 = v;
                    }
                }

            }
        }
    }

    // Returns Touch object from fingerid
    Touch GetTouch(int id)
    {

        for(int i = 0; i < Input.touchCount; i++)
        {
            if (Input.touches[i].fingerId == id)
                return Input.touches[i];
        }

        return Input.touches[0];
    }
}
