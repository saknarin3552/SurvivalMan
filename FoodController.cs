using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FoodController : MonoBehaviour {

    public Image currentFood;//ภาพแสดง Bar
    public Text txt;//แสดงข้อความ %
    public float food = 100;
    private float maxfood = 100;
    public static FoodController instance;

    // 100/100 = 1 
    // 99/100 = 0.99
    // 50/100 = 0.5


    void Start()
    {
        instance = this;
        InvokeRepeating("updateFoodHealth", 1.0f, 2f);
    }

    void Update()
    {
        float radio = food / maxfood; // = 100/100 = 1 
        currentFood.rectTransform.localScale = new Vector3(radio, 1, 1);
        txt.text = (radio * 100) + " % ";
    }

    void updateFoodHealth()
    {
        if (food > 0)
        {
            food -= 1f;
        }
    }
    
    //จะถูกเรียกใช้งานตอนกดใช้ Item เนื้อ
    public void healingFood()
    {
        food += 10;
        if (food >= maxfood)
        {
            food = maxfood;
        }
    }
}
