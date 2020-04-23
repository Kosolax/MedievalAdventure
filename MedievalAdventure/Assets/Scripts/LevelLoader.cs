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
        float timer = 0f;
        float minLoadTime = 2.5f;
        float slideValue = 0f;
        float progressValue = 0f;
        


        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;
        loadingScreen.SetActive(true);

        while (!operation.isDone || timer < minLoadTime)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            timer += Time.deltaTime;
            if(timer < minLoadTime || operation.isDone)
            {
                if (timer > 0.625 && timer < 0.700)
                {
                    slideValue = 0.25f;
                    progressValue = 25f;
                }
                else if (timer > 1.250 && timer < 1.300)
                {
                    slideValue = 0.50f;
                    progressValue = 50f;
                }
                else if (timer > 1.875 && timer < 1.900)
                {
                    slideValue = 0.75f;
                    progressValue = 75f;
                }
                else if (timer > 2.300 && timer < 2.400)
                {
                    slideValue = 1f;
                    progressValue = 100;
                }

                slider.value = slideValue;
                progressText.text = progressValue + "%";
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
