using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;
using Kencoder;

public class DetailViewTest : BaseTest {		
	public HeroDetailView detailView;
	public HeroListItemView itemView;
	public HeroListView listView;

	public List<HeroData> heroList;

	void Start()
	{
		ShowScreenLog();

		itemView.onSelected = (HeroListItemView itemView, bool isSelected) => {
			HeroData data = itemView.data;
			string name = data == null ? "Known" : data.name;

			UpdateLog("ItemView is selected. hero=" + name + " isSelected=" + isSelected);
		};

		heroList = Mock.GetHeroList();
	}

	[Test]
	public void SetHero2() {
		listView.SelectHero(heroList[3]);
	}

	[Test]
	public void SetFirstHero() {
		listView.Select(0);
	}


	[Test]
	public void SetListView() {
		//listView.TestCreate(20);
		
		listView.SetHeroList(heroList);
		listView.onSelected = (HeroListView listView, HeroData selected) => {
			UpdateLog("Selected: " + selected.ToString());
			detailView.SetData(selected);
		};
	}

	[Test]
	public void SetData()
	{
		HeroData data = Mock.GetHero();
		Debug.Log("Data:\n" + data.ToString());

		detailView.SetData(data);
	}

	[Test]
	public void TestListItem()
	{
		Debug.Log("###### TEST 2 ######");

		HeroData data = Mock.GetHero();
		Debug.Log("Data:\n" + data.ToString());

		itemView.SetData(data);
	}
}
