/*
Name: Tayvian Reed Eberle
Date: 10/2/2022
Desc: Handles health bar behavior for enemies and player
*/
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Tooltip("Whatever is in here is what the health bar keep track of")]
    public GameObject target;
    [SerializeField, Tooltip("If checked the health bar will follow the object it is assigned to")]
    bool follow;
    //Offset of Y axis follow behavior of the health bar
    float followDist;
    public HealthScript tHealth;
    Slider slider;
    // Start is called before the first frame update
    private void Start() {
        try{
            tHealth = target.GetComponent<HealthScript>();
        }
        catch {
            //If we cannot find a health script on assigned object, give it one and assume max health will be 50
            tHealth = target.AddComponent<HealthScript>();
            tHealth.maxHealth = 50;
        }
        slider = gameObject.GetComponent<Slider>();
        slider.maxValue = tHealth.maxHealth;
        followDist = gameObject.transform.localScale.y;
    }
    private void FixedUpdate() {
        if(follow){
            if(target != null){
                transform.position = new Vector2(target.transform.position.x, target.transform.position.y - followDist);
            }
        }
        ChangeValue();
    }
    // Update is called once per frame
    public void ChangeValue()
    {
        slider.value = tHealth.currentHealth;
        if(slider.value == 0){
            tHealth.DestroyCanvas();
            Destroy(gameObject);
        }
    }
}
