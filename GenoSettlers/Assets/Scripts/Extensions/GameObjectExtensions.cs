using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public static class GameObjectExtensions
{
    //public static bool TryGetGenericComponent<T>(this GameObject gameObject, out Component component) where T : Component
    //{
    //    component = default;
    //    Type wantedType = typeof(T);
    //    if (!wantedType.IsGenericType)
    //        return false;

    //    Type[] wantedTypeGenericTypes = wantedType.GetGenericArguments();

    //    foreach (Component innerComponent in gameObject.GetComponents<Component>())
    //    {
    //        Type componentType = innerComponent.GetType().BaseType;
    //        if (!componentType.IsGenericType)
    //            continue;
            
    //        Type[] componentGenericTypes = componentType.GetGenericArguments();
    //        if (componentGenericTypes.Length != wantedTypeGenericTypes.Length)
    //            continue;

    //        for(int i = 0; i < wantedTypeGenericTypes.Length; i++)
    //        {
    //            if (!wantedTypeGenericTypes[i].IsAssignableFrom(componentGenericTypes[i]))
    //                break;

    //        component = innerComponent;
    //        return true;
    //        }
    //    }
    //    return false;
    //}
}
