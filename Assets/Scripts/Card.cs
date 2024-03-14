using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{

    public TextMeshProUGUI name;
    public TextMeshProUGUI type;
    public TextMeshProUGUI effect;
    public TextMeshProUGUI description;
    public Image img;
    
    public int id;
    public string cname;
    public string ctype;
    public string ceffect;
    public string cdescription;

    //public Cards card;

    // Start is called before the first frame update
    void Start()
    {
        name.text = cname;
        type.text = ctype;
        effect.text = ceffect;
        description.text = cdescription;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setId(int id) {id = id;}
    public void setName(string name) {cname = name;}
    public void setType(string type) {ctype = type;}
    public void setEffect(string effect) {ceffect = effect;}
    public void setDescription(string description) {cdescription = description;}
    public void setImg(){}

}
