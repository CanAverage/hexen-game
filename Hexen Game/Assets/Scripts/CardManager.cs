using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    private Vector3 _position;

    [SerializeField] int _cardID;
    void Start() {
        _position = this.transform.position;
    }
    public void OnBeginDrag(PointerEventData data) {
        Debug.Log("Picked something up");
    }

    public void OnDrop(PointerEventData data) {
        Debug.Log("Dropped something off");
    }

    public void OnDrag(PointerEventData data) {
        Debug.Log("Dragging");
        this.transform.position = data.position;


        switch(_cardID) {
            case 0:
            break;
            case 1:
            break;
            case 2:
            break;
            case 3:
            break;
        }
    }

    public void OnEndDrag(PointerEventData data) {
        Debug.Log("Stopping");
        this.transform.position = _position;
    }

    public void setId(int id) {
        _cardID = id;
    }
}
