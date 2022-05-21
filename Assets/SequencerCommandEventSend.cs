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
            var arg1 = GetParameter(1);
            if (arg1 != null && arg1.Length>0)
            {

                Pool.EventPool.Trigger<string>(message,arg1);
            }
            else
            {

                Pool.EventPool.Trigger(message);
            }

            Stop();
        }

        void Update()
        {
        }

        void OnDestroy()
        {

        }
    }
}