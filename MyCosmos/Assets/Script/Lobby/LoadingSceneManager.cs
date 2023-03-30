using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadingSceneManager : MonoBehaviour
{
    public static string nextScene;

    [SerializeField]
    Text dot;

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
        op.allowSceneActivation = false;

        dot.DOText("...",1.5f).SetLoops(2,LoopType.Restart).OnComplete(()=>{
            op.allowSceneActivation=true;
        });

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
