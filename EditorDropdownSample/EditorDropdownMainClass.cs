using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using System.Reflection;


public class EditorDropdownMainClass : MonoBehaviour
{
    public int NamespaceIndex { get; set; }
    public int ClassIndex { get; set; }
    public int MethodIndex { get; set; }

    public List<string> Namespaces => RefreshTypes();
    public List<string> Classes => RefreshClasses();
    public List<string> Methods => RefreshMethods();



    [ContextMenu("Refresh Types options")]
    void RefreshOptions()
    {
        PlayerPrefs.SetString("AssemblyTypes", JsonConvert.SerializeObject(Assembly.GetExecutingAssembly().GetTypes().ToList()));
        RefreshTypes();
        RefreshClasses();
        RefreshMethods();
    }



    List<string> RefreshTypes()
    {
        IList<Type> m_assembly = JsonConvert.DeserializeObject<List<Type>>(PlayerPrefs.GetString("AssemblyTypes"));
        var m_namespaces = m_assembly.Where(x => x.Namespace != null).Select(x => x.Namespace).Distinct().ToList();
        return m_namespaces;
    }

    List<string> RefreshClasses()
    {
        IList<Type> m_assembly = JsonConvert.DeserializeObject<List<Type>>(PlayerPrefs.GetString("AssemblyTypes"));
        var m_namespaces = RefreshTypes();
        var m_namespace = m_namespaces.ElementAt(NamespaceIndex);
        var m_classes = m_assembly.Where(x => x.IsClass && x.Namespace == m_namespace).Select(x => x.Name).Distinct().ToList();
        return m_classes;
    }

    List<string> RefreshMethods()
    {
        var m_methods = new List<string>();
        IList<Type> m_assembly = JsonConvert.DeserializeObject<List<Type>>(PlayerPrefs.GetString("AssemblyTypes"));
        var m_namespaces = RefreshTypes();
        var m_namespace = m_namespaces.ElementAt(NamespaceIndex);
        var m_classes = RefreshClasses();

        if (m_classes.Any())
        {
            var m_class = m_classes.ElementAt(ClassIndex);

            m_methods = m_assembly.Where(x => x.IsClass && x.Name == m_class).FirstOrDefault().GetMethods().Select(x => x.Name).ToList();
        }

        return m_methods;
    }
}





