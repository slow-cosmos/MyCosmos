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
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        var tween = dot.DOText("...",1.5f).SetLoops(2,LoopType.Restart).OnComplete(()=>{
            op.allowSceneActivation=true;
        });

        yield return tween.WaitForCompletion();

        while(!op.isDone)
        {
            var tween2 = dot.DOText("...",1.5f).SetLoops(1,LoopType.Restart);
            yield return tween2.WaitForCompletion();
        }
    }
}
