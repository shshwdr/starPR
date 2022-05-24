using Pool;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaikeAppButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        EventPool.OptIn("baikeEntryChanged", OnBaikeEntryChanged);
    }

    private void OnBaikeEntryChanged()
    {

        GetComponent<AppButton>().showRedDot();
    }
    public void clickButton()
    {
        GetComponent<AppButton>().hideRedDot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
