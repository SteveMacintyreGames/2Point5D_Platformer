using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    [SerializeField] private MeshRenderer _display;
    
   void OnTriggerStay(Collider other)
   {
        var range = .2;
        //Debug.Log("MovingBox Detected");
        if (Vector3.Distance(transform.position, other.transform.position)<range)
        {
            //Debug.Log("box is in range");
            _display.material.color = Color.blue;

            other.GetComponent<Rigidbody>().isKinematic = true;
        }
   }
}
