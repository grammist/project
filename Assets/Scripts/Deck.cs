using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public static List<GameUnit> players = new List<GameUnit>();

    public static List<Card> deck0 = new List<Card>();
    public static List<Card> hand0 = new List<Card>();
    public static List<Card> discard0 = new List<Card>();

    public static List<Card> deck1 = new List<Card>();
    public static List<Card> hand1 = new List<Card>();
    public static List<Card> discard1 = new List<Card>();

    public static List<Card> deck2 = new List<Card>();
    public static List<Card> hand2 = new List<Card>();
    public static List<Card> discard2 = new List<Card>();

    public static List<Card> cardusing0 = new List<Card>();
    public static List<Card> cardusing1 = new List<Card>();
    public static List<Card> cardusing2 = new List<Card>();

    public static Card curCard;

    public static void testDeck(){
        for (int i = 0; i < 30; i++) {
            Card card = Instantiate(Resources.Load<Card>("Card"));
            card.setId(i);
            card.setName(i + "");
            card.setType("Player0");
            card.setEffect("effect");
            card.setDescription(i + "");
            deck0.Add(card);
        }

        for (int i = 0; i < 30; i++) {
            Card card = Instantiate(Resources.Load<Card>("Card"));
            card.setId(i);
            card.setName(i + "");
            card.setType("Player1");
            card.setEffect("effect");
            card.setDescription(i + "");
            deck1.Add(card);
        }

        for (int i = 0; i < 30; i++) {
            Card card = Instantiate(Resources.Load<Card>("Card"));
            card.setId(i);
            card.setName(i + "");
            card.setType("Player2");
            card.setEffect("effect");
            card.setDescription(i + "");
            deck2.Add(card);
        }
    }

     public static void draw(int num) {
        switch(num){
            case 0:
                curCard = deck0[0];
                deck0.RemoveAt(0);
                Phase.display = true;
                hand0.Add(curCard);
                break;
            case 1:
                curCard = deck1[0];
                deck1.RemoveAt(0);
                Phase.display = true;
                hand1.Add(curCard);
                break;
            case 2:
                curCard = deck2[0];
                deck2.RemoveAt(0);
                Phase.display = true;
                hand2.Add(curCard);
                break;
            default:
                break;

        }
     }

}
