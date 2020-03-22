using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class NotesManager : MonoBehaviour
{
	[SerializeField] string CSVName;
	public List<Note> CheckingNotes = new List<Note>();
	public List<Note> UsingNotes = new List<Note>();
	bool IsPlaying;
	public float ManagedTime;
	public int PerfectRange = 40, GoodRange = 80, CheckRange = 120;
	void Start()
	{

	}
	void StartMusic()
	{
		ManagedTime = 0;
	}
	void Update()
	{
		if (!IsPlaying)
			return;
		ManagedTime += Time.deltaTime * 1000;

	}
	public void CheckBeat(NoteEnum n)
	{
		if (CheckingNotes.Count == 0)
			return;
		var c = CheckingNotes.Where(x => x.NoteType == n).OrderBy(x => x.Time).First();
		if (Mathf.Abs(ManagedTime - c.Time) < PerfectRange)
		{ Perfect(); return; }
		if (Mathf.Abs(ManagedTime - c.Time) < GoodRange)
		{ Good(); return; }
		if (Mathf.Abs(ManagedTime - c.Time) < CheckRange)
		{ Bad(); return; }
	}
	void Perfect()
	{
		Debug.Log("Perfect");
	}
	void Good()
	{
		Debug.Log("Good");
	}
	void Bad()
	{
		Debug.Log("Bad");
	}
	public void AddCheck(Note n)
	{
		CheckingNotes.Add(n);
	}
}