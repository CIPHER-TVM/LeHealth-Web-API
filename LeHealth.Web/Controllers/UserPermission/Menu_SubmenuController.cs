using LeHealth.Catalogue.API;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LeHealth.Base.API.Controllers.UserPermission
{
    [Route("api/menu")]
    [ApiController]
    public class Menu_SubmenuController : ControllerBase
    {
        private readonly ILogger<Menu_SubmenuController> logger;
        private readonly IMenuSubmenuService  menuSubmenuService;
        public Menu_SubmenuController(ILogger<Menu_SubmenuController> _logger, IMenuSubmenuService _menuSubmenuService)
        {
            logger = _logger;
            menuSubmenuService = _menuSubmenuService;
        }


        [HttpPost]
        [Route("SaveMenuItems")]
        public ResponseDataModel<string> SaveMenuItems(MenuModel obj)
        {
            try
            {
                string retval = menuSubmenuService.SaveMenuItems(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = retval,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "menuController", "SaveMenuItems()");

                return new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
        }
        [HttpPost]
        [Route("GetMenuItem/{MenuId}")]
        public ResponseDataModel<MenuModel> GetMenuItem(int MenuId)
        {
            MenuModel menu = new MenuModel();
            try
            {
                menu = menuSubmenuService.GetMenuItem(MenuId);
                var response = new ResponseDataModel<MenuModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = menu
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<MenuModel>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
            finally
            {
            }
        }

        [HttpPost]
        [Route("GetMenuMap/{GroupId}")]
        public ResponseDataModel<List<int>> GetMenuMap(int GroupId)
        {
            List<int> menu = new List<int>();
            try
            {
                menu = menuSubmenuService.GetMenuMap(GroupId);
                var response = new ResponseDataModel<List<int>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = menu
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<List<int>>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
            finally
            {
            }
        }


        [HttpPost]
        [Route("GetLeftmenu/{user}/{BranchesId}")]
        public ResponseDataModel<List<Leftmenumodel>> GetLeftmenu(int user,int BranchesId)
        {
            List<Leftmenumodel> menu = new List<Leftmenumodel>();
            try
            {
               menu = menuSubmenuService.GetLeftmenu(user, BranchesId);
                var response = new ResponseDataModel<List<Leftmenumodel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = menu
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<List<Leftmenumodel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
            finally
            {
            }
        }
        [Route("GetMenuItems")]
        public ResponseDataModel<IEnumerable<MenuModel>> GetMenuItems()
        {
           List< MenuModel> Menus = new List<MenuModel>();
            try
            {
                Menus = menuSubmenuService.GetMenuItems();
                var response = new ResponseDataModel<IEnumerable<MenuModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = Menus
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<MenuModel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
            finally
            {
            }
        }

        #region
        [HttpPost]
        [Route("SaveSubMenuItems")]
        public ResponseDataModel<string> SaveSubMenuItems(SubmenuModel obj)
        {
            try
            {
                string retval = menuSubmenuService.SaveSubMenuItems(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = retval,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "menuController", "SaveSubMenuItems()");

                return new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
        }
        [HttpPost]
        [Route("GetSubmenuMenuItem/{SubMenuId}")]
        public ResponseDataModel<SubmenuModel> GetSubmenuMenuItem(int SubMenuId)
        {
            SubmenuModel menu = new SubmenuModel();
            try
            {
                menu = menuSubmenuService.GetSubmenuMenuItem(SubMenuId);
                var response = new ResponseDataModel<SubmenuModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = menu
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<SubmenuModel>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
            finally
            {
            }
        }
        [Route("GetSubMenuItems")]
        public ResponseDataModel<IEnumerable<SubmenuModel>> GetSubMenuItems()
        {
            List<SubmenuModel> Menus = new List<SubmenuModel>();
            try
            {
                Menus = menuSubmenuService.GetSubMenuItems();
                var response = new ResponseDataModel<IEnumerable<SubmenuModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = Menus
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SubmenuModel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
            finally
            {
            }
        }
        #endregion
        [HttpPost]
        [Route("SaveMenumap")]
        public ResponseDataModel<string> SaveMenumap(MenuMap obj)
        {
            try
            {
                string retval = menuSubmenuService.SaveMenumap(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = retval,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "menuController", "SaveMenumap()");

                return new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
        }

    }
}
