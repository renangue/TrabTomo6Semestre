using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject loadingScreen;

    public static int level = 1;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Period))
        {
            NextScene();
        }

        if(Input.GetKeyDown(KeyCode.Comma))
        {
            PreviousScene();
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadSceneAsync());

        ++level;

        print(level);
    }

    void NextScene()
    {
        StartCoroutine(LoadSceneAsync());
    }

    void PreviousScene()
    {
        StartCoroutine(PreviousSceneAsync());
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

    IEnumerator PreviousSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex -1);

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
