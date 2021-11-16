using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_player : MonoBehaviour
{
    private float movementSpeed = 250f;
    private float movedirection;
    private float gravity = 250f;

    private bool jumping = false;
    private bool isgrounded;
    public bool attacking = false;
    
    public Transform pisoCheck;
    public LayerMask terrainmask;
    public Animator anim;

    private Vector2 initialpos;

    // Start is called before the first frame update
    void Start()
    {
        initialpos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Attacking", attacking);

        Transform t = this.GetComponent<Transform>();

        movedirection = 0; //Default movement direction

        //Right movement
        if (Input.GetKey(KeyCode.D))
        {
            movedirection = 1;
            t.localScale = new Vector2(1, 1); //Flips the sprite and his components
        }
        //Left movement
        if (Input.GetKey(KeyCode.A))
        {
            movedirection = -1;
            t.localScale = new Vector2(1, -1); //Flips the sprite and his components
        }
        //Jump action
        if (Input.GetKey(KeyCode.Space))
        {
            jumping = true;
        }
        //Attack action starts
        if (Input.GetKey(KeyCode.G))
        {
            attacking = true;
        }
        //Attack action ends
        if (Input.GetKeyUp(KeyCode.G))
        {
            attacking = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform t = this.GetComponent<Transform>();

        if (collision.tag == "Enemy") {
            if (collision.gameObject != null)
                collision.gameObject.GetComponent<SC_squit>().Morir();
        }
        if (collision.tag == "Exit")
            collision.gameObject.SetActive(false);
        if (collision.tag == "Limit")
            t.position = initialpos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            this.transform.position = initialpos;
    }

    private void FixedUpdate()
    {
        isgrounded = Physics2D.OverlapCircle(pisoCheck.position,0.02f,terrainmask);

        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();

        if(jumping == true && isgrounded == true)
        {
            rb.AddForce(new Vector2(0,gravity));
            jumping = false;
        }
        if(movedirection > 0)
        {
            rb.velocity = new Vector2(Time.deltaTime * movementSpeed,rb.velocity.y);
        }
        if (movedirection < 0)
        {
            rb.velocity = new Vector2(-Time.deltaTime * movementSpeed,rb.velocity.y);
        }
        if(movedirection == 0)
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }
    }
}
