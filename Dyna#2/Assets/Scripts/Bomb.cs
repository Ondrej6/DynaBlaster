using UnityEngine;

public class Bomb : MonoBehaviour
{
    /*
    * Skript slúži na odpaľovanie bomby
    */

    public float countdown = 2f; //nastavenie časovaču na 2 sekundy

    // Update() is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        
        if (countdown <= 0f)
        {
            FindObjectOfType<MapDestroyer>().Explode(transform.position); //prevedenie explózie
            Destroy(gameObject); //zničenie samotného objektu bomby
        }
    }
}
