
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.Service
{
    public class MenuSubmenuService : IMenuSubmenuService
    {
        private readonly IMenuSubmenuManager  menuSubmenuManager;

        public MenuSubmenuService(IMenuSubmenuManager  _menuSubmenuManager)
        {
            menuSubmenuManager = _menuSubmenuManager;
        }
        public MenuModel GetMenuItem(int menuId)
        {
            return menuSubmenuManager.GetMenuItem(menuId);
        }

        public List<MenuModel> GetMenuItems()
        {
            return menuSubmenuManager.GetMenuItems();
        }

      

        public string SaveMenuItems(MenuModel obj)
        {
            return menuSubmenuManager.SaveMenuItems(obj);
        }

        public string SaveSubMenuItems(SubmenuModel obj)
        {
            return menuSubmenuManager.SaveSubMenuItems(obj);
        }
        public string SaveMenumap(MenuMap obj)
        {
            return menuSubmenuManager.SaveMenumap(obj);
        }
        public List<Leftmenumodel> GetLeftmenu(int user, int branchesId)
        {
            return menuSubmenuManager.GetLeftmenu(user, branchesId);
        }
        public Lefmenugroupmodel GetMenuongroups(int user, int branchesId, string groupIds)
        {
            return menuSubmenuManager.GetMenuongroups(user, branchesId, groupIds);
        }
        public List<int> GetMenuMap(int groupId)
        {
            return menuSubmenuManager.GetMenuMap(groupId);
        }
        public List<SubmenuModel> GetSubMenuItems()
        {
            return menuSubmenuManager.GetSubMenuItems();
        }

        public SubmenuModel GetSubmenuMenuItem(int subMenuId)
        {
            return menuSubmenuManager.GetSubmenuMenuItem(subMenuId);
        }
    }
}
