using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public string mapFirstLoad;
    public void onNewGame()
    {
        SceneManager.LoadScene(mapFirstLoad);
    }
}