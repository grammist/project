using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Hand : MonoBehaviour
{

    Card card;
    List<Card> lst = new List<Card>();
    GameUnit curPlayer;
    //bool updated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameUnit player in Deck.players) {
            if (player.selected) {
                curPlayer = player;
                switch (player.tag) {
                    case "Player0":
                        if(this.GetComponentsInChildren<Transform>(true).Length > 1) {
                            for (int i = 0; i < this.transform.childCount; i++) {
                                Destroy(this.transform.GetChild(i).gameObject);
                            }
                        }
                        foreach(Card card in Deck.hand0) {
                            Instantiate(card, this.transform);
                        }
                        break;
                    case "Player1":
                    if(this.GetComponentsInChildren<Transform>(true).Length > 1) {
                            for (int i = 0; i < this.transform.childCount; i++) {
                                Destroy(this.transform.GetChild(i).gameObject);
                            }
                        }
                        foreach(Card card in Deck.hand1) {
                            Instantiate(card, this.transform);
                        }
                        break;
                    case "Player2":
                    if(this.GetComponentsInChildren<Transform>(true).Length > 1) {
                            for (int i = 0; i < this.transform.childCount; i++) {
                                Destroy(this.transform.GetChild(i).gameObject);
                            }
                        }
                        foreach(Card card in Deck.hand2) {
                            Instantiate(card, this.transform);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
