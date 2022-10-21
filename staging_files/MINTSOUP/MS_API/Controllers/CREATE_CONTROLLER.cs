using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using MS_API1_Users_LogicLayer;
using MS_API1_Users_Repo;
using MS_API1_Users_Model;
using Models;

namespace MS_API.Controllers
{
    [ApiController]
    [Route("mint-soup")]
    public class CREATE_CONTROLLER : ControllerBase
    {
        private readonly ICREATE_LogicLayer _create_Logic;
        private readonly ICHECK_AccessLayer _check_Repo;
        public CREATE_CONTROLLER( ICREATE_LogicLayer _create,ICHECK_AccessLayer _check)
        {
            this._create_Logic = _create;
            this._check_Repo = _check;
        }
        public enum _CONTROLLER_RESPONSEmsg{
            No_OBJ_due_to_null,
            Full_OBJ
        }

//---------------------------------------------------CREATE VIEWER SECTION-----------------------------------------------------------------
        /// <summary>
        /// This is the method to test if a viewer successfully gets their account with their aith0ID
        /// </summary>
        /// <param name="auth0ID"></param>
        /// <returns>returns an async action result as a Viewer</returns>
        [HttpPost("register")]
        public async Task<ActionResult<Models.Viewer?>> CREATE_myViewer_by_auth0ID(Models.CREATE_Viewer_on_signUP_with_auth0ID_DTO CREATE_VIEWER_DTO)
        {
            if(ModelState.IsValid)
            {
                CHECK_AccessLayer.CHECKSTATUS checkAdmin = await this._check_Repo.CHECK_Admin_by_Email(CREATE_VIEWER_DTO?.Auth0ID);
                CHECK_AccessLayer.CHECKSTATUS checkViewer = await this._check_Repo.CHECK_Viewer_by_Email(CREATE_VIEWER_DTO?.Auth0ID);
                
                //Check if already an admin
                if((checkAdmin == CHECK_AccessLayer.CHECKSTATUS.TRUE)){
                    Console.WriteLine($"\n\n\t The user with email {CREATE_VIEWER_DTO?.Email} is already an admin");
                    return Conflict($"choose another email or sign in with this one with {CREATE_VIEWER_DTO?.Email}");
                }

                //Check if already a viewer
                if((checkViewer == CHECK_AccessLayer.CHECKSTATUS.TRUE)){
                    Console.WriteLine($"\n\n\t The user with email {CREATE_VIEWER_DTO?.Email} is already a viewer");
                    return Conflict($"choose another email or sign in with this one with {CREATE_VIEWER_DTO?.Email}");
                }

                (Models.Viewer?, CHECK_AccessLayer.CHECKSTATUS) viewer = await this._create_Logic.CREATE_myViewer_by_auth0ID(CREATE_VIEWER_DTO);
                if(viewer.Item2.ToString() == "SAVED")
                {
                    return Created("register",viewer);
                }
                else
                {
                    return Conflict(viewer.Item2.ToString());
                }
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End CREATE_myViewer_by_auth0ID
        
        



    }
}