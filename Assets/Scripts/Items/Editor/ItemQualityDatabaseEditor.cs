using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Items {

	public class ItemQualityDatabaseEditor : EditorWindow {

		ItemQualityDatabase db;

		const string DATABASE_FILE_NAME = @"ItemQualityDatabase.asset";
		const string DATABASE_FOLDER_NAME = @"Database";
		const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_FOLDER_NAME + "/" + DATABASE_FILE_NAME;

		[MenuItem("Lonelinia/Item Quality Editor %#i")]
		public static void Init() {
			ItemQualityDatabaseEditor window = EditorWindow.GetWindow<ItemQualityDatabaseEditor> ();
			window.minSize = new Vector2 (600, 400);
			window.title = "Item Quality";
			window.Show ();
		}


		void OnEnable() {
			db = AssetDatabase.LoadAssetAtPath (DATABASE_FULL_PATH, typeof(ItemQualityDatabaseEditor)) as ItemQualityDatabase;
			if (db == null) {
				if (!AssetDatabase.IsValidFolder ("Assets/" + DATABASE_FOLDER_NAME)) {
					AssetDatabase.CreateFolder ("Assets", DATABASE_FOLDER_NAME);
				}

				db = ScriptableObject.CreateInstance<ItemQualityDatabase> ();
				AssetDatabase.CreateAsset(db, DATABASE_FULL_PATH);
				AssetDatabase.SaveAssets ();
				AssetDatabase.Refresh ();
			}
		}



		void OnGUI() {
			GUILayout.Label ("test label");


		}




		void AddQuality() {

		}


	}

}