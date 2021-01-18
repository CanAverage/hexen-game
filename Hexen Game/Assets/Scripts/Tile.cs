using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    [SerializeField] private bool _occupied = false;
    [SerializeField] private bool _hasPlayer = false;
    [SerializeField] private Material _highlightedMaterial;
    [SerializeField] private Material _normalMaterial;
    bool isHighlighted = false;
    [SerializeField]private int _tileRow = 0;
    [SerializeField]private int _tileNumber = 0;

    void Start() {
        gameObject.GetComponent<Renderer>().material = _normalMaterial;
    }

    public void setOccupied(bool oc) {
        _occupied = oc;
    }

    public bool getOccupied() {
        return _occupied;
    }

    public void SetHasPlayer(bool hp) {
        _hasPlayer = hp;
    }

    public bool GetHasPlayer() {
        return _hasPlayer;
    }

    public void toggleHighlighted() {
        isHighlighted = !isHighlighted;

        if(isHighlighted) {
            gameObject.GetComponent<Renderer>().material = _highlightedMaterial;
        } else {
            gameObject.GetComponent<Renderer>().material = _normalMaterial;
        }
    }
    public void setPosition(int row, int number) {
        _tileNumber = number;
        _tileRow = row;
    }

    public int getRow() {
        return _tileRow;
    }

    public int getNumber() {
        return _tileNumber;
    }
}
