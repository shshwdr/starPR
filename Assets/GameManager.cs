using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            Sequencer.Message("FansCount_10");
            Sequencer.Message("FansCount_100");
            DialogueManager.PlaySequence("SendMessage(FansCount_10, , everyone)");
        }
    }
}
