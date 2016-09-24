using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OfficeLogger; 
public class CustomUtil
{
    /// <summary>
    /// Gets the unique ID
    /// </summary>
    /// <returns>The unique I.</returns>
    /// <param name="item1">Item1.</param>
    /// <param name="item2">Item2.</param>
    public static string GetUniqueID (string item1, int item2)
    {
        return item1 + "_" + item2.ToString();
    }
    public static string GetUniqueID (string item1, string item2)
    {
        return item1 + "_" + item2;
    }


}
