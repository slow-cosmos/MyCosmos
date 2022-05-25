using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Screen.width==1200 && Screen.height==1600)
        {
            float initScale = transform.localScale.x;
            transform.localPosition = new Vector3(-0.08f, 2.3f, 0);
            transform.localScale = new Vector3(initScale * 1.33f, initScale * 1.33f, initScale * 1.33f);
        }
    }

}
