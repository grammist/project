using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Zoom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float zoomSize;

    public void OnPointerEnter(PointerEventData pointerEventData) {
        Debug.Log(transform.localScale);
        transform.localScale = new Vector3(zoomSize, zoomSize, 1.0f);
        Debug.Log(transform.localScale);
    }

    public void OnPointerExit(PointerEventData pointerEventData) {
        transform.localScale = Vector3.one;
    }
}
