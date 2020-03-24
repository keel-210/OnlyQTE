using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePool : MonoBehaviour
{
	public GameObject note;
	public NotesManager manager;
	List<Note> UsingNotes = new List<Note>();
	List<Note> UsableNotes = new List<Note>();
	public void PrepareNotes(Note _n, RectTransform t)
	{
		if (UsableNotes.Count == 0)
		{
			GameObject obj = Instantiate(note);
			Note n = obj.GetComponent<Note>();
			UsingNotes.Add(n);
			ActivateNote(n, _n, t);
		}
		else
		{
			Note n = UsableNotes[0];
			n.gameObject.SetActive(true);
			UsingNotes.Add(n);
			UsingNotes.RemoveAt(0);
			ActivateNote(n, _n, t);
		}
	}
	public void Remove(Note n)
	{
		UsingNotes.Remove(n);
		UsableNotes.Add(n);
		n.gameObject.SetActive(false);
	}
	void ActivateNote(Note n, Note _n, RectTransform t)
	{
		n.gameObject.SetActive(true);
		n.Time = _n.Time;
		n.manager = manager;
		n.NoteType = _n.NoteType;
		n.pool = this;
		n.StartNote(t);
	}
}
