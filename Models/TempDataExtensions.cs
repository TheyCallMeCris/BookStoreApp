﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

public static class TempDataExtensions
{
    public static T Get<T>(this ITempDataDictionary tempData, string key)
    {
        object o;
        tempData.TryGetValue(key, out o);
        return o == null ? default(T) : JsonConvert.DeserializeObject<T>((string)o);
    }

    public static void Set<T>(this ITempDataDictionary tempData, string key, T value)
    {
        tempData[key] = JsonConvert.SerializeObject(value);
    }
}