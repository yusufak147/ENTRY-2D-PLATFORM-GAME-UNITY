using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMove : MonoBehaviour
{
   
    Rigidbody2D rgb;
    Vector3 velocity;
    public Animator animator;
    public TextMeshProUGUI playerScoreText;

    public int score;
   public AudioSource jumpSoundEffect;
    float speedAmount = 5f;
    float jumpAmount = 6f;
    
    private void OnEnable()
    {
        PlayerManager.OnPlayerDeath += DisablePlayerMovement;
    }
    private void OnDisable()
    {
        PlayerManager.OnPlayerDeath -= DisablePlayerMovement;
    }
   
    // Start is called before the first frame updateS
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        score = 0;
        EnablePlayerMovement();
    }

    // Update is called once per frame
    void Update()
    {

        playerScoreText.text = score.ToString();

        // yön tuþlarýyla hareket etme 
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

          //Zýplama buton ayarlama ve bir kere zýplama 
        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rgb.velocity.y, 0))
        {
            jumpSoundEffect.Play();
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
            animator.SetBool("IsJumping",true);
        }
          //zýplama animasyonu
           if (animator.GetBool("IsJumping") && Mathf.Approximately(rgb.velocity.y, 0))
        {
            animator.SetBool("IsJumping", false);
        }
          //sola dönüþ animasyonu
        if(Input.GetAxisRaw("Horizontal")==-1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        //sað dönüþ animasyonu
        else if (Input.GetAxisRaw("Horizontal")== 1)
            {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        
    }
    private void DisablePlayerMovement()
    {
        animator.enabled = false;
       speedAmount = 0f;
        jumpAmount= 0f;
        jumpSoundEffect.enabled = false;

    }
    private void EnablePlayerMovement()
        {
            animator.enabled = true;
        
    }
   

}
