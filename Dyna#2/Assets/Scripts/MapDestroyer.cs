using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
    public Tilemap tilemap;

    public Tile wallTile;
    public Tile destructibleTile;

    public GameObject explosionPrefab;

    //výbuch bunky, parameter je pozícia na mape, kde má nastať výbuch
    public void Explode (Vector2 worldPos)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos); //určenie bunky

        ExplodeCell(originCell); //samotný výbuch

        //propagácia výbuchu do všetkých smerov
        if (ExplodeCell(originCell + new Vector3Int(1,0,0)))
        {
            ExplodeCell(originCell + new Vector3Int(2, 0, 0));
        }
        if(ExplodeCell(originCell + new Vector3Int(0, 1, 0)))
        {
            ExplodeCell(originCell + new Vector3Int(0, 2, 0));
        }
        if (ExplodeCell(originCell + new Vector3Int(-1, 0, 0)))
        {
            ExplodeCell(originCell + new Vector3Int(-2, 0, 0));
        }
        if (ExplodeCell(originCell + new Vector3Int(0, -1, 0)))
        {
            ExplodeCell(originCell + new Vector3Int(0, -2, 0));
        }

        Invoke("DestroyClones", 0.5f);// po 0,5 sec odstránenie pozostatkov explózie


    }

    //výbuch buniek, parametrom je trojrozmerný vektor určujúci pozíciu bunky kde nastane výbuch
    bool ExplodeCell (Vector3Int bunka)
    {
        Tile tile = tilemap.GetTile<Tile>(bunka);
        if (tile == wallTile) //múry nevybuchujú
        {
            return false; //zastavenie šírenia
        }

        if (tile == destructibleTile) //výbuch zničiteľného bloku
        {
            tilemap.SetTile(bunka, null); //odstránenie prekážky
            Vector3 pos1 = tilemap.GetCellCenterWorld(bunka);
            Instantiate(explosionPrefab, pos1, Quaternion.identity); //zobrazenie explózie
            return false; //zastavenie šírenia explózie
        }
        Vector3 pos = tilemap.GetCellCenterWorld(bunka);
        Instantiate(explosionPrefab, pos, Quaternion.identity); //v prípade že na bunke nie je objekt, simulácia explózie

        return true; //propagácia na ďalšie políčko
    }

    //zničenie všetkých objektov Explosion
    public void DestroyClones()
    {
        GameObject[] explosions = GameObject.FindGameObjectsWithTag("Explosion");
        foreach (GameObject explosion in explosions)
        {
            GameObject.Destroy(explosion);
        }
    }
}
