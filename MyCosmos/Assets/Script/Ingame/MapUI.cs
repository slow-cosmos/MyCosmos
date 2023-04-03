using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour
{
    [SerializeField]
    Canvas mapCanvas;

    public void ZoomInMap()
    {
        mapCanvas.gameObject.SetActive(true);
    }

    public void ZoomOutMap()
    {
        bool isDragging = gameObject.GetComponent<DragMap>().isDragging;
        if(!isDragging) mapCanvas.gameObject.SetActive(false);
    }

}
