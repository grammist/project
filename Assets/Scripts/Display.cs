using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{

    Card card;
    float time;
    float timeDelay;
    bool clone = false;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        timeDelay = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Phase.display){
            show();
        }

    }

    public void show() {
        time += 1f * Time.deltaTime;
        if(Phase.curState == Phase.State.initialize){
            if(!clone){
                card = Instantiate(Deck.curCard, this.transform);
                clone = true;
            }
            if(time >= timeDelay) {
                Destroy(this.transform.GetChild(0).gameObject);
                time = 0;
                //Phase.next();
                clone = false;
                Phase.display = false;
            }

        }
    }


}
