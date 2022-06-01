using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCircle : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Rotate(Vector3.forward*0.3f);
    }

    public void SpawnCircle(GameObject star)
    {
        gameObject.SetActive(true);
        transform.localPosition = star.transform.localPosition;
        transform.LookAt(new Vector3(0, 0, 0));
    }

    public void RemoveCircle()
    {
        gameObject.SetActive(false);
    }
}
