using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearManage : MonoBehaviour
{
    public Image background, clearButton;
    public Text clearText, clearButtonText;
    public Button clearBtn;


    public float fadeTime = 1.5f;

    void Start()
    {
        StartCoroutine(ClearText());
    }

    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(3f);

        while (clearText.color.a < 1.0f)
        {
            clearText.color = new Color(1, 1, 1, clearText.color.a + (Time.deltaTime / fadeTime));
            //clearButton.color = new Color(1, 1, 1, clearButton.color.a + (Time.deltaTime / fadeTime));
            //clearButtonText.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, clearButtonText.color.a + (Time.deltaTime / fadeTime));

            if(background.color.a < 0.3960784f)
            {
                background.color = new Color(0,0,0, background.color.a + (Time.deltaTime / fadeTime));
            }

            yield return null;
        }

        clearBtn.gameObject.SetActive(true);
    }

}
