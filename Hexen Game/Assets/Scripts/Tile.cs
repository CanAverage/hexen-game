using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    [SerializeField] private bool _occupied = false;
    [SerializeField] private bool _hasPlayer = false;

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
}
