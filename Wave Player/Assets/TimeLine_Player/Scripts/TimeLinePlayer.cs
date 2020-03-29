using System.Collections;
using System.Collections.Generic;
using Malee;
using UnityEngine;
using UnityEditor;

public class TimeLinePlayer : MonoBehaviour
{
	[System.Serializable]
    public class TimeLineList : ReorderableArray<TimeLine_Object>{
    }

    [Space(10)]
    [Reorderable]
    [Header("                  Main TimeLine")]
    public TimeLineList TimeLine;

    [HideInInspector]
    public float time;
    [HideInInspector]
    public float lastActionTime;

    [HideInInspector]
    public Stack<TimeLine_Object> waves_buffer;
    [HideInInspector]
    public List<TimeLine_Object> played_waves;
    [HideInInspector]
    public bool showPlayedWaves = false;

    void Start()
    {
        lastActionTime = Time.time;
        time = Time.time;

        waves_buffer = new Stack<TimeLine_Object>();

        TimeLine_Object[] timeLine_list = new TimeLine_Object[TimeLine.Count];
        TimeLine.CopyTo(timeLine_list,0);

        Load_Waves(timeLine_list);
    }

    void FixedUpdate()
    {
        time = Time.time;

        if(waves_buffer.Count > 0)
        {
            if (waves_buffer.Peek() != null) {

                TimeLine_Object current_object = waves_buffer.Peek();

                bool result = current_object.Act(this);

                if (result)
                {
                    if (waves_buffer.Peek() == current_object)
                    {
                        Add_playedList(waves_buffer.Pop());
                    }

                    lastActionTime = time;
                }
            }
            else { }
            //Add_playedList(waves_buffer.Pop());
        }
    }

    private void Load_Waves(TimeLine_Object[] buffer)
    {
        for (int i = buffer.Length-1; i > -1; i--)
        {
            waves_buffer.Push(buffer[i]);
        }
    }

    public void buffer_Add(TimeLine_Object[] list)
    {
        for (int i = list.Length - 1; i > -1; i--)
        {
            waves_buffer.Push(list[i]);
        }
    }

    public void buffer_Remove(TimeLine_Object tmLine_Object)
    {
        if (waves_buffer.Peek() == tmLine_Object)
        {
            waves_buffer.Pop();
        }
    }

    private void Add_playedList(TimeLine_Object obj)
    {
        if (played_waves.Count > 0)
            played_waves.Insert(played_waves.Count, obj);
        else
            played_waves.Insert(0, obj);
    }
}

[CustomEditor(typeof(TimeLinePlayer))]
public class TimeLinePlayerEditor: Editor
{

    private List<TimeLine_Object> playedObjects = new List<TimeLine_Object>();

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        TimeLinePlayer myTarget = (TimeLinePlayer)target;

        myTarget.showPlayedWaves = EditorGUILayout.ToggleLeft("- Show played TimeLine Objects:  ", myTarget.showPlayedWaves);

        if (!myTarget.showPlayedWaves) return; 

        for (int i = 0; i < myTarget.played_waves.Count; i++)
        {
            EditorGUILayout.LabelField(i + ". " + myTarget.played_waves[i].name, EditorStyles.miniLabel);
        }

        if (myTarget.waves_buffer == null) return;

        TimeLine_Object[] objectsList = new TimeLine_Object[myTarget.waves_buffer.Count];
        myTarget.waves_buffer.CopyTo(objectsList, 0);

        if (objectsList.Length > 0)
        {
            EditorGUILayout.LabelField(myTarget.played_waves.Count + ". " + "-> " + objectsList[0].name, EditorStyles.miniBoldLabel);

            for (int i = 1; i < objectsList.Length; i++)
            {
                EditorGUILayout.LabelField((myTarget.played_waves.Count+i) + ". " + objectsList[i].name);
            }
        }
    }

}
