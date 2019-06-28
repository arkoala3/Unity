using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MyButton: MonoBehaviour
{
	/* Fields */
	protected enum ButtonType { None, Rectangle, Circle }
	[HideInInspector] [SerializeField] protected ButtonType buttonType= ButtonType.None;

	protected Vector2 center;
	[HideInInspector] [SerializeField] protected Vector2 length= new Vector2(0, 0); // Divide by 2
	[HideInInspector] [SerializeField] protected float radius= 0;

	protected Vector2 tapPoint;


	/* Classes */
	#if UNITY_EDITOR
	[CustomEditor(typeof(MyButton)), CanEditMultipleObjects]
	private class MyButtonEditor: Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			MyButton myButton= (MyButton)target;

			myButton.buttonType= (ButtonType)EditorGUILayout.EnumPopup("Button Type", myButton.buttonType);
			switch(myButton.buttonType)
			{
			case ButtonType.Rectangle:
				myButton.length= EditorGUILayout.Vector2Field("Length", myButton.length);
				break;
			case ButtonType.Circle:
				myButton.radius= EditorGUILayout.FloatField("Radius", myButton.radius);
				break;
			}
		}
	}
	#endif


	/* Methods */
	private void Start() { center= transform.position; }

	private void Update()
	{
		if(Input.GetMouseButton(0))
			tapPoint= Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if(Input.GetMouseButtonUp(0))
			if(OverlapPoint())
				SendMessageUpwards("ProcessButtonClick", name);
	}

	protected virtual bool OverlapPoint()
	{
		switch(buttonType)
		{
		case ButtonType.Rectangle:
			return ((center.x-length.x<=tapPoint.x&&tapPoint.x<=center.x+length.x) && (center.y-length.y<=tapPoint.y&&tapPoint.y<=center.y+length.y));
		case ButtonType.Circle:
			return (Math.Sqrt(Math.Pow(center.x-tapPoint.x, 2)+Math.Pow(center.y-tapPoint.y, 2))<=radius);
		default:
			return false;
		}
	}
}