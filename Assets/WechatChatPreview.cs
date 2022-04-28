using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WechatChatPreview : MonoBehaviour
{
    [SerializeField]
    TMP_Text previewLabel;
    [SerializeField]
    string conversationName;
    // Start is called before the first frame update
    void Start()
    {
        // var s = DialogueLua.GetVariable("DialogueEntryRecords").asString; // Assumes Use Conversation Variable is UNticked.
        // getLastSentence(s);
        StartCoroutine( loadLastSentence());
    }

    IEnumerator loadLastSentence()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        previewLabel.text = getLastSentence();
    }

    string getLastSentence()
    {
        var s = DialogueLua.GetVariable("DialogueEntryRecords_"+ conversationName).asString; // Assumes Use Conversation Variable is UNticked.
        if (s== null)
        {
            return "";
        }
        string[] ints = s.Split(';');
        int conversationID = Tools.StringToInt(ints[ints.Length - 3]);
        int entryID = Tools.StringToInt(ints[ints.Length - 2]);
        DialogueEntry entry = DialogueManager.masterDatabase.GetDialogueEntry(conversationID, entryID);
        Debug.Log("Last sentence was: " + entry.DialogueText);
        return entry.DialogueText;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
