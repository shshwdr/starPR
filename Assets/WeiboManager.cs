using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWeiboInfo
{
    public string userName;
    public string word;
    public int likes;
    public bool isPositive;
    public WeiboSentenceInfo weiboSentenceInfo;

}

public class WeiboManager : Singleton<WeiboManager>
{
    List<OneWeiboInfo> currentWeibos = new List<OneWeiboInfo>();
    public List<OneWeiboInfo> CurrentWeibos { get { return currentWeibos; } }

    public void removeWeibo(OneWeiboInfo info)
    {
        currentWeibos.Remove(info);
        EventPool.Trigger("updateWeibos");
    }
    public OneWeiboInfo getOneWeibo()
    {
        OneWeiboInfo res = new OneWeiboInfo();
        res.userName = WeiboNameSpawner.Instance.getName();
        var oneWeiboSentence = WeiboSpawner.Instance.getOneWeiboSentence();
        res.weiboSentenceInfo = oneWeiboSentence;
        res.word = oneWeiboSentence.words;
        res.isPositive = oneWeiboSentence.isPositive>0;
        res.likes = Random.Range(0, 10);
        return res;
    }

    public void spawnWeibos(int count)
    {
        for (int i = 0; i < count; i++)
        {
            currentWeibos.Add(getOneWeibo());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnWeibos(20);
        EventPool.Trigger("updateWeibos");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
