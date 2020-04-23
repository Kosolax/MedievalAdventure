/* -------------------------------------------------------------- */
/* -----------All rights reserved to Medieval Adventure---------- */
/* -------------------------------------------------------------- */

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

    internal IEnumerator LoadsAsync(int sceneIndex)
    {
        float timer = 0f;
        float minLoadTime = 2.5f;
        float progressManuel = 0f;

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;
        loadingScreen.SetActive(true);

        while (!operation.isDone || timer < minLoadTime)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            timer += Time.deltaTime;
            if (timer < minLoadTime || operation.isDone)
            {
                if (timer > 0.625 && timer < 0.700)
                {
                    progressManuel = 0.25f;
                }
                else if (timer > 1.250 && timer < 1.300)
                {
                    progressManuel = 0.50f;
                }
                else if (timer > 1.875 && timer < 1.900)
                {
                    progressManuel = 0.75f;
                }
                else if (timer > 2.300 && timer < 2.400)
                {
                    progressManuel = 1f;
                }
                slider.value = progressManuel;
                progressText.text = progressManuel * 100 + "%";
            }
            else if (!operation.isDone)
            {
                slider.value = progress;
                progressText.text = progress * 100 + "%";
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
        yield return null;
    }
}
