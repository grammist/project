using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase
{
    public enum State {
        initialize,
        decision,
        action,
        respond,
    }
    public static int initCount = 0;

    public static State curState;
    public static bool display = false;

    public Phase() {
        curState = State.initialize;
    }

    public static void next (){
        Debug.Log(2);
        curState += 1;
    }

    public static void incre() {
        Debug.Log(1);
        initCount ++;
        if(initCount == Deck.players.Count) {
            next();
            initCount = 0;
        }
    }

    public static void resetPhase() {
        curState = 0;
    }

}
