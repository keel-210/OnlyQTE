using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePool : MonoBehaviour
{
	public GameObject note;
	public NotesManager manager;
	List<Note> UsingNotes = new List<Note>();
	List<Note> UsableNotes = new List<Note>();
	public void PrepareNotes(NoteEnum NoteType, RectTransform t)
	{
		if (UsableNotes.Count == 0)
		{
			GameObject obj = Instantiate(note);
			Note n = obj.GetComponent<Note>();
			UsingNotes.Add(n);
			ActivateNote(n, NoteType, t);
		}
		else
		{
			Note n = UsableNotes[0];
			n.gameObject.SetActive(true);
			UsingNotes.Add(n);
			UsingNotes.RemoveAt(0);
			ActivateNote(n, NoteType, t);
		}
	}
	public void Remove(Note n)
	{
		UsingNotes.Remove(n);
		UsableNotes.Add(n);
		n.gameObject.SetActive(false);
	}
	void ActivateNote(Note n, NoteEnum NoteType, RectTransform t)
	{
        n.gameObject.SetActive(true);
		n.manager = manager;
		n.NoteType = NoteType;
        n.pool = this;
		n.StartNote(t);
	}
}
