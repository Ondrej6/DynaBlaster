using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    /*
     * Skript meniaci scénu na menu
     */
    public void Changescene()
    {
        SceneManager.LoadScene(0);
    }
}
