using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    public void OnBeginDrag(PointerEventData data) {
        //Debug.Log("Picked something up");
    }

    public void OnDrop(PointerEventData data) {
        //Debug.Log("Dropped something off");
    }

    public void OnDrag(PointerEventData data) {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;

            Debug.Log(objectHit.name);
        }
    }

    public void OnEndDrag(PointerEventData data) {

    }
}
