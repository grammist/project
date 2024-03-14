using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;



public class GameMouse : MonoBehaviour
{

    Transform curTarget;
    GameCell curCell;
    GameUnit curUnit;
    GameObject originUnit;
    GameUnit gu;


    // Start is called before the first frame update
    void Start()
    {
        //originUnit = Resources.Load<GameObject>("Unit Variant");
    }

    // Update is called once per frame
    void Update()
    {

        MouseDetect();
        MouseInput();
    }

    /*IEnumerator wait(int num){
        yield return new WaitForSeconds(num);
    }*/

    private void MouseInput() {
        if(Input.GetMouseButtonDown(0)) {
            if(curUnit != null) {
                if(gu != null && gu != curUnit) {
                    gu.unSelect();
                }
                gu = curUnit;
                gu.toSelect();
                return;
            }

            if(gu != null) {
                switch ((int)gu.getState())
                {
                    case 1:
                        if (curCell != null) {
                            if (curCell.inRange(gu.getCell().getX(), gu.getCell().getY(), 1, curCell.getX(), curCell.getY())) {
                                gu.MoveTo(curCell);
                            } else {
                                Debug.Log("Destination is out of range!");
                            }
                        }
                        break;
                    case 2:
                    
                    
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            }
        }

        
    }

    private void MouseDetect() {
        
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(mouseRay, out hitInfo))
        {
            curTarget = hitInfo.transform;
            GameCell cell = curTarget.GetComponent<GameCell>(); //cell is the cell that mouse hits, could be null
            if (cell != null) //the mouse in the battlefield
            {
                if (curCell != null && curCell != cell)
                {
                    curCell.Normal();
                }

                curCell = cell;
                curCell.High();
                
                /*if ((int)Phase.curState == 1) {
                    
                }*/
                curUnit = curCell.getUnit();
                
                
            }

            
        }
    }

    public void endPhase() {
        gu.nextState();
    }


    public void retrieve() {
        
        if(gu != null) {
            gu.retrieve();
        }
    }

}
