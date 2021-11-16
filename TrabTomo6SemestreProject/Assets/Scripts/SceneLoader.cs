using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject loadingScreen;

    public static int level = 1;

    public void LoadNextScene()
    {
        StartCoroutine(LoadSceneAsync());

        ++level;

        print(level);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        if (loadingScreen)
            loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        if(loadingScreen)
            loadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            yield return null;
        }
    }
}
