using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TimeLinePlayer/TimeLine Object/Spawn Random Area")]
public class TimeLine_RandomAreaSpawn : TimeLine_Object
{
    [Header("Random X position (min & max)")]
    public float min_xPosition;
    public float max_xPosition;

    [Header("Random Y position (min & max)")]
    public float min_yPosition;
    public float max_yPosition;

    [Header("Spawn Prefab")]
    public GameObject prefab;

    public override bool Act(TimeLinePlayer player)
    {
        if (!prefab)
        {
            Debug.LogError("TimeLine_Object Random Area Spawn doesn't have a prefab do instantiate.");
            return true;
        }

        float x = Random.Range(min_xPosition, max_xPosition);
        float y = Random.Range(min_yPosition, max_yPosition);

        Vector3 position = new Vector3(x, y);

        GameObject clone = Instantiate(prefab, position, player.transform.rotation, player.transform);

        return clone != null;
    }
}

