using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private List<Texture> _cards;
    [SerializeField]private GameObject _card1;
    [SerializeField]private GameObject _card2;
    [SerializeField]private GameObject _card3;
    [SerializeField]private GameObject _card4;
    [SerializeField]private GameObject _card5;
    private List<int> _deck;
    int amountOfCards = 30;
    void Start()
    {
         _deck = new List<int>();
        for (int i = 0; i < amountOfCards; i++)
        {
            _deck.Add(Random.Range(0, _cards.Count));
        }

        _card1.GetComponent<RawImage>().texture = _cards[_deck[0]];
        _card1.GetComponent<Card>().setId(_deck[0]);
        _card2.GetComponent<RawImage>().texture = _cards[_deck[1]];
        _card2.GetComponent<Card>().setId(_deck[1]);
        _card3.GetComponent<RawImage>().texture = _cards[_deck[2]];
        _card3.GetComponent<Card>().setId(_deck[2]);
        _card4.GetComponent<RawImage>().texture = _cards[_deck[3]];
        _card4.GetComponent<Card>().setId(_deck[3]);
        _card5.GetComponent<RawImage>().texture = _cards[_deck[4]];
        _card5.GetComponent<Card>().setId(_deck[4]);
        _deck.Remove(0);
        _deck.Remove(0);
        _deck.Remove(0);
        _deck.Remove(0);
        _deck.Remove(0);
    }


    public bool isCardLeft() {
        if(_deck.Count > 1) {
            return true;
        } else {
            return false;
        }
    }

    public int getCardID() {
        return _deck[0];
    }
    public Texture getCard() {
        Texture card = _cards[_deck[0]];
        _deck.Remove(_deck[0]);
        return card;
        
    }
}
