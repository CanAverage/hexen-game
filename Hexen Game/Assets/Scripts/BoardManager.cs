using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private GameObject _hexagon;
    [SerializeField] private int _amountOfEnemies = 8;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _player;
    private float __hexagonXOffset = 0.57f;
    private float __hexagonYOffset = 0.5f;

    private float _currentXOffset = 0;
    private float _currentYOffset = 0;
    private int _minRows = 4;
    private int _maxRows = 7;
    private int _currentAmountOfRows = 4;
    private int _modifier = 1;
    private float _indent = 0.29f;
    List<GameObject> _tiles;
    // Start is called before the first frame update
    void Start()
    {
        _tiles = new List<GameObject>();
        bool flipflop = true;
        while (_currentAmountOfRows > _minRows-1) {
            if(_currentAmountOfRows == _maxRows) {
                _modifier = -1;
            }
            _currentYOffset += __hexagonYOffset;
            _currentXOffset += (_maxRows - _currentAmountOfRows) * __hexagonXOffset;
            if(_currentAmountOfRows > 5) {
                _currentXOffset += __hexagonXOffset;
            }
            
            for (int i = 0; i < _currentAmountOfRows; i++)
            {
                _tiles.Add(Instantiate(_hexagon,new Vector3(_currentXOffset, _currentYOffset,0), _hexagon.transform.rotation));
                _currentXOffset += __hexagonXOffset;
            }
            if(flipflop) {
                flipflop = !flipflop;
                _currentXOffset = _indent;

            } else {
                flipflop = !flipflop;
                _currentXOffset = 0;
            }
            
            _currentAmountOfRows += _modifier;
            
        }
        for (int i = 0; i < _amountOfEnemies; i++)
        {
            bool isValid = false;
            int position = 0;
            while (!isValid) {
                position = Random.Range(0, _tiles.Count);
                if(_tiles[position].GetComponent<Tile>().getOccupied() == false) {
                    isValid = true;
                }
            }
            _tiles[position].GetComponent<Tile>().setOccupied(true);
            Instantiate(_enemy, _tiles[position].transform.position + new Vector3(0,0,-0.19f), _enemy.transform.rotation);
        }

    }



}
