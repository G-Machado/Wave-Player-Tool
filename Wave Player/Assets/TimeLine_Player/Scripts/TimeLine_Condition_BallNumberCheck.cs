using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Malee;

[CreateAssetMenu(menuName = "TimeLinePlayer/TimeLine Object/Condition_BallNumberCheck")]
public class TimeLine_Condition_BallNumberCheck : TimeLine_Object
{
    public enum condition
    {
        BIGGER_THAN,
        SMALLER_THAN
    }

    public condition checkCondition;
    public int numberCheck;

    [Header("TimeLine Consequence")]
    [Tooltip("The TimeLine_Object that will be called if condition is true")]
    [Reorderable]
    public TimeLine_Wave.TimeLineList if_TRUE;

    [Header("TimeLine Consequence")]
    [Tooltip("The TimeLine_Object that will be called if condition is false")]
    [Reorderable]
    public TimeLine_Wave.TimeLineList if_FALSE;

    public override bool Act(TimeLinePlayer player)
    {
        player.buffer_Remove(this);

        CircleCollider2D[] ballsList;

        ballsList = player.GetComponentsInChildren<CircleCollider2D>();

        if (checkCondition == condition.BIGGER_THAN)
        {
            if (ballsList.Length > numberCheck)
            {

                if (if_TRUE.Length == 0)
                    Debug.LogWarning("TimeLineObject Ball Check Condition doesn't have a 'if_TRUE' object. Condition will be ignored");
                else
                    player.buffer_Add(if_TRUE.ToArray());
    
                return true;
            }
        }else
        if (checkCondition == condition.SMALLER_THAN)
        {
            if (ballsList.Length < numberCheck)
            {
                if (if_TRUE.Length == 0)
                    Debug.LogWarning("TimeLineObject Ball Check Condition doesn't have a 'if_TRUE' object. Condition will be ignored");
                else
                {
                    player.buffer_Add(if_TRUE.ToArray());
                }

                return true;
            }
        }

        if (if_TRUE.Length == 0)
            Debug.LogWarning("TimeLineObject Ball Check Condition doesn't have a 'if_FALSE' object. Condition will be ignored");
        else
            player.buffer_Add(if_FALSE.ToArray());

        return true;
    }
}
