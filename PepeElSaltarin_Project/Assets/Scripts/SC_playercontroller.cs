using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_playercontroller : MonoBehaviour
{
    private float movementSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movementh = Input.GetAxis("Horizontal");
        float movementv = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(movementh * movementSpeed * Time.deltaTime, movementv * movementSpeed * Time.deltaTime, 0);
    }
}
