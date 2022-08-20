using System;
using UnityEngine;
using System.Reflection;

//using System.Linq;
//Assembly.GetExecutingAssembly().GetTypes().ToList()
//Assembly.GetExecutingAssembly().GetTypes().ToList().Where(x => x.Namespace != null);
//Assembly.GetExecutingAssembly().GetTypes().ToList().Where(x => x.IsClass && x.Name=="xptoClass");
//PlayerPrefs.SetString("AssemblyTypes", JsonConvert.SerializeObject(Assembly.GetExecutingAssembly().GetTypes().ToList()));


public class ReflectionFunctionInvoker : MonoBehaviour
{
    public int NumberToBeFilled = 0;

    [ContextMenu("Fill the number")]
    public void fillI()
    {
        var parameter = new CustomType()
        {
            UselessGameObject = null,
            MaxRandomNumber = 99999
        };
        string classStr = "TypeToBeCalled";
        Type classByString = Type.GetType(classStr);
        var classInstance = Activator.CreateInstance(classByString);
        MethodInfo methodByString = classByString.GetMethod("RandomInt");

        NumberToBeFilled = (int)methodByString.Invoke(classInstance, new object[] { parameter });
    }
}

public class CustomType
{
    public int MaxRandomNumber { get; set; }
    public GameObject UselessGameObject;
}

public class TypeToBeCalled
{
    public int RandomInt(CustomType attr)
    {
        return new System.Random().Next(attr.MaxRandomNumber);
    }
}
