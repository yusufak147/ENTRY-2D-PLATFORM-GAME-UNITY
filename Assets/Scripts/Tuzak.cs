using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuzak : MonoBehaviour
{
    public float health;
    public float damage;
    bool playerCollider = false;
   
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !playerCollider)
        {
            playerCollider = true;
            other.GetComponent<PlayerManager>().getDamage(damage);

        }
        else if (other.tag == "Bullet")
        {
            getDamage(other.GetComponent<BulletManager>().bulletDamage);
           
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerCollider = false;
        }
    }

    public void getDamage(float damage)
    {
        if (health - damage >= 0)
        {
            health -= damage;
            
        }
        else
        {
            health = 0;

        }
        amIdead();
    }

    void amIdead()
    {
        if (health == 0)
        {
          


        }
    }
}
