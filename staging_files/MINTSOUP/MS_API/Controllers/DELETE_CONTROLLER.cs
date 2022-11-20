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
    public class DELETE_CONTROLLER : ControllerBase
    {
        private readonly IGET_LogicLayer _LogicLayer;
        private readonly ICHECK_AccessLayer _CheckRepo;
        private readonly IDELETE_AccessLayer _DElREPO;
        private readonly GET_CONTROLLER _get;
        public DELETE_CONTROLLER(IGET_LogicLayer _Logic, ICHECK_AccessLayer _check, IDELETE_AccessLayer _del, GET_CONTROLLER _g)
        {
            this._LogicLayer = _Logic;
            this._CheckRepo = _check;
            this._DElREPO = _del;
            this._get = _g;
        }

//-------------------------------------------------------DEL VIEWER SECTION----------------------------------------------------
        /// <summary>
        /// This is method lets a viewer delete their viewer account with their aith0ID
        /// </summary>
        /// <param name="MSToken"></param>
        /// <returns>returns an async action result as a full Viewer if not deleted and an empty viewer if deleted successfully</returns>
        //[HttpDelete("del-my-viewer")]
        //public async Task<ActionResult<bool>> DELETE_myViewer_by_MSToken(DTOs.MSTokenACTIONDTO delmyViewerDTO)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        Guid? myToken = delmyViewerDTO.GetMSToken();
        //        CHECK_AccessLayer.CHECKSTATUS check = await this._CheckRepo.CHECK_Viewer_by_MSToken(myToken);

        //        if(this._get.CompareCheckStatus(check, "TRUE"))
        //        {
        //            if(check.ToString() == "FALSE") { return NotFound($"The user account with '{myToken}' was not found"); }
        //            else if(check.ToString() == "NO_AUTH0") { return BadRequest($"you did not had an id '{myToken}'"); }
                
        //            Console.WriteLine($"\n\n\t\t An attempt to delete a viewer by  '{myToken}' at {DateTime.Now} was '{check.ToString()}'  \n");
        //            check = await this._DElREPO.DELETE_myViewer_by_MSToken(myToken);
        //            return Ok(check.ToString());
        //        }
        //        else
        //        {
        //            return NotFound(false);
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("That was a bad request");
        //    }
        //}//End GET_myViewer_by_MSToken


//-------------------------------------------------------DEL SHOW'S LIKE SECTION----------------------------------------------------
        ///// <summary>
        ///// This is method lets a viewer delete their viewer account with their aith0ID
        ///// </summary>
        ///// <param name="MSToken"></param>
        ///// <returns>returns an async action result as a full Viewer if not deleted and an empty viewer if deleted successfully</returns>
        //[HttpDelete("del-my-showlike")]
        //public async Task<ActionResult<string>> DELETE_myLike_on_ShowSession_by_MSToken(Models.GET_anOBJ_by_1GUID_with_MSToken delmyLikeDTO)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        CHECK_AccessLayer.CHECKSTATUS check = await this._CheckRepo.CHECK_Viewer_by_MSToken(delmyLikeDTO?.MSToken);
    
        //        if(check.ToString() == "FALSE") { return NotFound($"The user account with '{delmyLikeDTO?.MSToken}' was not found"); }
        //        else if(check.ToString() == "NO_AUTH0") { return BadRequest($"you do not have an id - '{delmyLikeDTO?.MSToken}'"); }

        //        check = await this._CheckRepo.CHECK_if_there_are_ANY_LikesOnShowSession(delmyLikeDTO?.MSToken, delmyLikeDTO?.OBJID);

        //        if(check.ToString() == "FALSE") { return NotFound($"The user's like with '{delmyLikeDTO?.MSToken}' was not found"); }
        //        else if(check.ToString() == "NO_AUTH0") { return BadRequest($"you do not have an id - '{delmyLikeDTO?.MSToken}'"); }


        //        Console.WriteLine($"\n\n\t\t An attempt to delete a viewer's like on the session by  '{delmyLikeDTO?.MSToken}' at {DateTime.Now} was '{check.ToString()}'  \n");
        //        check = await this._DElREPO.DELETE_myLike_on_ShowSession_by_MSToken(delmyLikeDTO?.MSToken, delmyLikeDTO?.OBJID);
        //        Console.WriteLine($"\n\n\t\t The attempt was '{check.ToString()}'  \n");

        //        return Ok(check.ToString());
        //    }
        //    else
        //    {
        //        return BadRequest("That was a bad request");
        //    }
        //}//End DELETE_myLike_on_ShowSession_by_MSToken






    }
}