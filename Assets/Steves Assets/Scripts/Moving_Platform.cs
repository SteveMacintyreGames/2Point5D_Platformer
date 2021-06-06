using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    [SerializeField] private Transform _targetA,_targetB;
    [SerializeField] private float _speed = 1.0f;
    private Vector3 _currentTarget;

    void Start()
    {
        _currentTarget = _targetB.position;
    }
    void FixedUpdate()
    {
        MoveTowardsCurrentTarget();
        CheckIfTargetReached();        
    }

    void MoveTowardsCurrentTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);
    }

    void CheckIfTargetReached()
    {
        if (transform.position == _targetB.position)
        {
            _currentTarget = _targetA.position;
        }
        if (transform.position == _targetA.position)
        {
            _currentTarget = _targetB.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
   
}
