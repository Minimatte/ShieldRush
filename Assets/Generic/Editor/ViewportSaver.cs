using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;

public class ViewportSaver : EditorWindow
{
	struct Orientation
	{
		public Vector3 Position { get { return position; } }
		public Quaternion Rotation { get { return rotation; } }

		Vector3 position;
		Quaternion rotation;

		public Orientation(SceneView view)
		{
			position = view.pivot;
			rotation = view.rotation;
		}

		public Orientation(Vector3 position, Quaternion rotation)
		{
			this.position = position;
			this.rotation = rotation;
		}

		public void ApplyTo(SceneView view)
		{
			view.pivot = position;
			view.rotation = rotation;
		}

		public static bool operator !=(Orientation a, Orientation b)
		{
			return !(a == b);
		}
		public static bool operator ==(Orientation a, Orientation b)
		{
			return a.position == b.position && a.rotation == b.rotation;
		}
	}

	static string FileName { get { return Application.temporaryCachePath + SceneManager.GetActiveScene().name + ".views"; } }

	static Dictionary<int, Orientation> viewportList = new Dictionary<int, Orientation>();
	static Orientation oldBuffer;

	[MenuItem("Viewport/Save/1 %1")]
	public static void SaveViewport1() { SaveViewport(0); }
	[MenuItem("Viewport/Restore/1 #1")]
	public static void RestoreViewport1() { RestoreViewport(0); }
	[MenuItem("Viewport/Save/2 %2")]
	public static void SaveViewport2() { SaveViewport(1); }
	[MenuItem("Viewport/Restore/2 #2")]
	public static void RestoreViewport2() { RestoreViewport(1); }
	[MenuItem("Viewport/Save/3 %3")]
	public static void SaveViewport3() { SaveViewport(2); }
	[MenuItem("Viewport/Restore/3 #3")]
	public static void RestoreViewport3() { RestoreViewport(2); }
	[MenuItem("Viewport/Save/4 %4")]
	public static void SaveViewport4() { SaveViewport(3); }
	[MenuItem("Viewport/Restore/4 #4")]
	public static void RestoreViewport4() { RestoreViewport(3); }
	[MenuItem("Viewport/Save/5 %5")]
	public static void SaveViewport5() { SaveViewport(4); }
	[MenuItem("Viewport/Restore/5 #5")]
	public static void RestoreViewport5() { RestoreViewport(4); }

	static void SaveViewport(int index)
	{
		if (!GetCurrentView())
			return;

		viewportList[index] = GetCurrentOrientation();
		UpdateBuffer();

		SaveToFile(FileName);
	}

	static void RestoreViewport(int index)
	{
		LoadFromFile(FileName);

		if (!GetCurrentView())
			return;

		if (!viewportList.ContainsKey(index))
		{
			Debug.Log("Viewport " + (index + 1) + " not saved!");
			return;
		}

		Orientation target = viewportList[index];

		if (target == GetCurrentOrientation())
			oldBuffer.ApplyTo(GetCurrentView());
		else {
			UpdateBuffer();
			target.ApplyTo(GetCurrentView());
		}
	}

	static SceneView GetCurrentView()
	{
		return SceneView.lastActiveSceneView;
	}

	static Orientation GetCurrentOrientation()
	{
		if (!GetCurrentView())
			return new Orientation();

		return new Orientation(GetCurrentView());
	}

	static void UpdateBuffer()
	{
		oldBuffer = GetCurrentOrientation();
	}

	static void SaveToFile(string filename)
	{
		using (BinaryWriter writer = new BinaryWriter(new FileStream(filename, FileMode.Create)))
		{
			writer.Write(viewportList.Count);
			foreach (KeyValuePair<int, Orientation> pair in viewportList)
			{
				writer.Write(pair.Key);

				//Write position
				writer.Write(pair.Value.Position.x);
				writer.Write(pair.Value.Position.y);
				writer.Write(pair.Value.Position.z);

				//Write rotation
				writer.Write(pair.Value.Rotation.x);
				writer.Write(pair.Value.Rotation.y);
				writer.Write(pair.Value.Rotation.z);
				writer.Write(pair.Value.Rotation.w);
			}
		}
	}

	static void LoadFromFile(string filename)
	{
		using (BinaryReader reader = new BinaryReader(new FileStream(filename, FileMode.OpenOrCreate)))
		{
			if (reader.BaseStream.Length <= 0)
				return;

			viewportList.Clear();
			int n = reader.ReadInt32();

			for (int i = 0; i < n; i++)
			{
				int index = reader.ReadInt32();

				Vector3 position = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
				Quaternion rotation = new Quaternion(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

				viewportList[index] = new Orientation(position, rotation);
			}
		}
	}
}
