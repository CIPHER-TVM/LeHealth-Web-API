using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public class MenuModel
    {
        public int Mid { get; set; }
        public string Menu { get; set; }
        public string MenuIcon { get; set; }
        public string Link { get; set; }
        public int? SubMenuFlag { get; set; }
        public string MenuAlias { get; set; }
        public List<int> submenuIds { get; set; }
    }
    public class SubmenuModel
    {
        public int SId { get; set; }
        public int? MainMenuId { get; set; }
        public string SubMenu { get; set; }
        public string SubMenuLink { get; set; }
        public string SubMenuIcon { get; set; }
        public string SubMenuAlias { get; set; }
    }

    public class MenuMap
    {
        public int groupId { get; set; }
        public List<int> menuIds { get; set; }
        
    }
    public class Leftmenumodel: MenuModel
    {
        public List<SubmenuModel> SubMenus { get; set; }
    }
}
