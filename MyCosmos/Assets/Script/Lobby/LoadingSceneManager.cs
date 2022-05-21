using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public static string nextScene;

    //[SerializeField]
    //Image progressBar;

    [SerializeField]
    Text[] dot;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = true;


        /*float timer = 0.0f;
        while(!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime;
            for (int i = 0; i < 3; i++)
            {
                if(timer>=1.0f)
                {
                    dot[i].color = new Color(1, 1, 1, 1);
                    timer = 0f;
                }
            }
        }*/
        

        /*float timer = 0.0f;

        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime;
            if (op.progress < 0.9f) { progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer); if (progressBar.fillAmount >= op.progress) { timer = 0f; } }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                if (progressBar.fillAmount == 1.0f) { op.allowSceneActivation = true; yield break; }
            }
        }*/

    }
}
