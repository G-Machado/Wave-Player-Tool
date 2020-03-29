using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "TimeLinePlayer/TimeLine Object/Delay")]
public class TimeLine_Delay : TimeLine_Object
{
    [Header("Delay time")]
    [Tooltip("The amount of time that this object delays the timeline")]
    public float delay = 0;

    public override bool Act(TimeLinePlayer player)
    {
        return player.time - player.lastActionTime > delay;
    }

}
