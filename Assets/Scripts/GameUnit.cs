using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour
{
    public enum State {
        takeAction,
        settleDown,
        makeAction,
    }

    public bool selected = false;
    GameCell curCell;
    Material selfMat;
    [SerializeField]
    Color hi;
    Color originCol;
    public State curState;
    

    

    // Start is called before the first frame update
    void Start()
    {
        curState = 0;
        selfMat = GetComponent<MeshRenderer>().material;
        originCol = selfMat.color;
    }

    public void setCell(GameCell cell) {
        transform.parent.GetComponent<GameCell>().setCha(null);
        transform.DetachChildren();
        curCell = cell;
        transform.parent = curCell.transform;
        curCell.setCha(this);
        transform.position = cell.transform.position + Vector3.up * 5;
    }


    public bool getSelected() {
        return selected;
    }

    public void draw(int num){
        for (int i = 0; i < num; i++) {
            switch(this.tag) {
                case "Player0":
                    Deck.draw(0);
                    break;
                case "Player1":
                    Deck.draw(1);
                    break;
                case "Player2":
                    Deck.draw(2);
                    break;
                default:
                    break;
            }
        }
    }

    public void changeSelect() {
        if (!selected) {
            selfMat.color = hi;
            selected = true;
            return;
        }
        selfMat.color = originCol;
        selected = false;
    }

    public void toSelect() {
        selfMat.color = hi;
            selected = true;
            return;
    }

    public void unSelect() {
        selfMat.color = originCol;
        selected = false;
        return;
    }



    public GameCell getCell() {
        GameCell gc = this.transform.parent.GetComponent<GameCell>();
        return gc;
    }

    public void SetTag(string tag) {
        if (!UnityEditorInternal.InternalEditorUtility.tags.Equals(tag)) {
            UnityEditorInternal.InternalEditorUtility.AddTag(tag);
        }
        this.tag = tag;
    }

    public void MoveTo(GameCell cell) {
        transform.parent.GetComponent<GameCell>().setCha(null);
        transform.DetachChildren();
        curCell = cell;
        transform.parent = curCell.transform;
        curCell.setCha(this);
        StartCoroutine(MoveCor(cell));
    }

    IEnumerator MoveCor(GameCell cell) {
        float workTime = 0;
        Vector3 originPos = transform.position;
        Vector3 desPos = cell.transform.position + Vector3.up * 5;

        while(true) {
            workTime += Time.deltaTime;
            Rotate(originPos, desPos, workTime);
            transform.position = Vector3.Lerp(originPos, desPos, workTime);
            if(workTime >= 1) {
                break;
            }
            yield return null;
        }
    }

    public void Rotate(Vector3 ori, Vector3 des, float time) {
        GameObject tmp = new GameObject();
        tmp.transform.position = ori;
        tmp.transform.LookAt(des);
        Quaternion oriRot = transform.rotation;
        Quaternion desRot = tmp.transform.rotation;
        Destroy(tmp);

        transform.rotation = Quaternion.Lerp(oriRot, desRot, time * 3);
    }

    public void retrieve() {
        switch(this.curState) {
            case State.settleDown:
                curState -= 1;
                break;
            case State.makeAction:
                curState -= 1;
                break;
            default:
                break;
        }
    }


    public void nextState() {
        if((int)curState != 2) {
            curState += 1;
        }
    }

    public int getState() {
        return (int)curState;
    }

    public void resetPhase(){
        curState = 0;
    }

    

    // Update is called once per frame
    void Update()
    {
        if((int)Phase.curState == 0) {
            draw(1);
            Phase.incre();
        }
    }

    
}
