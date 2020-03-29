using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class TimeLine_Object : ScriptableObject
{

    public abstract bool Act(TimeLinePlayer player);
}
