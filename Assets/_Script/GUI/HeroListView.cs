using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kencoder
{
    public class HeroListView : MonoBehaviour
    {
        // Callback Definition 
        public delegate void OnSelectedCallback(HeroListView sender, HeroData selectedHero);

            // Public 
        public OnSelectedCallback onSelected;

        [Header("UI Components")]
        [SerializeField] protected float m_topMargin = 10;
        [SerializeField] protected float m_spacing = 10;
        [SerializeField] protected HeroListItemView m_itemViewPrefab;
        [SerializeField] protected RectTransform m_contentTransform;

        // Internal data 
        protected ToggleGroup m_toggleGroup = null;
        protected HeroData m_selectedHero = null;
        protected List<HeroListItemView> m_itemViewList = new List<HeroListItemView>();

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public HeroData selectedHero {
            get {
                return m_selectedHero;
            }
        }

        public void SetHeroList(List<HeroData> dataList) {
            float position = m_topMargin;

            ClearItemView();

            foreach(HeroData data in dataList) {
                position = CreateItemView(data, position);
            }

            SetContentHeight(position);
        }

        ToggleGroup GetToggleGroup() {
            if(m_toggleGroup != null) {
                return m_toggleGroup;
            }
            m_toggleGroup = GetComponent<ToggleGroup>();
            return m_toggleGroup;
        }

        void SetContentHeight(float height) {
            Vector2 size = m_contentTransform.sizeDelta;
            size.y = height;

            m_contentTransform.sizeDelta = size;
        }

        float CreateItemView(HeroData heroData, float position) {
            GameObject go = Object.Instantiate(m_itemViewPrefab.gameObject) as GameObject;

            RectTransform rectTrans = go.transform as RectTransform;
            rectTrans.anchorMin = new Vector2(0.5f, 1);
            rectTrans.anchorMax = new Vector2(0.5f, 1);
            rectTrans.pivot = new Vector2(0.5f, 1);

            rectTrans.SetParent(m_contentTransform, false);
            rectTrans.anchoredPosition = new Vector2(0.5f, -position);
        
            // Setting the itemView 
            HeroListItemView itemView = go.GetComponent<HeroListItemView>();
            itemView.SetToggleGroup(GetToggleGroup());
            itemView.SetData(heroData);
            itemView.onSelected = OnItemViewSelected;

            m_itemViewList.Add(itemView);

            // 
            return position + rectTrans.sizeDelta.y + m_spacing;
            
            //itemView.toggle
        }

        void ClearItemView() {
            foreach(HeroListItemView view in m_itemViewList) {
                GameObject.Destroy(view.gameObject);
            }
            m_itemViewList.Clear();
        }


        void OnItemViewSelected(HeroListItemView itemView, bool isSelected) {
            if(itemView == null) {
                return;
            }

            HeroData hero = itemView.data;

            if(isSelected) {
                m_selectedHero = hero;
            }

            if(onSelected != null) {
                onSelected(this, m_selectedHero);
            }
        }

        public void Select(int index) {
            if(index < 0 || index >= m_itemViewList.Count) {
                return; // ken: out of bound 
            }

            m_itemViewList[index].Select();
        }

        public int GetIndexByHero(HeroData data) {
            for(int i=0; i<m_itemViewList.Count; i++) {
                if(m_itemViewList[i].data.id == data.id) {
                    return i;
                }
            }

            return -1;
        }

        public void SelectHero(HeroData data) {
            int index = GetIndexByHero(data);
            Select(index);
        }

        
        public void TestCreate(int count=10) {
            List<HeroData> heroList = Mock.GetHeroList(count);
            SetHeroList(heroList);
        }

    }
}