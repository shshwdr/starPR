using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WechatChatPreview : MonoBehaviour
{
    [SerializeField]
    TMP_Text previewLabel;
    [SerializeField]
    string conversationName;

    [SerializeField]
    GameObject newMessageObject;
    // Start is called before the first frame update
    void Start()
    {
        // var s = DialogueLua.GetVariable("DialogueEntryRecords").asString; // Assumes Use Conversation Variable is UNticked.
        // getLastSentence(s);
        StartCoroutine( loadLastSentence());
    }

    public void selectDialogue()
    {

        //DialogueLua.SetVariable("Conversation", "Adam");
        DialogueLua.SetVariable("Conversation", conversationName);
        PixelCrushers.SaveSystem.LoadScene("wechat dialogue");
        //Sequencer.Message("SetVariable(Conversation,Adam);LoadLevel(wechat dialogue)");
        //SceneManager.LoadScene("wechat dialogue");
        //Sequencer.Message("LoadLevel(wechat dialogue)");
        //StartCoroutine(test());
    }
    IEnumerator test()
    {
        yield return new WaitForSecondsRealtime(0.1f);

        SceneManager.LoadScene("wechat dialogue");
    }

    IEnumerator loadLastSentence()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        previewLabel.text = getLastSentence();
        //newMessageObject.SetActive(hasMoreConversation());
    }

    string getLastSentence()
    {
        var entry = getLastEntry();
        if (entry == null)
        {
            return "";
        }
        return entry.DialogueText;
    }

    DialogueEntry getLastEntry()
    {
        var s = DialogueLua.GetVariable("DialogueEntryRecords_" + conversationName).asString;
        if (s == "nil")
        {
            return null;
        }
        string[] ints = s.Split(';');
        if(ints.Length - 3 < 0)
        {
            return null;
        }
        int conversationID = Tools.StringToInt(ints[ints.Length - 3]);
        int entryID = Tools.StringToInt(ints[ints.Length - 2]);
        DialogueEntry entry = DialogueManager.masterDatabase.GetDialogueEntry(conversationID, entryID);
        return entry;
    }

    bool hasMoreConversation()
    {
        var entry = getLastEntry();
        if(entry == null)
        {
            return true;
        }
        var model = new ConversationModel(DialogueManager.masterDatabase, DialogueManager.masterDatabase.GetConversation(entry.conversationID).Title, null, null, false, null);
        var state = model.GetState(entry, true);
        var isThereMore = state.hasAnyResponses;
        return isThereMore;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
