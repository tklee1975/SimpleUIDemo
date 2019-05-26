using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;
using Kencoder;

public class GameDataManagerTest : BaseTest {		
	[Test]
	public void testLoad()
	{
		Debug.Log(GameDataManager.Instance.InfoHeroList());
	}

	[Test]
	public void test2()
	{
		Debug.Log("###### TEST 2 ######");
	}
}
