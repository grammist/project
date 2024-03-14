using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCell : MonoBehaviour
{
    Material selfMat;
    [SerializeField]
    Color dark;
    [SerializeField]
    Color light;
    [SerializeField]
    Color grey;
    Color originCol;
    int cordx;
    int cordy;
    bool target = false;
    bool resource = false;
    bool revive = false;
    GameUnit cha;

    // Start is called before the first frame update
    void Start()
    {
        selfMat = GetComponent<MeshRenderer>().material;
        selfMat.color = dark;
        if ((cordx == 21 && cordy == 26)) { 
            revive = true;
            cha = Instantiate(Resources.Load<GameUnit>("Unit Variant"));
            cha.transform.parent = this.transform;
            cha.GetComponent<GameUnit>().setCell(this);
            //cha.transform.LookAt(this.transform.position);
            cha.SetTag("Player0");
            Deck.players.Add(cha);
        }
        if ((cordx == 20 && cordy == 26)) { 
            revive = true;
            cha = Instantiate(Resources.Load<GameUnit>("Unit Variant"));
            cha.transform.parent = this.transform;
            cha.GetComponent<GameUnit>().setCell(this);
            //cha.transform.LookAt(this.transform.position);
            cha.SetTag("Player1");
            Deck.players.Add(cha);
        }

        if ((cordx == 22 && cordy == 26)) { 
            revive = true;
            cha = Instantiate(Resources.Load<GameUnit>("Unit Variant"));
            cha.transform.parent = this.transform;
            cha.GetComponent<GameUnit>().setCell(this);
            //cha.transform.LookAt(this.transform.position);
            cha.SetTag("Player2");
            Deck.players.Add(cha);
        }
        if (inRange(15, 26, 4, cordx, cordy) || inRange(27, 26, 4, cordx, cordy)) {
            setTarget();
            selfMat.color = grey;
        }
        
        
        originCol = selfMat.color;
        
    }

    public void setCha(GameUnit gu) {
        cha = gu;
    }

    public bool getRevive() {
        return revive;
    }

    public GameUnit getUnit() {
        return cha;
    }

    public void High() { selfMat.color = light; }

    public void Normal() { selfMat.color = originCol; }

    public void setX(int x) {
        cordx = x;
    }

    public void setY(int y) {
        cordy = y;
    }

    public int getX() {
        return cordx;
    }

    public int getY() {
        return cordy;
    }

    public void setTarget() {
        target = true;
    }

    public bool getTarget() {
        return target;
    }

    public Material getMat() {
        return this.selfMat;
    }

    public void SetTag(string tag)
    {
        if (!UnityEditorInternal.InternalEditorUtility.tags.Equals(tag))
        {
            UnityEditorInternal.InternalEditorUtility.AddTag(tag);
        }
        this.tag = tag;
    }

    public List<int[]> getRange(int x, int y, int ran) { //A single cell is 0
        //int num = Math.Pow(ran, 2) * 3 + 1;
        int left = x - ran;
        int right = x + ran;
        int up = y - ran;
        int down = y + ran;
        List<int[]> inran = new List<int[]>();
        if (y % 2 == 0) {
            int leftoff = -1;
            int rightoff = 0;
            for (int i = y; i >= up; i--) {
                if (i % 2 == 0)
                {
                    leftoff++;
                }
                else {
                    rightoff--;
                }
                for (int j = left + leftoff; j <= right + rightoff; j++) {
                    inran.Add(new int[] { j, i });
                }
            }
            leftoff = -1;
            rightoff = 0;
            for (int i = y; i <= down; i++) {
                if (i % 2 == 0)
                {
                    leftoff++;
                }
                else
                {
                    rightoff--;
                }
                for (int j = left + leftoff; j <= right + rightoff; j++) {
                    inran.Add(new int[] { j, i });
                }
            } 
        }
        else
        {
            int leftoff = 0;
            int rightoff = 1;
            for (int i = y; i >= up; i--)
            {
                if (i % 2 == 0)
                {
                    leftoff++;
                }
                else
                {
                    rightoff--;
                }
                for (int j = left + leftoff; j <= right + rightoff; j++)
                {
                    inran.Add(new int[] { j, i });
                }
            }
            leftoff = 0;
            rightoff = 1;
            for (int i = y; i <= down; i++)
            {
                if (i % 2 == 0)
                {
                    leftoff++;
                }
                else
                {
                    rightoff--;
                }
                for (int j = left + leftoff; j <= right + rightoff; j++)
                {
                    inran.Add(new int[] { j, i });
                }
            }
        }
        return inran;
    }

    public bool inRange(int x, int y, int r, int X, int Y) {
        foreach (int[] i in getRange(x, y, r)) {
            if (X == i[0] && Y == i[1]) {
                return true;
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
