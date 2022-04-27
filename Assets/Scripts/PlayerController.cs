using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public float jumpForce = 10;
    public float gravityModifier;
    private bool Grounded =true ;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem DirtySplatter;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;  
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Grounded && !gameOver){
            Debug.Log(jumpSound);
            playerAudio.PlayOneShot(jumpSound,1.0f);
            playerRb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
            Grounded = false;
            playerAnim.SetTrigger("Jump_trig");
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
    if (collision.gameObject.CompareTag("Ground")){
        Grounded = true;
        DirtySplatter.Play();
    }
    if (collision.gameObject.CompareTag("Obstacle")){
        gameOver = true;
        playerAudio.PlayOneShot(crashSound,1.0f);
        explosionParticle.Play();
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int",1);
        Debug.Log("Game Over !");
        DirtySplatter.Stop();
        }
    }    
}
