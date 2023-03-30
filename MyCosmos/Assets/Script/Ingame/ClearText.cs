using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ClearText : MonoBehaviour
{
    public Button clearBtn;
    public Text clearText;
    public Image background;

    Sequence sequence;

    void OnEnable()
    {
        sequence = DOTween.Sequence()
        .SetDelay(3)
        .Append(background.DOFade(0.3960784f,2))
        .Join(clearText.DOFade(1,2))
        .SetDelay(0.5f);

        sequence.OnComplete(()=>{
            clearBtn.gameObject.SetActive(true);
        });
    }
}
