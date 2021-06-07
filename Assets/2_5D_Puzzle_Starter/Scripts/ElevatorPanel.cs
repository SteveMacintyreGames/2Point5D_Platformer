using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField] private MeshRenderer _callButton;
    
    [SerializeField] private int _requiredCoins = 8;
    private bool _elevatorCalled = false;


    
    
    //detect trigger collision

    void OnTriggerStay(Collider other)
    {
        //check for player
        if (other.tag == "Player")
        {
        //if e key is pressed
        if (Input.GetKeyDown(KeyCode.E) && (other.gameObject.GetComponent<Player>().CoinCount() >= _requiredCoins))
        {

            if (_elevatorCalled)
            {
                 _callButton.material.color = Color.red;
                 _elevatorCalled = false;
            }
            else
            {
                _callButton.material.color = Color.green;
                _elevatorCalled = true;
            } 

           if(GameObject.Find("Elevator") != null)
           {
               GameObject.Find("Elevator").GetComponent<Elevator>().CallElevator();
           }
           
        }
        
        }
    }

}
