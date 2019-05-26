using System.Collections;
using System.Collections.Generic;

namespace Kencoder
{
    public class HeroData : JSONData
    {
        public int id = 0;
        public string name = "";
        public string job = "";
        public string country = "";
        public string bio = "";
        public string mugshot = "";

        public override void ParseJSONData(Dictionary<string, object> jsonDict) {
            id = JSONHelper.GetInt(jsonDict, "id", 0);
            name = JSONHelper.GetString(jsonDict, "name", "");
            job = JSONHelper.GetString(jsonDict, "job", "");
            country = JSONHelper.GetString(jsonDict, "country", "");
            bio = JSONHelper.GetString(jsonDict, "bio", "");
            mugshot = JSONHelper.GetString(jsonDict, "mugshot", "");
		}

        public override void DefineJSON (Dictionary<string, object> outDict)
		{
			// This is ReadOnly Game Data. no need to implement DefineJSON 
		}

        public override string ToString() {
            return "id=" + id + " name=" + name + " job=" + job 
                    + " country=" + country
                    + " mugshot=" + mugshot
                    + "\nbio:\n" + bio;
        }
    }
}