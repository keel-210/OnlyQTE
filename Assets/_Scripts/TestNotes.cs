using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNotes : MonoBehaviour
{
	public GameObject note;
	public List<float> times = new List<float>();
	public List<NoteEnum> enums = new List<NoteEnum>();
	public List<RectTransform> QTE_Transform = new List<RectTransform>();
	[SerializeField] NotePool pool;
	void Start()
	{

	}

	void Update()
	{
		for (int i = 0; i < times.Count; i++)
		{
			if (times[i] - 1.0f > Time.time)
			{
				GameObject obj = Instantiate(note);
				obj.transform.position = QTE_Transform[i].position;

			}
			else
				break;
		}
	}
}
