using PixelCrushers;
using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationActivator : MonoBehaviour
{

    private void Awake()
    {
        SaveSystem.saveDataApplied += OnSaveDataApplied;
    }

    private void OnSaveDataApplied()
    {
        SaveSystem.saveDataApplied -= OnSaveDataApplied;

        if (DialogueManager.isConversationActive) return;
        var conversationTitle = !string.IsNullOrEmpty(SMSDialogueUI.conversationVariableOverride)
            ? SMSDialogueUI.conversationVariableOverride
            : DialogueLua.GetVariable("Conversation").asString;
        if (!string.IsNullOrEmpty(conversationTitle))
        {
            Debug.Log("Dialogue System: Starting conversation '" + conversationTitle + "' from beginning");
            DialogueManager.StartConversation(conversationTitle);
        }
    }
    //// Start is called before the first frame update
    //void Start()
    //{
    //    var converstaionName = DialogueLua.GetVariable("Conversation").AsString;
    //    DialogueManager.StartConversation(converstaionName);
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
