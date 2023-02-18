using UnityEngine;
using UnityEngine.EventSystems;

public class A2DTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public bool Press;


	#region IPointerDownHandler implementation
	public void OnPointerDown (PointerEventData eventData)
	{
		Press = true;
	}
	#endregion

	#region IPointerUpHandler implementation
	public void OnPointerUp (PointerEventData eventData)
	{
		Press = false;
	}

	#endregion



}
