using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    private Vector3 _position;
    private Transform _lastObjHit;
    [SerializeField] private GameObject _gameManager;
    [SerializeField] int _cardID;
    void Start() {
        _position = this.transform.position;
        _lastObjHit = this.transform;
    }
    public void OnBeginDrag(PointerEventData data) {
        Debug.Log("Picked something up");
    }

    public void OnDrop(PointerEventData data) {
        Debug.Log("Dropped something off");
    }

    public void OnDrag(PointerEventData data) {
        //Debug.Log("Dragging");
        this.transform.position = data.position;
        int layer_mask = LayerMask.GetMask("Hexagons");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit,Mathf.Infinity, layer_mask)) {
            Transform objectHit = hit.transform;


                if(objectHit.position != _lastObjHit.position) {
                    _lastObjHit = objectHit;
                }
            
        }
        }


    

    public void OnEndDrag(PointerEventData data) {
        Debug.Log("Stopping");
        this.transform.position = _position;

            switch(_cardID) {
            case 0:
            break;
            case 1:
            break;
            case 2:
            break;
            case 3:
            Debug.Log(_lastObjHit.gameObject.GetComponent<Tile>().getOccupied());
                if(_lastObjHit.gameObject.GetComponent<Tile>().getOccupied() == false) {
                    _gameManager.GetComponent<BoardManager>().setPlayerTile(_lastObjHit.gameObject);
                }
            break;
            }
            if(_gameManager.GetComponent<DeckManager>().isCardLeft() == true) {
                _cardID = _gameManager.GetComponent<DeckManager>().getCardID();
                this.gameObject.GetComponent<RawImage>().texture = _gameManager.GetComponent<DeckManager>().getCard();
            } else {
                Destroy(this.gameObject);
            }
    }
    public void setId(int id) {
        _cardID = id;
    }
}