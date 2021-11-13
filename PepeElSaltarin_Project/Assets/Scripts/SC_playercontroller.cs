using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_playercontroller : MonoBehaviour
{
    private float movementSpeed = 5f;
    private bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform t = this.GetComponent<Transform>();

        //Right movement
        if(Input.GetKey(KeyCode.RightArrow))
        {
            t.localScale = new Vector2(1,1); //Flips the sprite and his components
            t.position = new Vector2(t.position.x + Time.deltaTime * movementSpeed, t.position.y);
        }
        //Left movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            t.localScale = new Vector2(1,-1); //Flips the sprite and his components
            t.position = new Vector2(t.position.x - Time.deltaTime * movementSpeed, t.position.y);
        }
        //Jump action
        if (Input.GetKey(KeyCode.Space))
        {
            t.position = new Vector2(t.position.x, t.position.y + Time.deltaTime * movementSpeed);
            jumping = true;
        }
    }
}
