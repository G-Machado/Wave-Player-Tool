using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Malee;

[System.Serializable]
[CreateAssetMenu(menuName = "TimeLinePlayer/TimeLine Object/Wave")]
public class TimeLine_Wave : TimeLine_Object
{
    [System.Serializable]
    public class TimeLineList : ReorderableArray<TimeLine_Object>{
    }

    [Header("Sequencial Timeline Objects")]
    [Reorderable]
    public TimeLineList TimeLine;

    public override bool Act(TimeLinePlayer player)
    {
        player.buffer_Remove(this);

        if(TimeLine.Length == 0)
        {
            Debug.LogError("TimeLineObject Wave does't have any TimeLineObject to play!");
            return true;
        }

        player.buffer_Add(TimeLine.ToArray());

        return true;
    }

}
