using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class NotesManager : MonoBehaviour
{
	[SerializeField] string CSVName;
	[SerializeField] NotePool pool;
	public List<Note> CheckingNotes = new List<Note>();
	public List<Note> Notes = new List<Note>();
	public List<RectTransform> QTE_Transform = new List<RectTransform>();

	bool IsPlaying;
	public float ManagedTime;
	public int PerfectRange = 40, GoodRange = 80, CheckRange = 120;
	List<Note> DeleteNotes = new List<Note>();
	void Start()
	{
		CSVReader reader = new CSVReader();
		Notes = reader.ReadScore(CSVName);
		StartMusic();
	}
	void StartMusic()
	{
		ManagedTime = 0;
		IsPlaying = true;
	}
	void Update()
	{
		if (!IsPlaying)
			return;
		ManagedTime += Time.deltaTime * 1000;

		for (int i = 0; i < Notes.Count; i++)
		{
			if (Notes[i].Time - 1000 < ManagedTime)
			{
				pool.PrepareNotes(Notes[i], QTE_Transform[(int)Notes[i].NoteType]);
				DeleteNotes.Add(Notes[i]);
			}
			else
				break;
		}
		foreach (Note dn in DeleteNotes)
			Notes.Remove(dn);
		DeleteNotes.Clear();
	}
	public void CheckBeat(NoteEnum n)
	{
		Debug.Log(CheckingNotes.Count);
		if (CheckingNotes.Count == 0)
			return;
		var c = CheckingNotes.Where(x => x.NoteType == n).OrderBy(x => x.Time).First();
		if (Mathf.Abs(ManagedTime - c.Time) < PerfectRange)
		{ Perfect(c); return; }
		if (Mathf.Abs(ManagedTime - c.Time) < GoodRange)
		{ Good(c); return; }
		if (Mathf.Abs(ManagedTime - c.Time) < CheckRange)
		{ Bad(c); return; }
	}
	void Perfect(Note n)
	{
		RemoveCheck(n);
		Debug.Log("Perfect");
	}
	void Good(Note n)
	{
		RemoveCheck(n);
		Debug.Log("Good");
	}
	void Bad(Note n)
	{
		RemoveCheck(n);
		Debug.Log("Bad");
	}
	public void AddCheck(Note n)
	{
		CheckingNotes.Add(n);
	}
	public void RemoveCheck(Note n)
	{
		if (CheckingNotes.Contains(n))
			CheckingNotes.Remove(n);
	}
}