using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour {

    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 150f;

    public int moneyCount;
    public GameObject moneyObject;
    private Text moneyText;

    public bool grounded = true;
    public bool canDoubleJump;

    public Ink activeInk;

    private Rigidbody2D rb2d;
    private Animator anim;

    private bool isButtonDown;
    private float direction; //-1 left, 1 right
    private bool move;

    public bool whichMoney = false;

    Vector3 tempPos;
    Vector3 velocity;

    void Start ()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        if(moneyObject != null)
            moneyText = moneyObject.GetComponent<Text>();
        //activeInk = Ink.Fire;
	}

    public void addCoin(int value)
    {
        moneyCount += value;
        if(moneyText != null)
        {
             moneyText.text = moneyCount.ToString();
        }

    }
	
	void Update ()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat(("Speed"), Mathf.Abs(rb2d.velocity.x));

        if(CrossPlatformInputManager.GetAxis("Horizontal") < -0.1f || CrossPlatformInputManager.GetButtonDown("Left") || Input.GetKeyDown(KeyCode.A))
        //if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (CrossPlatformInputManager.GetAxis("Horizontal") > 0.1f || CrossPlatformInputManager.GetButtonDown("Right")|| Input.GetKeyDown(KeyCode.D))
        //if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetButtonDown("Jump") || CrossPlatformInputManager.GetButtonDown("Jump"))
        //if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            }
            else
            {
                if(canDoubleJump)
                {
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpPower);
                }
            }
        }

        if ((CrossPlatformInputManager.GetButtonUp("Right")|| Input.GetKeyUp(KeyCode.D)) && direction == 1)
        //if ((Input.GetKeyUp(KeyCode.D)) && direction == 1)
            direction = 0;

        if ((CrossPlatformInputManager.GetButtonUp("Left")|| Input.GetKeyUp(KeyCode.A)) && direction == -1)
        //if ((Input.GetKeyUp(KeyCode.A)) && direction == -1)
            direction = 0;

        if ((CrossPlatformInputManager.GetButtonDown("Right")|| Input.GetKeyDown(KeyCode.D)))
        //if ((Input.GetKeyDown(KeyCode.D)))
            direction = 1;

        if ((CrossPlatformInputManager.GetButtonDown("Left")|| Input.GetKeyDown(KeyCode.A)))
        //if (Input.GetKeyDown(KeyCode.A))
            direction = -1;
    }

    void FixedUpdate()
    {
        //Vector3 easeVelocity = rb2d.velocity;
        //easeVelocity.y = rb2d.velocity.y;
        //easeVelocity.z = 0.0f;
        //easeVelocity.x *= 0.75f;
        //float h = 0;
        //float h = Input.GetAxis("Horizontal");
        

        

        //if (direction == 0) 
            //direction = CrossPlatformInputManager.GetAxis("Horizontal");

        //if (grounded)
        //{
            //rb2d.velocity = easeVelocity;
        //}
        
        rb2d.AddForce((Vector2.right * speed) * direction);

        if (rb2d.velocity.x > maxSpeed)
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);

        if (rb2d.velocity.x < -maxSpeed)
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);

        if (rb2d.velocity.y > maxSpeed)
            rb2d.velocity = new Vector2(rb2d.velocity.x, maxSpeed);

        // Este if hace que el jugador se frene mas rapido
        if (direction == 0 && grounded)
            rb2d.velocity = new Vector2(rb2d.velocity.x * 0.9f, rb2d.velocity.y);

        // Este if regula la velocidad de caida (no de ascension). puede que no sirva
        //if (!grounded && rb2d.velocity.y > -maxSpeed && rb2d.velocity.y < 0.1f)
            //rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y - 0.3f);


    }

    public void set_vel_x(float vel_x)
    {
        speed = vel_x;
    }
    public void set_vel_y(float vel_y)
    {
        velocity.y = vel_y;
        rb2d.velocity = velocity;
    }

    public float set_position_return_vel_x(float posicion_x, float posicion_y, bool set_pos_y)
    {
        tempPos = transform.position;
        tempPos.x = posicion_x;
        if (set_pos_y)
        {
            tempPos.y = posicion_y;
        }
        transform.position = tempPos;
        //set_vel_y (0);
        float vel = speed;
        speed = 0;
        return vel;
    }

    public void addSpeed(float x, float y)
    {
        Vector2 v2 = new Vector2(x, y);
        rb2d.velocity += v2;
    }

    public void setSpeed(float x, float y)
    {
        rb2d.velocity = new Vector2(x, y);
    }

    public void setSpeedX(float x)
    {
        rb2d.velocity = new Vector2(x, rb2d.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag.Equals("InkBottle"))
        {
            Ink ink = c.gameObject.GetComponent<InkBottleScript>().inkType;

            activateInk(ink);
        }
    }

    void activateInk(Ink ink)
    {
        activeInk = ink;
    }



}

public enum Ink {None, Fire, Wind}
