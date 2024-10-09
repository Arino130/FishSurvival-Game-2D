using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public void newGame()
    {
        SceneManager.LoadScene("MapLevel1");
    }
}