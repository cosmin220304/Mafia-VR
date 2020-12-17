using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Menu[] menus;
    public static MenuManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string menuName)
    {
        foreach(var menu in menus)
        {
            if (menu.Name == menuName)
            {
                menu.Open();
            }
            else
            {
                menu.Close();
            }
        }
    }

    public void CloseMenu(string menuName)
    {
        var menu = menus.FirstOrDefault(m => m.Name == menuName);
        menu.Close();
    }

    public void OpenMenu(Menu Menu)
    {
        foreach(var menu in menus)
        {
            if (menu.Name == Menu.Name)
            {
                menu.Open();
            }
            else
            {
                menu.Close();
            }
        }
    }

    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }
}
