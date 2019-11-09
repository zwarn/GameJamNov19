using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class FloatReference : ScriptableObject
{
    public float value, initialValue;




    public void Reset()
    {
        value = initialValue;
    }



}
