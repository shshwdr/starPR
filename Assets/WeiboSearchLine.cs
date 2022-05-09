using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Pool;

public class WeiboSearchLine : MonoBehaviour
{
    TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponentInChildren<TMP_Dropdown>();
        dropdown.onValueChanged.AddListener(onValueChanged);
        EventPool.OptIn<string>("addOption", addOption);

        foreach(var key in WeiboKeywordsManager.Instance.unlockedKeywords)
        {
            addOption(key);
        }
    }

    void addOption(string ad)
    {
        dropdown.AddOptions(new List<string>(){ad });
    }

    void onValueChanged(int i)
    {
        var newValue = dropdown.options[i].text;
        GameObject.FindObjectOfType<WeiboContentsView>().updateKeyWords(newValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
