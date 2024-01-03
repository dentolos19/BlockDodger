using System.Runtime.CompilerServices;
using UnityEngine;

public static class GameStore
{
    public static int HighestScore
    {
        get => Get(0);
        set => Set<int>(value);
    }

    public static float Sensitivity
    {
        get => Get<float>();
        set => Set<float>(value);
    }

    private static TValue Get<TValue>(TValue defaultValue = default, [CallerMemberName] string propertyName = null)
    {
        return typeof(TValue).Name switch
        {
            "Int32" => (TValue)(object)PlayerPrefs.GetInt(propertyName, (int)(object)defaultValue),
            "Single" => (TValue)(object)PlayerPrefs.GetFloat(propertyName, (float)(object)defaultValue),
            "String" => (TValue)(object)PlayerPrefs.GetString(propertyName, (string)(object)defaultValue),
            _ => defaultValue
        };
    }

    private static void Set<TValue>(object value, [CallerMemberName] string propertyName = null)
    {
        switch (typeof(TValue).Name)
        {
            case "Int32":
                PlayerPrefs.SetInt(propertyName, (int)value);
                break;
            case "Single":
                PlayerPrefs.SetFloat(propertyName, (float)value);
                break;
            case "String":
                PlayerPrefs.SetString(propertyName, (string)value);
                break;
            default:
                throw new System.NotImplementedException();
        }
    }
}