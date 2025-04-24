using UnityEngine;
using UnityEngine.SceneManagement;

public class NotSceneManager : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
