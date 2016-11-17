using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
namespace OfficeLogger
{
	/// <summary>
	/// Local Storage System will take data from other systems, serialize it and then write it to separate files
	/// </summary>
    public class LocalStorageService : MonoService
	{
        protected override void Awake()
        {
            MonoServiceApplication.AddService(MonoInstanceConstants.LOCALSTORAGESERVICE, this);
        }

		private string fileNameSeparator = "_";

		/// <summary>
		/// Synchronously loads data from a file and deserializes it into a dictionary
		/// </summary>
		/// <returns> Returns the dictionary of data with regard to the gievn file name</returns>
		/// <param name="name">name of the file to load the data</param>
		public Dictionary<string, object> LoadGlobalData (string name)
		{
			string fileName = Application.persistentDataPath + "/" + name;
			string encodedString = LoadLocalFile (fileName);
			if (encodedString != null)
				return Deserialize (encodedString);
			return null;
		}

		/// <summary>
		/// Synchronously loads data from a file using given accountID and deserializes it into a dictionary
		/// </summary>
		/// <returns> Returns dictionary of data associated with given file name and specific to account ID</returns>
		/// <param name="name">name - Name of the file to load from</param>
		/// <param name="accountID">Id of the account the file is associated with.</param>
		public Dictionary<string, object> LoadAccountData (string name, string accountID)
		{
			return LoadGlobalData (name + fileNameSeparator + accountID);
		}

		/// <summary>
		/// Synchronously loads data from a file using given characterID and deserializes it into a dictionary
		/// </summary>
		/// <returns> Returns dictionary of data associated with given file name and specific to character ID</returns>
		/// <param name="name">filename to load from</param>
		/// <param name="characterID">Id of the character the file associated with.</param>
		public Dictionary<string, object> LoadCharacterData (string name, string characterID)
		{
			return LoadGlobalData (name + fileNameSeparator + characterID);
		}

		/// <summary>
		/// Asynchronously loads data from a file, deserializes it into a dictionary,
		/// and then calls callback with the resulting dictionary
		/// </summary>
		/// <param name="name">fileName</param>
		/// <param name="callback">Callback</param>
		public void LoadGlobalDataAsync (string name, Action<Dictionary<string, object>> callback)
		{
			string fileName = Application.persistentDataPath + "/" + name;
		
			StartCoroutine (LoadLocalFileAsync (fileName, callback));
		}

		/// <summary>
		/// Asynchronously loads data from a file, deserializes it into a dictionary,
		/// and then calls callback with the resulting dictionary
		/// data is account specific
		/// </summary>
		/// <param name="name">fileName</param>
		/// <param name="callback">Callback</param>
		/// <param name="accountID">Account ID.</param>
		public void LoadAccountDataAsync (string name, Action<Dictionary<string, object>> callback, string accountID)
		{
			LoadGlobalDataAsync (name + fileNameSeparator + accountID, callback);
		}

		/// <summary>
		/// Asynchronously loads data from a file, deserializes it into a dictionary,
		/// and then calls callback with the resulting dictionary
		/// data is character specific
		/// </summary>
		/// <param name="name">fileName</param>
		/// <param name="callback">Callback</param>
		/// <param name="characterID">Character ID.</param>
		public void LoadCharacterDataAsync (string name, Action<Dictionary<string, object>> callback, string characterID)
		{
			LoadGlobalDataAsync (name + fileNameSeparator + characterID, callback);
		}

		/// <summary>
		/// Serializes the data and then synchronously saves it to a file
		/// </summary>
		/// <param name="name">fileName</param>
		/// <param name="data">Data that might need to be desrialized again.</param>
		public void SaveData (string name, Dictionary<string, object> data)
		{
			string fileName = Application.persistentDataPath + "/" + name;
			string encodedString = Serialize (data);
		
			SaveToLocalFile (fileName, encodedString);
		}

		/// <summary>
		/// Serializes the data and then synchronously saves it to a file
		/// data is account specific
		/// </summary>
		/// <param name="name">fileName</param>
		/// <param name="data">Data that might need to be desrialized again.</param>
		/// /// <param name="accountID">Account ID.</param>
		public void SaveAccountData (string name, Dictionary<string, object> data, string accountID)
		{
			SaveData (name + fileNameSeparator + accountID, data);
		}

		/// <summary>
		/// Serializes the data and then synchronously saves it to a file
		/// data is character specific
		/// </summary>
		/// <param name="name">fileName</param>
		/// <param name="data">Data that might need to be desrialized again.</param>
		/// /// <param name="characterID">Character ID.</param>
		public void SaveCharacterData (string name, Dictionary<string, object> data, string characterID)
		{
			SaveData (name + fileNameSeparator + characterID, data);
		}

		/// <summary>
		/// Returns true if a file exists on the local device for the given data name
		/// </summary>
		/// <returns><c>true</c>, if file exists <c>false</c> otherwise.</returns>
		/// <param name="name">fileName</param>
		public bool GlobalDataExists (string name)
		{
			string fileName = Application.persistentDataPath + "/" + name;
			if (File.Exists (fileName)) {
				Debug.Log (fileName + " exists.");
				return true;
			}
			Debug.Log (fileName + " doesn't exist.");
			return false;
		}

		/// <summary>
		/// Returns true if a file exists on the local device for the given data name that is account specific
		/// </summary>
		/// <returns><c>true</c>, if file exists <c>false</c> otherwise.</returns>
		/// <param name="name">fileName</param>
		public bool AccountDataExists (string name, string accountID)
		{
			return GlobalDataExists (name + fileNameSeparator + accountID);
		}

		/// <summary>
		/// Returns true if a file exists on the local device for the given data name that is character specific
		/// </summary>
		/// <returns><c>true</c>, if file exists <c>false</c> otherwise.</returns>
		/// <param name="name">fileName</param>
		public bool CharacterDataExists (string name, string characterID)
		{
			return GlobalDataExists (name + fileNameSeparator + characterID);
		}

		/// <summary>
		/// Saves data to the local file.
		/// </summary>
		/// <param name="fileName">File name.</param>
		/// <param name="encodedString">Encoded string</param>
		private void SaveToLocalFile (string fileName, string encodedString)
		{
			if (File.Exists (fileName)) {
				Debug.LogWarning ("Overwriting " + fileName);
				//			return;
			}
			var writer = File.CreateText (fileName);
			writer.WriteLine (encodedString);
			writer.Close ();
		}

		/// <summary>
		/// Loads the local file.
		/// </summary>
		/// <returns>EncodedString</returns>
		/// <param name="fileName">File name.</param>
		private string LoadLocalFile (string fileName)
		{
			if (File.Exists (fileName)) 
			{
				var reader = File.OpenText (fileName);
				string toLoad = reader.ReadLine ();
				reader.Close ();
				if (!string.IsNullOrEmpty (toLoad)) 
				{
					Debug.Log (toLoad);
					return toLoad;
				}
			} else {
				Debug.Log ("Could not Open the file: " + fileName + " for reading.");
			}
			return null;
		}

		/// <summary>
		/// Loads the local file asynchronously.
		/// </summary>
		/// <param name="fileName">File name.</param>
		/// <param name="callback">Callback on file successfully loaded</param>
		private IEnumerator LoadLocalFileAsync (string fileName, Action<Dictionary<string, object>> callback)
		{
			string encodedString = "";
			WWW www = new WWW ("file:///" + fileName);
			while (!www.isDone) {
				Debug.Log (www.progress);
				yield return null;
			}
			string toLoad = www.text;
			if (!string.IsNullOrEmpty (toLoad)) {
				Debug.Log ("Done");
				encodedString = toLoad;
				if (callback != null)
					callback.Invoke (Deserialize (encodedString));
				yield break;
			} else {
				Debug.Log ("Could not Open the file: " + fileName + " for reading.");
			}
		}

		/// <summary>
		/// Serialize the specified data.
		/// </summary>
		private string Serialize (Dictionary<string, object> data)
		{
			ToSerialize toSerialize = new ToSerialize (data);
			string encodedString = JsonUtility.ToJson (toSerialize);
			Debug.Log (encodedString);
			return encodedString;
		}

		/// <summary>
		/// Deserialize the specified encodedString into dictionary
		/// </summary>
		private Dictionary<string, object> Deserialize (string encodedString)
		{
			ToSerialize toSerialize = JsonUtility.FromJson<ToSerialize> (encodedString);
			return toSerialize.ToDictionary ();
		}

		/// <summary>
		/// To serialize dictionary since unity doesn't serialize dictionary but it does serialize lists
		/// </summary>
		[System.Serializable]
		public class ToSerialize
		{
			[SerializeField] private List<string> keys;
			[SerializeField] private List<string> values;

			/// <summary>
			/// Initializes lists with keys and values of dictionary passed
			/// </summary>
			/// <param name="data">Data.</param>
			public ToSerialize (Dictionary<string,object> data)
			{
				keys = new List<string> ();
				values = new List<string> ();
				foreach (var item in data) {
					keys.Add (item.Key);
					values.Add (JsonUtility.ToJson (item.Value));
				}

				if (keys.Count != values.Count)
					throw new System.Exception (string.Format ("there are {0} keys and {1} values after serialization. Make sure that both key and value types are serializable."));
			}

			/// <summary>
			/// Converts list of keys and values to appropriate dictionary
			/// </summary>
			/// <returns>The dictionary.</returns>
			public Dictionary<string,object> ToDictionary ()
			{
				if (keys.Count != values.Count)
					throw new System.Exception (string.Format ("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));
				
				Dictionary<string,object> data = new Dictionary<string, object> ();
				for (int i = 0; i < keys.Count; i++) {
					data [keys [i]] = JsonUtility.FromJson (values [i], Type.GetType (keys [i]));
				}
				return data;
			}
		}		
	}
}
