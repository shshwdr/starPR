// Copyright (c) Pixel Crushers. All rights reserved.

using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{

    /// <summary>
    /// Implements sequencer command: WaitForMessage(message), which waits
    /// until it receives OnSequencerMessage(message) for all specified messages.
    /// </summary>
    [AddComponentMenu("")] // Hide from menu.
    public class SequencerCommandWaitForValidCondition : SequencerCommand
    {

        private List<string> requiredMessages = new List<string>();

        public void Awake()
        {
            requiredMessages.AddRange(parameters);
            if (DialogueDebug.logInfo) Debug.Log(string.Format("{0}: Sequencer: WaitForMessage({1})", new System.Object[] { DialogueDebug.Prefix, GetParameters() }));
            requiredMessages.RemoveAll(x => string.IsNullOrEmpty(x));
            if (requiredMessages.Count == 0) Stop();
            if (hasMoreConversation())
            {
                Stop();

            }
        }

        //    DialogueEntry getLastEntry()
        //{
        //    //var s = DialogueLua.GetVariable("DialogueEntryRecords_" + SMSDialogueUI.conversationVariableOverride).asString;
        //    //if (s == "nil")
        //    //{
        //    //    return null;
        //    //}
        //    //string[] ints = s.Split(';');
        //    //if (ints.Length - 3 < 0)
        //    //{
        //    //    return null;
        //    //}
        //    //int conversationID = Tools.StringToInt(ints[ints.Length - 3]);
        //    //int entryID = Tools.StringToInt(ints[ints.Length - 2]);
        //    //DialogueEntry entry = DialogueManager.masterDatabase.GetDialogueEntry(conversationID, entryID);
        //    return entry;
        //}

        bool hasMoreConversation()
        {
            //DialogueManager.currentConversationState
            //var entry = getLastEntry();
            //if (entry == null)
            //{
            //    return false;
            //}
            //var model = new ConversationModel(DialogueManager.masterDatabase, DialogueManager.masterDatabase.GetConversation(entry.conversationID).Title, null, null, false, null);
            //var state = model.GetState(entry, true);
            var isThereMore = DialogueManager.CurrentConversationState.HasAnyResponses;
            return isThereMore;
        }

        public void OnSequencerMessage(string message)
        {
            if (requiredMessages.Contains(message))
            {
                if (DialogueDebug.logInfo) Debug.Log(string.Format("{0}: Sequencer: WaitForMessage({1}) received message", new System.Object[] { DialogueDebug.Prefix, message }));
                requiredMessages.RemoveAll(x => x == message);
                if (requiredMessages.Count == 0)
                {
                    Stop();
                }
            }
        }

    }

}
