using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FruitData", menuName = "Scriptable Object/Fruit Data", order =int.MaxValue)]
public class FruitData : ScriptableObject
{
    [SerializeField] string fruitName;
    public string FruitName { get { return fruitName; } }
    [SerializeField] float none_time;
    public float None_time { get { return none_time; } }
    [SerializeField] float flower_Time;
    public float Flower_Time { get { return flower_Time; } }
    [SerializeField] float mid_Time;
    public float Mid_Time { get { return mid_Time; } }
    [SerializeField] Sprite flowerSprite;
    public Sprite FlowerSprite { get { return flowerSprite; } }
    [SerializeField] Sprite middleFruitSprite;
    public Sprite MiddleFruitSprite { get { return middleFruitSprite; } }
    [SerializeField] Sprite fruitSprite;
    public Sprite FruitSprite { get { return fruitSprite; } }
}
