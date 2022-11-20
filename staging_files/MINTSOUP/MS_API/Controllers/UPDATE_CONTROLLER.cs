using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


using MS_API1_Users_Repo;
using MS_API1_Users_LogicLayer;

namespace MS_API.Controllers
{
    [ApiController]
    [Route("mint-soup")]
    [Authorize]
    public class UPDATE_CONTROLLER : ControllerBase
    {
        private readonly IUPDATE_AccessLayer _update_Repo;
        private readonly IGET_LogicLayer _get_Logic;
        private readonly IGET_AccessLayer _get_Repo;
        private readonly ICHECK_AccessLayer _check_Repo;
        public UPDATE_CONTROLLER( IUPDATE_AccessLayer _update,ICHECK_AccessLayer _check, IGET_LogicLayer _get, IGET_AccessLayer _get_repo)
        {
            this._update_Repo = _update;
            this._check_Repo = _check;
            this._get_Logic = _get;
            this._get_Repo = _get_repo;
        }
        
        //[HttpPut("update-my-viewer")]
        //public async Task<ActionResult<Models.Viewer?>> UPDATE_myViewer_by_MSToken(Models.UPDATE_Viewer_with_anID_DTO getmyViewerDTO)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        //check if auth 0 string is valid
        //        if (getmyViewerDTO?.MSToken?.GetType() != typeof(string)){return Conflict($"\n\n\t The id '{getmyViewerDTO?.MSToken}' is not valid \n");}
        //        CHECK_AccessLayer.CHECKSTATUS check = await this._check_Repo.CHECK_Viewer_by_MSToken(getmyViewerDTO?.MSToken);

        //        //check if user exists
        //        if(check.ToString() != "TRUE"){return NotFound($"\n\n\t The user with id '{getmyViewerDTO?.MSToken}' could not be found \n");}

        //        //update user
        //        bool check_If_Updated = await this._update_Repo.UPDATE_Viewer_by_MSToken(getmyViewerDTO?.MSToken, getmyViewerDTO?.Fn, getmyViewerDTO?.Ln, getmyViewerDTO?.Email, getmyViewerDTO?.Image, getmyViewerDTO?.Username, getmyViewerDTO?.AboutMe, getmyViewerDTO?.StreetAddy, getmyViewerDTO?.City, getmyViewerDTO?.State, getmyViewerDTO?.Country, getmyViewerDTO?.AreaCode, getmyViewerDTO?.Role, getmyViewerDTO?.MembershipStatus, getmyViewerDTO?.LastSignedIn);
        //        if(check_If_Updated != true)
        //        {
        //            return Conflict($"Your account could not be updated at - {DateTime.Now}");
        //        }
        //        var viewer = await this._get_Repo.GET_myViewer_by_MSToken(getmyViewerDTO?.MSToken);
        //        return Ok(viewer);
        //    }
        //    else
        //    {
        //        return BadRequest("That was a bad request");
        //    }
        //}//END of UPDATE_myViewer_by_MSToken
        
    }
}