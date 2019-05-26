using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHelper : MonoBehaviour
{
    public static Sprite LoadMugshotSprite(string mugshotID) {
        return LoadSprite("Mugshot/" + mugshotID);
    }

    public static Sprite LoadSprite(string path) {
        return Resources.Load<Sprite>(path) as Sprite;	
    }

}