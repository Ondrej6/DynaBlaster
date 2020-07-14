using UnityEngine;

public class Enemy_movement : MonoBehaviour
{
    /*
     * Skript pre pohyb a interakciu nepriateľov na mape
     */

    public float speed = 1f; //rýchlosť pohybu
    public Rigidbody2D rb; //objekt RigidBody2D je pevné teleso na mape v tomto prípade Enemy

    //boolovské premenné na určenie smeru pohybu
    public bool horizontal = true;
    public bool vpravo = true;
    public bool hore = true;

    //riadenie fyziky príšer (nezávislé na framerate)
    private void FixedUpdate()
    {
        //určenie smeru
        if (horizontal)
        {
            if (vpravo)
            {
                transform.Translate(Time.deltaTime * speed, 0, 0); //right
            }
            else
            {
                transform.Translate(-1 * Time.deltaTime * speed, 0, 0); //left 
            }
        }
        else
        {
            if (hore)
            {
                transform.Translate(0, Time.deltaTime * speed, 0); //up
            }
            else
            {
                transform.Translate(0, -1 * Time.deltaTime * speed, 0); //down
            }
        }
    }

    //interakcia s ostatnými objektmi
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Wall") || (coll.gameObject.CompareTag("Bomb"))) //v prípade kolízie s inými objektmi nastane zmena smeru
        {
            if (horizontal)
            {
                if (vpravo)
                {
                    vpravo = false;
                }
                else
                {
                    vpravo = true;
                }
            }
            else
            {
                if (hore)
                {
                    hore = false;
                }
                else
                {
                    hore = true;
                }
            }
        }
        if (coll.gameObject.CompareTag("Explosion")) //pri dotknutí explózie objekt zaniká
        {
            Destroy(gameObject);
        }
    }    
}
