using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;

public class ContentHandler : MonoBehaviour
{
    private string matchedProperty;
    void Start()
    {

        var targetClass = GameObject.Find("Main Camera").GetComponent("Camera");
        Type type = targetClass.GetType();
        foreach (var property in type.GetProperties())
        {

            if(property.Name.StartsWith("backgroundColor"))
            {

                matchedProperty = property.Name;
                break;
            }
        }
        PropertyInfo propertyInfo = type.GetProperty(matchedProperty);
        propertyInfo.SetValue(targetClass, Color.gray);
    }
}
