using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MS_API1_Users_API;
using MS_API1_Users_Model;
using MS_API1_Users_LogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace MS_AP1
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViewerController : ControllerBase
    {
        private readonly Users_LogicLayer _LogicLayer;
        public ViewerController(Users_LogicLayer _Logic)
        {
            this._LogicLayer = _Logic;
        }

        /// <summary>
        /// This is the method to test if a viewer successfully gets their account with their aith0ID
        /// </summary>
        /// <param name="auth0ID"></param>
        /// <returns>returns an async action result as a Viewer</returns>
        [HttpPost("account")]
        public async Task<ActionResult<Models.Viewer>> GET_myViewer_by_auth0ID(Models.GET_Viewer_with_anID_DTO getMyViewerDTO)
        {
            if(ModelState.IsValid)
            {
                Models.Viewer? viewer = await this._LogicLayer.GET_myViewer_by_auth0ID(getMyViewerDTO?.Auth0ID);
                if(viewer != null)
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
        }//End GET_myViewer_by_auth0ID

        /// <summary>
        /// This is the method to test if a viewer successfully gets an account with their viewerID
        /// </summary>
        /// <param name="auth0ID"></param>
        /// <returns>returns an async action result as a Viewer</returns>
        [HttpPost("account")]
        public async Task<ActionResult<Models.Viewer>> GET_aViewer_by_viewerID(Models.GET_Viewer_with_anID_DTO? getMyViewerDTO)
        {
            if(ModelState.IsValid)
            {
                Models.Viewer? viewer = await this._LogicLayer.GET_aViewer_by_viewerID(getMyViewerDTO?.ViewerID);
                if(viewer != null)
                {
                    return Ok(viewer);
                }
                else
                {
                    return NotFound("This viewer could not be found");
                }
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End GET_aViewer_by_viewerID

    }
}