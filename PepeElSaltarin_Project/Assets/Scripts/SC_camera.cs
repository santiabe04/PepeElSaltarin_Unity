using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_camera : MonoBehaviour
{
    private int movedirection;

    private float movementSpeed = 150f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform t = this.GetComponent<Transform>();

        movedirection = 0; //Default movement direction

        //Right movement
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movedirection = 1;
        }
        //Left movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movedirection = -1;
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();

        if (movedirection > 0)
        {
            rb.velocity = new Vector2(Time.deltaTime * movementSpeed, rb.velocity.y);
        }
        if (movedirection < 0)
        {
            rb.velocity = new Vector2(-Time.deltaTime * movementSpeed, rb.velocity.y);
        }
        if (movedirection == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
