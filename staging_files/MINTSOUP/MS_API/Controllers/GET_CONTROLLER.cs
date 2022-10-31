using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


using MS_API1_Users_LogicLayer;
using MS_API1_Users_Model;
using MS_API1_Users_Repo;
using Models;

namespace MS_API.Controllers
{
    [ApiController]
    [Route("mint-soup")]
    [Authorize]
    public class GET_CONTROLLER : ControllerBase
    {
        private readonly IGET_LogicLayer _LogicLayer;
        private readonly ICHECK_AccessLayer _CheckRepo;

        public GET_CONTROLLER(IGET_LogicLayer _Logic, ICHECK_AccessLayer _check)
        {
            this._LogicLayer = _Logic;
            this._CheckRepo = _check;
        }

//-------------------------------------------------------GET VIEWER SECTION----------------------------------------------------
        /// <summary>
        /// This is the method to test if a viewer successfully gets their account with their aith0ID
        /// </summary>
        /// <param name="auth0ID"></param>
        /// <returns>returns an async action result as a Viewer</returns>
        [HttpPost("my-viewer")]
        public async Task<ActionResult<Models.Viewer?>> GET_myViewer_by_auth0ID(Models.GET_with_anAuth0ID_DTO getMyViewerDTO)
        {
            if(ModelState.IsValid)
            {
                (Models.Viewer?, string) viewer = await this._LogicLayer.GET_myViewer_by_auth0ID(getMyViewerDTO?.Auth0ID);
                if(viewer.Item1?.Auth0ID == getMyViewerDTO?.Auth0ID)
                {
                    // ActionResult<Viewer?> res1 =  new ActionResult<Viewer?>(viewer.Item1);
                    // OkObjectResult<string> res2 =  new OkObjectResult<string>(viewer.Item2);
                    return Ok(viewer.Item1);
                }
                else
                {
                    return NotFound("Your account could not be found");
                }
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End GET_myViewer_by_auth0ID

//-------------------------------------------------------GET VIEWER - through LOGIN SECTION----------------------------------------------------
        /// <summary>
        /// This is the method to test if a viewer successfully gets their account with their aith0ID
        /// </summary>
        /// <param name="auth0ID"></param>
        /// <returns>returns an async action result as a Viewer</returns>
        [HttpPost("login")]
        public async Task<ActionResult<Models.Viewer?>> GET_myViewer_by_LOGIN_with_auth0ID_and_Email(Models.GET_LOGIN_with_anAuth0ID_and_Email_DTO getMyViewerDTO)
        {
            if(ModelState.IsValid)
            {
                CHECK_AccessLayer.CHECKSTATUS check = await this._CheckRepo.CHECK_Viewer_by_Email(getMyViewerDTO?.Email);
                if(check.ToString() == "FALSE"){return NotFound($"The user '{getMyViewerDTO?.Email}' could not be found at - {DateTime.Now} ");}

                (Models.Viewer?, string) viewer = await this._LogicLayer.GET_myViewer_by_auth0ID(getMyViewerDTO?.Auth0ID);
                if(viewer.Item1?.Auth0ID == getMyViewerDTO?.Auth0ID)
                {
                    // ActionResult<Viewer?> res1 =  new ActionResult<Viewer?>(viewer.Item1);
                    // OkObjectResult<string> res2 =  new OkObjectResult<string>(viewer.Item2);
                    return Ok(viewer.Item1);
                }
                else
                {
                    return NotFound("Your account exists but could not be found");
                }
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End GET_myViewer_by_auth0ID


//-------------------------------------------------------GET ADMIN SECTION----------------------------------------------------
        /// <summary>
        /// This is the method gets your admin account with your aith0ID
        /// </summary>
        /// <param name="auth0ID"></param>
        /// <returns>returns an async action result as a admin</returns>
        [HttpPost("my-admin")]
        public async Task<ActionResult<(Models.Admin?, string)>> GET_myAdmin_by_auth0ID(Models.GET_with_anAuth0ID_DTO getMyViewerDTO)
        {
            if(ModelState.IsValid)
            {
                (Models.Admin?, string) viewer = await this._LogicLayer.GET_myAdmin_by_auth0ID(getMyViewerDTO?.Auth0ID);
                if(viewer.Item1?.Auth0ID == getMyViewerDTO?.Auth0ID)
                {
                    return Ok(viewer);
                }
                else
                {
                    return NotFound("Your account could not be found");
                }
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End GET_myAdmin_by_auth0ID





    }
}