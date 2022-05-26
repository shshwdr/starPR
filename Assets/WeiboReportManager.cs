using Sinbad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeiboReportReasonInfo
{
    public string name;
    public string displayName;

}
public class WeiboReportManager : Singleton<WeiboReportManager>
{
    List<WeiboReportReasonInfo> reportReasons;
    void Start()
    {
        reportReasons = CsvUtil.LoadObjects<WeiboReportReasonInfo>("weiboReportRules");

    }
    public List<WeiboReportReasonInfo> getReportReasons()
    {
        return reportReasons;
    }
}
