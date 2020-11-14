using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    //body part we are changing 
    public SpriteRenderer bodypart;
    //all the options we own for this bodypart TODO
    public List<Sprite> options;

    public int currentOption = 0;

    public void nextOption()
    {
        currentOption++;
        if(currentOption >= options.Count){
            currentOption = 0;
        }

        bodypart.sprite = options[currentOption];
    }

    public void previousOption()
    {
        currentOption--;
        if(currentOption <= 0){
            currentOption = options.Count - 1;
        }

        bodypart.sprite = options[currentOption];
    }
}
