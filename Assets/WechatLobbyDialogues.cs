using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WechatLobbyDialogues : MonoBehaviour
{
    [SerializeField]
    Transform dialoguesParent;
    [SerializeField]
    GameObject dialoguePrefab;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var dialogueName in WechatManager.Instance.UnlockedDialogues)
        {
            var go = Instantiate(dialoguePrefab, dialoguesParent);
            go.GetComponent<WechatChatPreview>().init(dialogueName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
