using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void LoadScene() => SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

    public static void UnloadScene() => SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
}
