using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public string sceneMapFirst;
    private void Start()
    {
        Debug.Log("test");
        SceneManager.LoadScene(sceneMapFirst);
    }
}