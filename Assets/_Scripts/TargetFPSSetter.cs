using UnityEngine;

public class TargetFPSSetter : MonoBehaviour
{
	void Awake()
	{
		Application.targetFrameRate = 100;
	}
}