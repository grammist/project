using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    GameCell originCell; //GameObject chnaged to GameCell
    int col = 41;
    int row = 51;
    int offset = 2;
    float cellr = (float) Math.Sqrt(3);
    float gaph = (float) (0.2);
    float gapv = (float)(0.1 * Math.Sqrt(3));
    int endCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        originCell = Resources.Load<GameCell>("cell Variant");
        for (int i = 0; i < row; i++) {
            offset = offset % 2;
            for (int j = 0; j < col; j++) {
                GameCell cloneCell = Instantiate(originCell);
                cloneCell.transform.SetParent(transform);
                cloneCell.transform.position = Vector3.right * (2 * (float)cellr * j + ((cellr + gaph / 2) * offset)) + Vector3.forward * ((float)3 * i)
                    + Vector3.right * gaph * j + Vector3.forward * gapv * i;
                cloneCell.setX(col - j);
                cloneCell.setY(i + 1);
            }
            offset++;
        }
        Deck.testDeck();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameUnit p in Deck.players) {
            if ((int)p.curState == 2) {
                endCount++;
            }
        }
        if(endCount == 3) {
            Phase.resetPhase();
            foreach (GameUnit p in Deck.players) {
                p.resetPhase();
            }
            
        }
        endCount = 0;
    }

    void LateUpdate() {
        
    }
}
