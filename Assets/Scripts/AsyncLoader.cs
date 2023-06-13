using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsyncLoader : MonoBehaviour
{
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private GameObject MainMenu;

    [SerializeField] private Slider LoadingSlider;

    public void LoadLevelButton(string levelToLoad)
    {
        MainMenu.SetActive(false);
        LoadingScreen.SetActive(true);

        StartCoroutine(LoadLevelAsync(levelToLoad));
    }

    IEnumerator LoadLevelAsync(string levelToLoad)
    {
        AsyncOperation loadoperation = SceneManager.LoadSceneAsync(levelToLoad);

        while (!loadoperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadoperation.progress / 0.9f);
            LoadingSlider.value = progressValue;
            yield return null;
        }
    }
}
