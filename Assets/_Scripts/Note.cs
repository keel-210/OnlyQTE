using UnityEngine;

public class Note : MonoBehaviour
{
    public int Time;
    public NoteEnum NoteType;
    public NotesManager manager;
    public NotePool pool;
    bool ISChecked;
    public void StartNote(RectTransform t)
    {
        transform.parent = GameObject.Find("Canvas").transform;
        transform.position = t.position;
        ISChecked = false;
    }
    void Update()
    {
        if (manager.ManagedTime > Time - manager.CheckRange && !ISChecked)
        {
            manager.AddCheck(this);
            ISChecked = true;
        }
        if (manager.ManagedTime > Time + manager.CheckRange)
        {
            manager.RemoveCheck(this);
            pool.Remove(this);
        }
    }
}
public enum NoteEnum
{
    Up, Down, Right, Left, Cross, Triangle, Circle, Rectangle
}