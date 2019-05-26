using System.Collections;
using System.Collections.Generic;

namespace Kencoder
{
    public class Mock 
    {
        public static List<HeroData> GetHeroList(int size=5) {
            List<HeroData> result = new List<HeroData>();

            for(int i=0; i<size; i++) {
                HeroData data = GetHero();

                data.id = (i+1);
                data.name = "測試名字 " + i;

                result.Add(data);
            }

            return result;
        }
        
        public static HeroData GetHero() {
            HeroData data = new HeroData();

            data.id = 1;
            data.name = "柏拉圖";
            data.country = "希臘";
            data.job = "哲學家";
            data.mugshot = "m_33";
            data.bio = "柏拉圖生於雅典的貴族家庭，他的家庭據傳是古雅典國王的後裔，他也是當時雅典知名的政治家柯里西亞斯的姪子。\n\n"
                        + "柏拉圖出色的學習能力和其他才華，古希臘人還稱讚他為阿波羅之子，並稱在柏拉圖還是嬰兒的時候曾有蜜蜂停留在他的嘴唇上，才會使他口才如此甜蜜流暢。\n\n"
                        + "朋友蘇格拉底受審并被判死刑，28歲的柏拉圖對當時的政治體制徹底絕望，於是開始遊遍歐州以尋求知識。據說他在四十歲時，結束旅行返回雅典，並創立了自己的學校—即著名的柏拉圖學院。";


            return data;
        }
    }

}