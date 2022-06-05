using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    
   private void OnCollisionEnter2D(Collision2D collision)
    {
     
        if (collision.gameObject.tag.Equals("Player"))  {

           
            PlayerMove player = collision.gameObject.GetComponent<PlayerMove>();
            player.score += 1;
            gameObject.SetActive(false);
               
        }
       
    }
}
