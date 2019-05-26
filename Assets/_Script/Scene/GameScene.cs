using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kencoder;

public class GameScene : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] protected HeroDetailView m_detailView;
	[SerializeField] protected HeroListView m_listView;

    [Header("Setting")]
    [SerializeField] protected Texture2D cursorTexture;

    // Internal Data 
    protected List<HeroData> m_heroList;


    // Start is called before the first frame update
    void Start()
    {
        m_heroList = GameDataManager.Instance.heroList;
        SetupListView();

        SetupCursor();

    }

    void SetupCursor() {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    void SetupListView() {
        m_listView.onSelected = (HeroListView itemView, HeroData hero) => {
            ShowHero(hero);
		};

        m_listView.SetHeroList(m_heroList);
        m_listView.SelectHero(m_heroList[0]);
    }

    void ShowHero(HeroData hero) {
        m_detailView.SetData(hero);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
