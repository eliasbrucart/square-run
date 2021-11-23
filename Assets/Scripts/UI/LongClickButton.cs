using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private bool pointerDown;
	private float pointerDownTimer;

	[SerializeField]
	private float requiredHoldTime;

	public UnityEvent onLongClick;
	static public event Action<string> MovePlayerDirection;

	public void OnPointerDown(PointerEventData eventData)
	{
		pointerDown = true;
		Debug.Log("OnPointerDown");
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		Reset();
		Debug.Log("OnPointerUp");
	}

	private void Update()
	{
		if (pointerDown)
		{
			if (gameObject.tag == "buttonRight")
				MovePlayerDirection?.Invoke("right");
			else
				MovePlayerDirection?.Invoke("left");
		}
	}

	private void Reset()
	{
		pointerDown = false;
		pointerDownTimer = 0;
	}

}