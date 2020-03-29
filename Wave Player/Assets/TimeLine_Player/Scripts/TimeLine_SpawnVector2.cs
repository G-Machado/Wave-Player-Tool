using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TimeLinePlayer/TimeLine Object/Spawn Vector2")]
public class TimeLine_SpawnVector2: TimeLine_Object
{

    [Header("Prefab Spawn")]
    [Tooltip("The prefab that's going to be spawned at WavePlayer position")]
    public GameObject prefab;

    [Header("Spawn Position")]
    [Tooltip("The position were the prefab will be instaciated")]
    public Vector2 position;

    public override bool Act(TimeLinePlayer player)
    {
        GameObject clone = Instantiate(prefab, position, player.transform.rotation, player.transform);

        return clone != null;
    }
}
