using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Shop Data", menuName = "Shop" )]
public class Shop : ScriptableObject
{

[SerializeField] private string potionName;
[SerializeField] private string description;
[SerializeField] private string cost;

public string PotionName {get {return potionName;}}
public string Description {get {return description;}}
public string Cost {get {return cost;}}

}


