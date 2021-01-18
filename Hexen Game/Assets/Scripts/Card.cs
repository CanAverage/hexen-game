using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    public void OnBeginDrag(PointerEventData data) {
        Debug.Log("Picked something up");
    }

    public void OnDrop(PointerEventData data) {
        Debug.Log("Dropped something off");
    }

    public void OnDrag(PointerEventData data) {

    }

    public void OnEndDrag(PointerEventData data) {

    }
}
