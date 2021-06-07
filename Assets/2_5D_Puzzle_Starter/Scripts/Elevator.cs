using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] Transform _pointA;
    [SerializeField] Transform _pointB;

    private bool _goingDown = false;
    [SerializeField] private float _speed = 2f;

    public void CallElevator()
    {       
       _goingDown = !_goingDown;
    }

    void FixedUpdate()
    {
        if (_goingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, _speed * Time.deltaTime);
        }
        if (_goingDown == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, _speed * Time.deltaTime);

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}

   
