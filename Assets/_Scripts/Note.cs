using UnityEngine;
using DG.Tweening;
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
		transform.localScale = Vector3.one;
		transform.DOScale(Vector3.one * 0.25f, 1f).SetEase(Ease.InCirc);
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