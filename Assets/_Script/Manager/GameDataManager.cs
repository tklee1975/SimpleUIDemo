using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder
{
	public class GameDataManager : ScriptableObject {

		#region Singleton Code
		protected static GameDataManager sInstance = null;

		public static GameDataManager Instance
		{
			get
			{
				if (sInstance == null) {
					sInstance = ScriptableObject.CreateInstance<GameDataManager>();
					sInstance.hideFlags = HideFlags.HideAndDontSave;	// Not visible to the user and not save
				}

				return sInstance;
			}
		}

		void OnEnable() {
			LoadHeroData();
		}

		#endregion

        public void Startup() {

        }

		#region GameData Data 

		protected List<HeroData> m_heroList = new List<HeroData>();

		public List<HeroData> heroList {
			get {
				return m_heroList;
			}
		}

		void LoadHeroData() {
			m_heroList.Clear();

			string path = "Data/HeroData";
			string content = FileHelper.ReadFileFromAsset(path);

			List<object> jsonDataArray = (List<object>) MiniJSON.Json.Deserialize(content);
			foreach (object obj in jsonDataArray) {
				Dictionary<string, object> recordJSON = (Dictionary<string, object>) obj;
				
				HeroData data = new HeroData();
				data.ParseJSONData(recordJSON);

				// recordList.Add (record);
                m_heroList.Add(data);
			}
		}


		#endregion

        #region Info 
        public string InfoHeroList() {
            string info = "";

            foreach(HeroData data in m_heroList) {
                info += data.ToString() + "\n";
            }

            return info;
        }

        #endregion
    }

}