using UnityEngine;

public class MenuGame : MonoBehaviour
{
    public string sceneMapFirst;
    public void onNewGame()
    {
        SceneManager.LoadScene(sceneMapFirst);
    }
}