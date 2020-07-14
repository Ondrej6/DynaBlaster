using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour
{
    /*
     * Skript vytvárajúci bombu na danej pozícií
     */

    public Tilemap tilemap; //objekt Tilemap do ktorého je dosadená mapa
    public Rigidbody2D rb; //objekt RigidBody2D je pevné teleso na mape v tomto prípade Player
    private int bombCount = 3; //maximálny počet bômb na mape v jednom momente
    public GameObject bomb; //samotný herný objekt predstavujúci bombu

    // Update() is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (BombCount() < bombCount ))
        {
            Vector3 pozicia = rb.position; //určenie pozície hráča
            Vector3Int bunka = tilemap.WorldToCell(pozicia); //určenie konkrétnej bunky
            Vector3 stredBunky = tilemap.GetCellCenterWorld(bunka); //vycentrovanie pozície na bunke

            Instantiate(bomb, stredBunky, Quaternion.identity); //vytvorenie bomby na strede bunky bez rotácie
        }
    }

    public int BombCount() //funkcia vracajúca počet bômb v danom momente na mape
    {
        int counter = 0;
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject bomb in bombs)
        {
            counter += 1;
        }
        return counter;
    }
}
