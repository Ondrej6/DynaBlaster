using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    /*
     * Skript riadi všetky hráčove funkcie
     */

    public float rychlost = 5f;//určenie rýchlosti
    public Rigidbody2D rb; //objekt RigidBody2D je pevné teleso na mape v tomto prípade Player
    public Animator animator; //animácia
    Vector2 pohyb; //vektor pohybu
    private bool dead = false; //určuje či hra skončila
    public int lives = 1; //počet životov


    // Update() is called once per frame
    void Update()
    {
        //registrácia pohybu na horizontálnej a vertikálnej osi
        pohyb.x = Input.GetAxisRaw("Horizontal");
        pohyb.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", pohyb.x);
        animator.SetFloat("Vertical", pohyb.y);
        animator.SetFloat("Speed", pohyb.sqrMagnitude);

        if(dead) //ukončenie hry smrťou
        {
            dead = false;
            SceneManager.LoadScene(4);
        }
        if (Input.GetKey(KeyCode.Escape)) //ukončenie hry pomocou Escape a návrat do menu
        {
            SceneManager.LoadScene(0);
        }
        
    }

    //posun na základe inputu
    void FixedUpdate()
    {        
        rb.MovePosition(rb.position + pohyb * rychlost * Time.fixedDeltaTime);
    }

    //pri kolízii s nepriateľom alebo výbuchom ukonči hru
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if ((coll.gameObject.CompareTag("Enemy") || coll.gameObject.CompareTag("Explosion")))
        {
            dead = true;
        }
    }
}