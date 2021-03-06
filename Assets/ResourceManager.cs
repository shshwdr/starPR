using PixelCrushers.DialogueSystem;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ResourceType { fans,money, hp}
public class ResourceManager : Singleton<ResourceManager>
{

    Dictionary<ResourceType, float> resources = new Dictionary<ResourceType, float>();

    public int getFansCount()
    {
        return Mathf.FloorToInt(resources[ResourceType.fans]);
    }

    public void addFansCountFromWeibo(float addCount)
    {
        addFansCount(addCount * TaobaoManager.Instance.weiboRewardMultiplier());
    }

    public void addFansCount(float addCount)
    {
        resources[ResourceType.fans] += addCount;
        EventPool.Trigger("updateFans");
        DialogueLua.SetVariable("fansCount", resources[ResourceType.fans]);
        //todo not call everytime
        if (resources[ResourceType.fans] >= 105)
        {

            Sequencer.Message("fansCount_1");
        }
        //todo not call everytime
        EventPool.Trigger("dialogueConditionChanged");
    }
    public bool tryConsumeHP(float value)
    {
        if (resources[ResourceType.hp] >= value)
        {

            consumeHP(value);
            return true;
        }
        return false;
    }
    public void consumeHP(float value)
    {

        resources[ResourceType.hp] -= value;
        EventPool.Trigger("updateHP");
    }

    public int getMoney()
    {

        return Mathf.FloorToInt(resources[ResourceType.money]);
    }

    public bool tryConsumeMoney(int value)
    {
        if (resources[ResourceType.money] >= value)
        {
            changeMoney(-value);
            return true;
        }
        return false;
    }

    public void changeMoney(float value)
    {
        resources[ResourceType.money] += value;
        EventPool.Trigger("updateMoney");
    }

    public int getHP()
    {
        return Mathf.FloorToInt(resources[ResourceType.hp]);
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (ResourceType type in System.Enum.GetValues(typeof(ResourceType)))
        {
            resources[type] = 100;
        }
        EventPool.Trigger("updateFans");
        EventPool.Trigger("updateHP");
    }
    int moneyChangePerTick = 1;
    int timePerTick = 1;
    float currentTime = 0;
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timePerTick)
        {
            currentTime = 0;
            changeMoney(moneyChangePerTick);
            addFansCount(TaobaoManager.Instance.fansIncreasedPerSecond());
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            addFansCountFromWeibo(1);
        }
    }
}
