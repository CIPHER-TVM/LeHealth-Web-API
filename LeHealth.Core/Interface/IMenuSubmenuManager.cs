using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface IMenuSubmenuManager
    {
        MenuModel GetMenuItem(int menuId);
        List<MenuModel> GetMenuItems();
        string SaveMenuItems(MenuModel obj);
        SubmenuModel GetSubmenuMenuItem(int subMenuId);
        List<SubmenuModel> GetSubMenuItems();
        string SaveSubMenuItems(SubmenuModel obj);
        string SaveMenumap(MenuMap obj);
        List<int> GetMenuMap(int groupId);
        List<Leftmenumodel> GetLeftmenu(int user, int branchesId);
    }
}
