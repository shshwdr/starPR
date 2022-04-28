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

    public void addFansCount(float addCount)
    {
        resources[ResourceType.fans] += addCount;
        EventPool.Trigger("updateFans");
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
        }
    }
}
