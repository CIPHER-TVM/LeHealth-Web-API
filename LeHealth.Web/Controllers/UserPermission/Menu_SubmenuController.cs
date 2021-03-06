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
        private readonly IMenuSubmenuService menuSubmenuService;
        public Menu_SubmenuController(ILogger<Menu_SubmenuController> _logger, IMenuSubmenuService _menuSubmenuService)
        {
            logger = _logger;
            menuSubmenuService = _menuSubmenuService;
        }

        /// <summary>
        /// API For saving menu items 
        /// </summary>
        /// <param name="obj">Menu item details</param>
        /// <returns>SUccess or reason for failure</returns>
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
        /// <summary>
        /// API for getting Menu item detail of a specific menu
        /// </summary>
        /// <param name="MenuId">Menu Id Primary key</param>
        /// <returns>Menu item's details</returns>
        [HttpPost]
        [Route("GetMenuItem/{MenuId}")]
        public ResponseDataModel<MenuModel> GetMenuItem(int MenuId)
        {
            try
            {
                MenuModel menu = new MenuModel();
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
            try
            {
                List<int> menu = new List<int>();
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

        /// <summary>
        /// API for binding data to leftside burger menu
        /// </summary>
        /// <param name="user">user's id</param>
        /// <param name="BranchesId">Branch's id</param>
        /// <returns>Leftside menu and submenu items</returns>
        [HttpPost]
        [Route("GetLeftmenu/{user}/{BranchesId}")]
        public ResponseDataModel<List<Leftmenumodel>> GetLeftmenu(int user, int BranchesId)
        {
            try
            {
                List<Leftmenumodel> menu = new List<Leftmenumodel>();
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


        [HttpPost]
        [Route("GetMenuongroups/{user}/{BranchesId}/{GroupIds}")]
        public ResponseDataModel<Lefmenugroupmodel> GetMenuongroups(int user, int BranchesId, string GroupIds)
        {
            
            try
            {
                Lefmenugroupmodel menu = new Lefmenugroupmodel();
                menu = menuSubmenuService.GetMenuongroups(user, BranchesId, GroupIds);
                var response = new ResponseDataModel<Lefmenugroupmodel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = menu
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<Lefmenugroupmodel>()
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
        [HttpPost]
        public ResponseDataModel<IEnumerable<MenuModel>> GetMenuItems()
        {
            try
            {
                List<MenuModel> Menus = new List<MenuModel>();
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
        /// <summary>
        /// API For saving submenu items
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
        /// <summary>
        /// api for getting submenu item's details by its primary key id
        /// </summary>
        /// <param name="SubMenuId"></param>
        /// <returns>submenu item's details</returns>
        [HttpPost]
        [Route("GetSubmenuMenuItem/{SubMenuId}")]
        public ResponseDataModel<SubmenuModel> GetSubmenuMenuItem(int SubMenuId)
        {
            try
            {
                SubmenuModel menu = new SubmenuModel();
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
        /// <summary>
        /// api for getting all submenu items
        /// </summary>
        /// <returns>List of all submenu items</returns>
        [HttpPost]
        [Route("GetSubMenuItems")]
        public ResponseDataModel<IEnumerable<SubmenuModel>> GetSubMenuItems()
        {
            try
            {
                List<SubmenuModel> Menus = new List<SubmenuModel>();
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
