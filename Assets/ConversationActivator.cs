using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationActivator : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        var converstaionName = DialogueLua.GetVariable("Conversation").AsString;
        DialogueManager.StartConversation(converstaionName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
