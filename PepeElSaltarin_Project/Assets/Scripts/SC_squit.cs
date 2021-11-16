using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_squit : MonoBehaviour
{
    private float movementSpeed = 1;

    private bool initialtarget = false;
    public bool ismoving;

    public Transform Target;
    public Transform Target2;

    public GameObject geocoin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Morir()
    {
        //Tirar moneda
        geocoin.SetActive(true);

        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(ismoving)
            if ((Vector3.Distance(transform.position, Target.position) > 0.5f) && (initialtarget == false))
            {

                transform.position =  Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * movementSpeed);
            }
            else
            {
                initialtarget = true;
            }

            if ((Vector3.Distance(transform.position, Target2.position) > 0.5f) && (initialtarget == true))
            {

                transform.position = Vector3.MoveTowards(transform.position, Target2.position, Time.deltaTime * movementSpeed);
            }
            else
            {
                initialtarget = false;
            }
    }
}
