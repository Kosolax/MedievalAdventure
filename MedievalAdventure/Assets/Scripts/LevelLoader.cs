using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;


    // fonction de chargement de scene
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadsAsync(sceneIndex));
    }

    IEnumerator LoadsAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            progressText.text = progress * 100 + "%";

            yield return null;


        }
    }
}
