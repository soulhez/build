﻿using System;
using System.Collections.Generic;

namespace Build
{
    public static class TypeConstructor
    {
        public static List<ITypeDependencyObject> CreateDependencyObjects(Type type, bool defaultTypeInstantiation)
        {
            var dependencyObjects = new List<ITypeDependencyObject>();
            foreach (var constructorInfo in type.GetConstructors())
            {
                dependencyObjects.Add(new TypeDependencyObject(constructorInfo, defaultTypeInstantiation));
            }
            return dependencyObjects;
        }
    }
}