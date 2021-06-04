using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
   {
       if (other.tag == "Player")
       {
            Player.Instance.AddCoins();
            Destroy(this.gameObject);
       }
       
   }
}
