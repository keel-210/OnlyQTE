using UnityEngine;

public class Note : MonoBehaviour
{
	public int Time;
	public int Bar, Beat;
	public NoteEnum NoteType;
	public NotesManager manager;
	public void StartNote(RectTransform t)
	{
		transform.position = t.position;

	}
	void Update()
	{
		if (manager.ManagedTime - manager.CheckRange > Time)
			manager.AddCheck(this);
	}
}
public enum NoteEnum
{
	Up, Down, Right, Left, Cross, Triangle, Circle, Rectangle
}