using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using DG.Tweening;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{

    /// <summary>
    /// Syntax: CamShake(shakeAmount, decreaseFactor, shakeDuration)
    /// </summary>
    public class SequencerCommandEventSend : SequencerCommand
    {

        

        public void Start()
        {
            var message = GetParameter(0);

            Pool.EventPool.Trigger(message);
        }

        void Update()
        {
        }

        void OnDestroy()
        {

        }
    }
}