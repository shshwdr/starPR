using UnityEngine;
using PixelCrushers;

public class LobbyMenuButtons : MonoBehaviour
{

    public int saveSlot = 1;
    public UnityEngine.UI.Button continueButton;
    public UnityEngine.UI.Button restartButton;

    private static bool hasShownContinueButton = false;

    private void Start()
    {
        if (continueButton == null) Debug.LogWarning(GetType().Name + ": Continue Button isn't assigned.", this);
        if (restartButton == null) Debug.LogWarning(GetType().Name + ": Restart Button isn't assigned.", this);
        var hasSavedGame = SaveSystem.HasSavedGameInSlot(saveSlot);
        continueButton.gameObject.SetActive(hasSavedGame && !hasShownContinueButton);
        restartButton.gameObject.SetActive(hasSavedGame);
        hasShownContinueButton = true;
    }
}
