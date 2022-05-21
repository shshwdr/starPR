using PixelCrushers.DialogueSystem;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WechatManager : Singleton<WechatManager>
{
    List<string> unlockedDialogue = new List<string>() { "boss" };
    // Start is called before the first frame update
    void Start()
    {

        EventPool.OptIn<string>("unlockDialogue", unlockDialogue);
    }

    public List<string> UnlockedDialogues { get { return unlockedDialogue; } }
    public void unlockDialogue(string dia)
    {
        unlockedDialogue.Add(dia);
    }

    public bool hasAnyWechatUnfinished()
    {
        //if is in dialogue, ignore current dialogue
        foreach(var n in unlockedDialogue)
        {
            if (hasMoreConversation(n))
            {
                return true;
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            unlockDialogue("fans_1");
        }
    }

    bool hasMoreConversation(string conversationName)
    {
        var entry = getLastEntry(conversationName);
        if (entry == null)
        {
            return true;
        }
        var model = new ConversationModel(DialogueManager.masterDatabase, DialogueManager.masterDatabase.GetConversation(entry.conversationID).Title, null, null, false, null);
        var state = model.GetState(entry, true);
        var isThereMore = state.hasAnyResponses;
        return isThereMore;
    }

    DialogueEntry getLastEntry(string conversationName)
    {
        var s = DialogueLua.GetVariable("DialogueEntryRecords_" + conversationName).asString;
        if (s == "nil")
        {
            return null;
        }
        string[] ints = s.Split(';');
        if (ints.Length - 3 < 0)
        {
            return null;
        }
        int conversationID = Tools.StringToInt(ints[ints.Length - 3]);
        int entryID = Tools.StringToInt(ints[ints.Length - 2]);
        DialogueEntry entry = DialogueManager.masterDatabase.GetDialogueEntry(conversationID, entryID);
        return entry;
    }
}
