using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public string sceneMapFirst;
    private void Start()
    {
        SceneManager.LoadScene(sceneMapFirst);
    }
}