using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeiboCenterPopup : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
    TMP_Text text;
    List<string> stringList = new List<string>();

    [SerializeField]
    float textShowTime;
    float textTimer;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        panel.SetActive(false);
    }
    public void addMessage(string t)
    {
        stringList.Add(t);
    }

    // Update is called once per frame
    void Update()
    {
        textTimer += Time.deltaTime;
        if (stringList.Count > 0)
        {
            if (textTimer >= textShowTime)
            {
                panel.gameObject.SetActive(true);
                text.text = stringList[0];
                stringList.RemoveAt(0);
                textTimer = 0;
            }
        }
        else
        {

            if (textTimer >= textShowTime)
            {
                panel.gameObject.SetActive(false);
            }
        }
    }
}
