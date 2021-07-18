using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader
{
    public static void LoadNextLevel()
    {
        LoadNextScene();
    }

    public static AsyncOperation LoadNextScene() => LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    public static AsyncOperation UnloadThisScene() => UnloadScene(SceneManager.GetActiveScene().buildIndex);

    public static AsyncOperation LoadScene(int buildIndex) => SceneManager.LoadSceneAsync(buildIndex);

    public static AsyncOperation UnloadScene(int buildIndex) => SceneManager.UnloadSceneAsync(buildIndex);
}
