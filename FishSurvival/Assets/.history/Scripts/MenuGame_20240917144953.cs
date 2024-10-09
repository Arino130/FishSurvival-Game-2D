using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public void onNewGame()
    {
        SceneManager.LoadScene("MapLevel1");
    }
}