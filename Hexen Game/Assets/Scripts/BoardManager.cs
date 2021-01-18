using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private GameObject _hexagon;
    [SerializeField] private int _amountOfEnemies = 8;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _gameManager;
    private float __hexagonXOffset = 0.57f;
    private float __hexagonYOffset = 0.5f;

    private float _currentXOffset = 0;
    private float _currentYOffset = 0;
    private int _minRows = 4;
    private int _maxRows = 7;
    private int _tileRow;
    private int _tileNumber;
    private int _currentAmountOfRows = 4;
    private int _modifier = 1;
    private float _indent = 0.29f;
    List<GameObject> _tiles;
    private GameObject _tilePlayerIsOn;
    private GameObject  _player;
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
            _tileRow += 1;
            _tileNumber = 0;
            _currentXOffset += (_maxRows - _currentAmountOfRows) * __hexagonXOffset;
            if(_currentAmountOfRows > 5) {
                _currentXOffset += __hexagonXOffset;
            }
            
            for (int i = 0; i < _currentAmountOfRows; i++)
            {
                _tiles.Add(Instantiate(_hexagon,new Vector3(_currentXOffset, _currentYOffset,0), _hexagon.transform.rotation));
                _currentXOffset += __hexagonXOffset;
                _tileNumber += 1;
                _tiles[_tiles.Count-1].GetComponent<Tile>().setPosition(_tileRow,_tileNumber);
                _tiles[_tiles.Count-1].GetComponent<Tile>().setBoardManager(this.gameObject);
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
        _tiles[_tiles.Count/2].GetComponent<Tile>().setOccupied(true);
        _player = Instantiate(_playerPrefab, _tiles[_tiles.Count/2].transform.position + new Vector3(0,0,-0.19f), _playerPrefab.transform.rotation);
        _tiles[_tiles.Count/2].GetComponent<Tile>().SetHasPlayer(true);
        _tilePlayerIsOn = _tiles[_tiles.Count/2];
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
            spawnOnTile(position, _enemy);
        }

    }

    void spawnOnTile(int tileNmbr, GameObject item) {
        _tiles[tileNmbr].GetComponent<Tile>().setOccupied(true);
        GameObject enemy = Instantiate(item, _tiles[tileNmbr].transform.position + new Vector3(0,0,-0.19f), item.transform.rotation);
        enemy.GetComponent<Enemy>().setNumber(_tiles[tileNmbr].GetComponent<Tile>().getNumber());
        enemy.GetComponent<Enemy>().setRow(_tiles[tileNmbr].GetComponent<Tile>().getRow());
        _gameManager.GetComponent<EnemyManager>().addEnemy(enemy);
        _tiles[tileNmbr].GetComponent<Tile>().toggleHighlighted();
    }

    GameObject findTile(int row, int number) {
        for (int i = 0; i < _tiles.Count; i++)
        {
            if(_tiles[i].GetComponent<Tile>().getNumber() == number && _tiles[i].GetComponent<Tile>().getRow() == row) {
                return(_tiles[i]);
            }
        }
        return gameObject;
    }

    public List<GameObject> findSurroundingTiles(GameObject tile) {
        List<GameObject> tiles = new List<GameObject>();

        for (int i = 0; i < _tiles.Count; i++)
        {
            if(Mathf.Abs(tile.GetComponent<Tile>().getNumber() - _tiles[i].GetComponent<Tile>().getNumber()) <= 1 && Mathf.Abs(tile.GetComponent<Tile>().getRow() - _tiles[i].GetComponent<Tile>().getRow()) <= 1) {
                if(_tiles[i].GetComponent<Tile>().getOccupied() == false)
                    tiles.Add(_tiles[i]);
            }
        }
        return tiles;
    }

        public List<GameObject> findSurroundingTilesv2(Vector2 tilev2) {
        List<GameObject> tiles = new List<GameObject>();

        for (int i = 0; i < _tiles.Count; i++)
        {
            if(Mathf.Abs(tilev2.x - _tiles[i].GetComponent<Tile>().getNumber()) <= 1 && Mathf.Abs(tilev2.y - _tiles[i].GetComponent<Tile>().getRow()) <= 1) {
                if(_tiles[i].GetComponent<Tile>().getOccupied() == false)
                    tiles.Add(_tiles[i]);
            }
        }
        return tiles;
    }

    public GameObject getPlayer() {
        return _playerPrefab;
    }

    public GameObject getPlayerTile() {
        return _tilePlayerIsOn;
    }

    public void setPlayerTile(GameObject tile) {
        _tilePlayerIsOn.GetComponent<Tile>().setOccupied(false);
        _tilePlayerIsOn.GetComponent<Tile>().SetHasPlayer(false);
        _player.transform.position = tile.transform.position + new Vector3(0,0,-0.19f); 
        tile.GetComponent<Tile>().setOccupied(true);
        tile.GetComponent<Tile>().SetHasPlayer(true);
        _tilePlayerIsOn = tile;
    }


}


