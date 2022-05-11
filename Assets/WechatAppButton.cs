using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WechatAppButton : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        OnDialogueConditionChanged();
        EventPool.OptIn("dialogueConditionChanged", OnDialogueConditionChanged);
    }

    void OnDialogueConditionChanged()
    {
        if (WechatManager.Instance.hasAnyWechatUnfinished())
        {
            GetComponent<AppButton>().showRedDot();
            return;
        }

        GetComponent<AppButton>().hideRedDot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
