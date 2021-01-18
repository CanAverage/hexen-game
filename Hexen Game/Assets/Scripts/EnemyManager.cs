using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] private GameObject _gameManager;
    [SerializeField] private List<GameObject> _enemies;
    private GameObject _playerTile;

    bool test = true;
    // Start is called before the first frame update
    void Start()
    {
        _enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(test) {
            Move_Enemies();
            test = !test;
        } 
    }

    void Move_Enemies() {
        _playerTile = _gameManager.GetComponent<BoardManager>().getPlayerTile();
        List<GameObject> freetiles = new List<GameObject>();
        freetiles = _gameManager.GetComponent<BoardManager>().findSurroundingTiles(_playerTile);

        foreach (var tile in freetiles)
        {
            foreach (var Enemy in _enemies)
            {
                if(Enemy.GetComponent<Enemy>().getNumber() == tile.GetComponent<Tile>().getNumber() && Enemy.GetComponent<Enemy>().getNumber() == tile.GetComponent<Tile>().getNumber()) {
                    Enemy.GetComponent<Enemy>().setInactive();
                }
            }
            tile.GetComponent<Tile>().toggleHighlighted();
        }
        /*
        if(freetiles.Count > 1) {
            int x;
            int y;
            int f;
            int g;
            int h;
            foreach (var Enemy in _enemies)
            {
                if(Enemy.GetComponent<Enemy>().isActive() == true) {
                Vector2 Start;
                Vector2 target;
                List<Vector2> openList = new List<Vector2>();
                List<Vector2> closedList = new List<Vector2>();
                g = 0;
                openList.Add(new Vector2(Enemy.GetComponent<Enemy>().getNumber(), Enemy.GetComponent<Enemy>().getRow()));

                while (openList.Count > 0) {
                    
                    Vector2 lowest; //= openList.Min();
                    Vector2 current; //= openList.First();
                    closedList.Add(current);
                    openList.Remove(current);
                    List<GameObject> AdjacentSquareImport = new List<GameObject>();
                    List<Vector2> AdjacentSquares = new List<Vector2>();

                    AdjacentSquareImport = _gameManager.GetComponent<BoardManager>().findSurroundingTilesv2(current);
                    foreach (var square in AdjacentSquareImport)
                    {
                        AdjacentSquares.Add(new Vector2(square.GetComponent<Tile>().getNumber(), square.GetComponent<Tile>().getRow()));
                    }
                    foreach (var AdjacentSquare in AdjacentSquareImport)
                    {
                        
                    }
                    //if(openList.Count == 0 || closedList.First == target) {
                    //    break;
                    //}
                   
                }

                }
            }
        }
        */
    }

    public void addEnemy(GameObject Enemy) {
        _enemies.Add(Enemy);
    }

    static int ComputeHScore(int x, int y, int targetX, int targetY) {
        return Mathf.Abs(targetX - x) + Mathf.Abs(targetY - y);
    }
}
