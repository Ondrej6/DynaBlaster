using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUp : MonoBehaviour
{
    /*
     * Skript na prechod do nového levelu
     */

    //kontrola kolízie portálu s hráčom
    //postup do ďalšieho levelu nastáva iba ak už nie sú žiadne príšery na mape
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Player") && (NumberOfEnemies() == 0))
        {
            if (SceneManager.GetActiveScene().buildIndex < 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //postup do ďalšieho levelu
            }
            else
            {
                SceneManager.LoadScene(0);
            }
            
        }
    }

    //určenie počtu nepriateľov na mape
    public int NumberOfEnemies()
    {
        int counter = 0;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            counter++;
        }
        return counter;
    }
}
