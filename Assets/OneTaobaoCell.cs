using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OneTaobaoCell : MonoBehaviour
{
    [SerializeField]
    TMP_Text displayNameLabel;
    [SerializeField]
    TMP_Text descriptionLabel;
    [SerializeField]
    TMP_Text currentLevelLabel;
    [SerializeField]
    TMP_Text costLabel;
    [SerializeField]
    Button upgradeButton;
    TaobaoItemInfo taobaoInfo;
    public void init(TaobaoItemInfo _info)
    {
        taobaoInfo = _info;
        updateTaobaoCell();
        upgradeButton.onClick.AddListener(onUpgradeButton);
    }
    void onUpgradeButton()
    {
        if (TaobaoManager.Instance.tryBuyItem(taobaoInfo.name))
        {
            updateTaobaoCell();
        }

    }
    public void updateTaobaoCell()
    {
        var level = TaobaoManager.Instance.itemLevelByName[taobaoInfo.name];
        displayNameLabel.text = taobaoInfo.displayName;
        descriptionLabel.text = string.Format( taobaoInfo.description,taobaoInfo.effect*level);
        currentLevelLabel.text = level.ToString();
        costLabel.text = TaobaoManager.Instance.itemCost(taobaoInfo.name).ToString();

    }
}
