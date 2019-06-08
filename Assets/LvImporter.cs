using UnityEngine;
using UnityEditor.Experimental.AssetImporters;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

[ScriptedImporter(1, "lvl")]
public class LvImporter : ScriptedImporter
{
	public float m_Scale = 1;

	public override void OnImportAsset(AssetImportContext ctx)
	{
		var name = ctx.assetPath.Replace ("\\", "/").Split ('/').LastOrDefault () ?? "temp";
		var gameObjectRoot = new GameObject(name);
		var canvas = gameObjectRoot.AddComponent<Canvas>();
		gameObjectRoot.AddComponent<Transform>();

		GameObject textGameObj = new GameObject(name+"Text");
		textGameObj.AddComponent<Transform>();

		var rectTransform = gameObjectRoot.GetComponent<RectTransform> ();
		rectTransform.anchoredPosition = Vector2.zero;	
		rectTransform.anchoredPosition = Vector2.zero;	

		string fileContent = File.ReadAllText (ctx.assetPath).Replace("\r", "");
		var lines = fileContent.Split ('\n');
		var width = lines.Aggregate (0, (acc, val) => Math.Max (acc, val.Length));
		var height = Math.Max(0, lines.Length - 2);

		Text textComp = textGameObj.AddComponent<Text>();
		var font = Resources.Load<Font> ("ConsolasLevel");

		Debug.Log ("res load: "+font);

		font = Resources.FindObjectsOfTypeAll<Font> ().FirstOrDefault();

		Debug.Log ("res find: " + font);

		textComp.font = font; // Font.CreateDynamicFontFromOSFont ("ConsolasLevel", 12); //font;
		textComp.fontStyle = FontStyle.Normal;
		textComp.fontSize = 12;
		textComp.supportRichText = true;
		Debug.Log ("prop font: " + textComp.font);
		textComp.horizontalOverflow = HorizontalWrapMode.Overflow;
		textComp.verticalOverflow = VerticalWrapMode.Overflow;
		textComp.text = fileContent; // + "\n@" + DateTime.Now + ", w: "+width+", h: "+height;

		/*var oneCharHeight = 25;
		var oneCharWidth = 10;
		var rectTransform = textGameObj.GetComponent<RectTransform> ();
		rectTransform.sizeDelta = new Vector2(width*oneCharWidth, height*oneCharHeight);
		*/

		textGameObj.transform.parent = gameObjectRoot.transform;
		gameObjectRoot.transform.rotation = Quaternion.Euler(90, 0, 0);
		textGameObj.transform.rotation = Quaternion.Euler(90, 0, 0);

		var position = Vector3.zero; // r3>(textVl);

		gameObjectRoot.transform.position = position;
		gameObjectRoot.transform.localScale = Vector3.one * m_Scale;

		// 'cube' is a a GameObject and will be automatically converted into a prefab
		// (Only the 'Main Asset' is elligible to become a Prefab.)
		ctx.AddObjectToAsset("main obj", gameObjectRoot);
		ctx.AddObjectToAsset("font", font);
		ctx.SetMainObject(gameObjectRoot);

		textComp.cachedTextGenerator.Invalidate ();


		//var material = new Material(Shader.Find("Standard"));
		//material.color = Color.red;

		// Assets must be assigned a unique identifier string consistent across imports
		//ctx.AddObjectToAsset("my Material", material);

		// Assets that are not passed into the context as import outputs must be destroyed
		//var tempMesh = new Mesh();
		//DestroyImmediate(tempMesh);
	}
}