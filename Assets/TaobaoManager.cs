using Pool;
using Sinbad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TaobaoItemInfo
{
    public string name;
    public string displayName;
    public string description;
    public int maxLevel;
    public int costBase;
    public float costIncrease;
    public float effect;
    public int locked;


}
public class TaobaoManager : Singleton<TaobaoManager>
{
    [HideInInspector]
    public List<TaobaoItemInfo> unlockedItems = new List<TaobaoItemInfo>();
    //[HideInInspector]
    //public List<TaobaoItemInfo> lockedItems = new List<TaobaoItemInfo>();
    [HideInInspector]
    public List<TaobaoItemInfo> allItems = new List<TaobaoItemInfo>();
    [HideInInspector]
    public Dictionary<string, int> itemLevelByName = new Dictionary<string, int>();
    Dictionary<string, TaobaoItemInfo> itemInfoByName = new Dictionary<string, TaobaoItemInfo>();


    // Start is called before the first frame update
    void Start()
    {

        allItems = CsvUtil.LoadObjects<TaobaoItemInfo>("taobaoSellItem");
        foreach (var keyInfo in allItems)
        {
            itemLevelByName[keyInfo.name] = 0;
            itemInfoByName[keyInfo.name] = keyInfo;
            if(keyInfo.locked == 0)
            {

                unlockedItems.Add(keyInfo);
            }
        }

    }

    //public List<BaikeEntryInfo> unlockedBaikeEntries()
    //{
    //    var res = new List<BaikeEntryInfo>();
    //    foreach (var key in unlockedKeywords)
    //    {
    //        res.Add(keywordInfoByName[key]);
    //    }
    //    return res;
    //}
    public int itemCost(string name)
    {
        if (!itemInfoByName.ContainsKey(name))
        {
            Debug.LogError("item does not existed");
        }
        var item = itemInfoByName[name];
        var level = itemLevelByName[name];
        return (int)(item.costBase * (Mathf.Pow(item.costIncrease, level)));
    }

    public float fansIncreasedPerSecond()
    {
        var key = "autoFansIncrease";
        var level = itemLevelByName[key] * itemInfoByName[key].effect;
        return level;
    }

    public int weiboRewardMultiplier()
    {
        var key = "weiboOtherAccount";
        var level = 1+itemLevelByName[key] * itemInfoByName[key].effect;
        return (int)level;
    }

    public bool tryBuyItem(string name)
    {
        if (ResourceManager.Instance.tryConsumeMoney(itemCost(name)))
        {
            levelUpItem(name);
            return true;
        }
        else
        {
            //show popup
        }
        return false;
    }
    public void levelUpItem(string keyword)
    {
        //GameObject.FindObjectOfType<WeiboCenterPopup>().addMessage(keyword + "+1");
        itemLevelByName[keyword]++;
        //if (keywordCountByName[keyword] >= keywordInfoByName[keyword].unlockCount)
        {
            //EventPool.Trigger("showBaike");
            //DialogueLua.SetVariable("keywordsCount", unlockedKeywords.Count);

            //Sequencer.Message("keywordsCount_1");
            //EventPool.Trigger("dialogueConditionChanged");
            //GameObject.FindObjectOfType<WeiboCenterPopup>().addMessage("解锁" + keyword);
            //EventPool.Trigger("addOption", keyword);
            //EventPool.Trigger("baikeEntryChanged");
        }

    }
}
