using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private GameObject hexagon;
    private float hexagonXOffset = 0.29f;
    private float hexagonYOffset = 0.52f;

    [SerializeField]private int minRows = 3;
    [SerializeField]private int maxRows = 6;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(hexagon)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
