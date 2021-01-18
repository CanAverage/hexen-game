using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private int row;
    private int number;

    private bool inactive;

    public int getRow() {
        return row;
    }


    public int getNumber() {
        return number;
    }

    public void setNumber(int i) {
        number = i;
    }


    public void setRow(int i) {
        row = i;
    }

    public void setInactive() {
        inactive = true;
    }

    public void setActive() {
        inactive = false;
    }


    public bool isActive() {
        return inactive;
    }
}
