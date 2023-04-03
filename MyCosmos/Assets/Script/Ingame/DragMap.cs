using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragMap : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool isDragging = false;
    
    private Vector2 delta = Vector3.zero;
    private float canvasWidth;
    private float positionRange;

    void Start()
    {
        canvasWidth = GameObject.Find("MapCanvas").GetComponent<RectTransform>().rect.width;
        positionRange = 640 - (canvasWidth/2);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        delta = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;
        
        float posX = transform.localPosition.x + eventData.delta.x;
        float posY = transform.localPosition.y;

        if(posX<-positionRange) transform.localPosition = new Vector3(-positionRange, posY, 0);
        else if(posX>positionRange) transform.localPosition = new Vector3(positionRange, posY, 0);
        else transform.localPosition = new Vector3(posX, posY, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
    }
}
