using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class ResourceHelperTest : BaseTest {		
	public Image image;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		ShowScreenLog();

		
	}

	[Test]
	public void testMugshot1()
	{
		image.sprite = ResourceHelper.LoadMugshotSprite("f_05");
	}

	[Test]
	public void testMugshot2()
	{
		image.sprite = ResourceHelper.LoadMugshotSprite("m_33");
	}
}
