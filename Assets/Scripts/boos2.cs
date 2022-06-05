using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class boos2 : MonoBehaviour
{
    public static event Action OnEnemyDeath;

    public float health;
    public float damage;
    bool playerCollider = false;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
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
            Destroy(other.gameObject);
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
            slider.value = health;
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
            Destroy(gameObject);
            OnEnemyDeath?.Invoke();

        }
    }

}
