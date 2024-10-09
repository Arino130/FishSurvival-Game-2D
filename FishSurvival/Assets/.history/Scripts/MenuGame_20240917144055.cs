using UnityEngine;

public class MenuGame : MonoBehaviour
{
    public string sceneFirst;
    public void onNewGame()
    {
        SceneManager.LoadScene(sceneMapFirst);
    }
}