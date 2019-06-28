using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MySpriteButton: MyButton
{
	/* Fields */
	[HideInInspector] [SerializeField] private Sprite[] sprite= null;


	/* Classes */
	#if UNITY_EDITOR
	[CustomEditor(typeof(MySpriteButton)), CanEditMultipleObjects]
	private class MySpriteButtonEditor: Editor
	{
		private static bool showSprite= false;
		private int spriteSize= 0;

		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			MySpriteButton mySpriteButton= (MySpriteButton)target;

			mySpriteButton.buttonType= (ButtonType)EditorGUILayout.EnumPopup("Button Type", mySpriteButton.buttonType);
			switch(mySpriteButton.buttonType)
			{
			case ButtonType.Rectangle:
				mySpriteButton.length= EditorGUILayout.Vector2Field("Length", mySpriteButton.length);
				break;
			case ButtonType.Circle:
				mySpriteButton.radius= EditorGUILayout.FloatField("Radius", mySpriteButton.radius);
				break;
			}

			showSprite= EditorGUILayout.Foldout(showSprite, "Sprite");
			if(showSprite)
			{
				spriteSize= mySpriteButton.sprite.Length;
				spriteSize= EditorGUILayout.IntField("Size", spriteSize);
				Array.Resize(ref mySpriteButton.sprite, spriteSize);

				for(int i= 0; i<spriteSize; i++)
					mySpriteButton.sprite[i]= (Sprite)EditorGUILayout.ObjectField("Element "+i, mySpriteButton.sprite[i], typeof(Sprite), false, GUILayout.Height(16));
			}
		}
	}
	#endif


	/* Methods */
	protected override bool OverlapPoint()
	{
		if(GetComponent<SpriteRenderer>().sprite==null)
			return false;

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

	public void ChangeSprite(string name) { GetComponent<SpriteRenderer>().sprite= Array.Find(sprite, sprite => string.Compare(sprite.name, name)==0); }
}