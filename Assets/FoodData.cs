using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FoodData", menuName = "Food Bonus", order = 51)]
public class FoodData : ScriptableObject
{

    public int speedBonus = 0;
    public int timeBonus = 0;
    public int bodyBonus = 0;
}
