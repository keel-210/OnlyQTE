using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	[SerializeField] NotesManager manager;
	public void ButtonDown(int NoteNum)
	{
		// Debug.Log(System.Enum.ToObject(typeof(NoteEnum), NoteNum) + Time.time.ToString());
		manager.CheckBeat((NoteEnum)System.Enum.ToObject(typeof(NoteEnum), NoteNum));
	}
	public void ButtonUp(int NoteNum)
	{

	}
}
