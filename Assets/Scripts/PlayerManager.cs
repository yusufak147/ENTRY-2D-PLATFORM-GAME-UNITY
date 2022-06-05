using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;   
public class PlayerManager : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    public float health ;
    public bool dead =false;
    public float BulletSpeed;
    public Transform Bullet ,Muzzle ;

    [SerializeField] private AudioSource deathSoundEffect;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
         slider.maxValue=health;
         slider.value=health;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            shootBullet();
        }
       

    }
    public void getDamage(float damage)
    {
    
        if(health-damage>=0)
          {
             health-=damage;
            slider.value=health;
          }
        else{
            health=0;
        }
        if (health == 0)
        {
            amIdead();
        }
    }
    
   void amIdead()
    {
            slider.value = 0;
            dead =true;
            deathSoundEffect.Play();
            OnPlayerDeath?.Invoke();
        
    }
    void shootBullet(){
        if (dead == false)
        {
            Transform tempBullet;
            tempBullet = Instantiate(Bullet, Muzzle.position, Quaternion.identity);
            tempBullet.GetComponent<Rigidbody2D>().AddForce(Muzzle.forward * BulletSpeed);
        }
        
    }
}
