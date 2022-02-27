using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface IMenuSubmenuService
    {
        string SaveMenuItems(MenuModel obj);
        MenuModel GetMenuItem(int menuId);
        List<MenuModel> GetMenuItems();
        string SaveSubMenuItems(SubmenuModel obj);
        SubmenuModel GetSubmenuMenuItem(int subMenuId);
        List<SubmenuModel> GetSubMenuItems();
    }
}
