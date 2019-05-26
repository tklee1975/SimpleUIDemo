using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kencoder
{
    
    public class HeroDetailView : MonoBehaviour
    {
        [SerializeField] protected Text m_nameText;
        [SerializeField] protected Text m_countryText;
        [SerializeField] protected Text m_jobText;
        [SerializeField] protected Text m_bioText;
        [SerializeField] protected Image m_mugshotImage;

        const string k_jobDesc = "職業：<color=#ffff00>#v</color>";
        const string k_countryDesc = "國家：<color=#ffff00>#v</color>";

        // Start is called before the first frame update
        void Start()
        {
            
        }

        public void SetData(HeroData data) {
            if(data == null) {
                return;
            }

            m_mugshotImage.sprite = ResourceHelper.LoadMugshotSprite(data.mugshot);
            m_nameText.text = data.name;
            m_countryText.text = k_countryDesc.Replace("#v", data.country);
            m_jobText.text = k_jobDesc.Replace("#v", data.job);
            m_bioText.text = data.bio;
        }
    }
}