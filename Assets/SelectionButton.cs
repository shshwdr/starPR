using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionButton : MonoBehaviour
{

    ISelectable selectParent;
    [SerializeField]
    TMP_Text textLabel;
    int index;
    public void init(string t,ISelectable s,int index)
    {
        textLabel.text = t;
        selectParent = s;
        this.index = index;
        GetComponent<Button>().onClick.AddListener(delegate { s.select(this.index); });
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
