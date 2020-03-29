using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Malee;

[CreateAssetMenu(menuName = "TimeLinePlayer/TimeLine Object/Random Object")]
public class TimeLine_RandomObject : TimeLine_Object
{
    [System.Serializable]
    public class TimeLinesList : ReorderableArray<TimeLine_Object>{
    }

    [Header("         Random TimeLine Objects")]
    [Tooltip("This object randomlly selects a TimeLine Object inside it's list and add to TimeLinePlayer's buffer.")]
    [Reorderable]
    public TimeLinesList ObjectsList;

    public override bool Act(TimeLinePlayer player)
    {
        if(ObjectsList.Length == 0)
        {
            Debug.LogError("TimeLineObject Random Object doesn't have any object to choose from!");
            return true;
        }

        player.buffer_Remove(this);

        int rng = Random.Range(0, ObjectsList.Length);

        TimeLine_Object[] list = new TimeLine_Object[1];
        list[0] = ObjectsList[rng];

        player.buffer_Add(list);

        return true;
    }
}
