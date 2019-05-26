using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kencoder
{
    public class HeroListItemView : MonoBehaviour
    {   
        // Callback Definition 
        public delegate void OnSelectedCallback(HeroListItemView sender, bool isSelected);

        // Public 
        public OnSelectedCallback onSelected;

        // User Interface 
        [Header("UI Components")]
        [SerializeField] protected Toggle m_toggle;
        [SerializeField] protected Image m_bgImage;
        [SerializeField] protected Text m_nameText;
        [SerializeField] protected Sprite m_spriteOn;
        [SerializeField] protected Sprite m_spriteOff;
        [SerializeField] protected Image m_mugshotImage;

        // Internal Data 
        protected HeroData m_heroData;

        // Start is called before the first frame update
        void Awake()
        {
            Debug.Log("CreateItemView: Awake");
            m_toggle.group = GetComponentInParent<ToggleGroup>();
            m_toggle.onValueChanged.AddListener(OnValueChanged);

            SetState(m_toggle.isOn);
        }

        public void SetToggleGroup(ToggleGroup toggleGroup) {
            m_toggle.group = toggleGroup;
        }

        public void Select() {
            m_toggle.isOn = true;
        }

        void SetState(bool value) {
            Color color = m_bgImage.color;
            m_bgImage.sprite = value ? m_spriteOn : m_spriteOff;
            color.a = value ? 1.0f : 0.2f;
            m_bgImage.color = color;
        }

        void OnValueChanged(bool value) {
            SetState(value);

            if(onSelected != null) {
                onSelected(this, value);
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public HeroData data {
            get {
                return m_heroData;
            }
        }

        public void SetData(HeroData data) {
            if(data == null) {
                return;
            }

            m_heroData = data;
            m_mugshotImage.sprite = ResourceHelper.LoadMugshotSprite(data.mugshot);
            m_nameText.text = data.name;
        }
    }
}