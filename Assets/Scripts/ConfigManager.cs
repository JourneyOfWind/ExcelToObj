using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager
{
    public static T Load<T>()where T: ScriptableObject{
        string path = "ScriptableObjs/"+ typeof(T).Name;
        return Resources.Load<T>(path);
    }
}
