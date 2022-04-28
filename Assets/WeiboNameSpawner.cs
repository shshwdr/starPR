using Sinbad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeiboUsernameInfo
{
    public string word;
    public int isPrefix;
    public int isSurfix;
    public int isFullName;
    public int isFansOnly;
    public int isMarket;

}
public class WeiboNameSpawner : Singleton< WeiboNameSpawner>
{
    public List<string> allPrefix = new List<string>();
    public List<string> allFansPrefix = new List<string>();
    public List<string> allSurfix = new List<string>();
    public string getName()
    {
        return Utils.randomList(allPrefix) + Utils.randomList(allSurfix);
    }
    // Start is called before the first frame update
    void Start()
    {
        var weiboUsernameInfo = CsvUtil.LoadObjects<WeiboUsernameInfo>("weiboUserName");
        foreach(var info in weiboUsernameInfo)
        {
            if (info.isPrefix > 0)
            {
                allPrefix.Add(info.word);
            }
            if (info.isSurfix > 0)
            {
                allSurfix.Add(info.word);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
