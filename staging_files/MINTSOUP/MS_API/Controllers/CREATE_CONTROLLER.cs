using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


using MS_API1_Users_LogicLayer;
using MS_API1_Users_Repo;
using MS_API1_Users_Model;
using Models;
using actions;
using DTOs;

namespace MS_API.Controllers
{
    [ApiController]
    [Route("mint-soup")]
    [Authorize]
    public class CREATE_CONTROLLER : ControllerBase
    {
        private readonly ICREATE_AccessLayer _create_repo;
        private readonly ICHECK_AccessLayer _check_Repo;
        public CREATE_CONTROLLER( ICREATE_AccessLayer _create,ICHECK_AccessLayer _check)
        {
            this._create_repo = _create;
            this._check_Repo = _check;
        }
        public enum _CONTROLLER_RESPONSEmsg{
            No_OBJ_due_to_null,
            Full_OBJ
        }


        //[HttpPost("create-show")]
        //public async Task<ActionResult<Show?>> CREATE_SHOW(Create_ShowDTO dto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        CHECK_AccessLayer.CHECKSTATUS check = await this._check_Repo.CHECK_Viewer_by_MSToken(dto.MSToken);
        //        if(actions.REPO_ACTIONS.CHECK_ifStatus_To_CHEKCSTATUS(check, "TRUE") == true)
        //        {
        //            bool saved = await this._create_repo.CREATE_myShow_by_MSToken(dto.MSToken, dto.showName, dto.showImage, dto.privacyLevel);
        //            Console.WriteLine($"Your show was created at {DateTime.UtcNow.ToString().ToUpper()} as -- {saved.ToString().ToUpper()} ");
        //            return Created("create-show", $"Your show was created at {DateTime.UtcNow.ToString().ToUpper()} as -- {saved.ToString().ToUpper()} ");
        //        }
        //        else
        //        {
        //            Console.WriteLine($" {check.ToString().ToUpper()} -- The Viewer could not be found at {DateTime.UtcNow} for {dto.MSToken} to create a show");
        //            return NotFound($" {check.ToString().ToUpper()} -- The Viewer could not be found at {DateTime.UtcNow} for {dto.MSToken} to create a show");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("This was a bad request");
        //    }
        //}//END of CREATE SHOW

        //[HttpPost("start-show-session")]
        //public async Task<ActionResult<Show?>> CREATE_SHOW_SESSION(Create_Show_SessionDTO dto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        CHECK_AccessLayer.CHECKSTATUS check = await this._check_Repo.CHECK_Viewer_by_MSToken(dto.MSToken);
        //        if (actions.REPO_ACTIONS.CHECK_ifStatus_To_CHEKCSTATUS(check, "TRUE") == true)
        //        {
        //            bool saved = await this._create_repo.CREATE_myShowSession_by_ShowID(dto.MSToken, dto.showID);
        //            Console.WriteLine($"Your show session was started at {DateTime.UtcNow.ToString().ToUpper()} as -- {saved.ToString().ToUpper()} ");
        //            return Created("start-show-session", $"Your show session was started at {DateTime.UtcNow.ToString().ToUpper()} as -- {saved.ToString().ToUpper()} ");
        //        }
        //        else
        //        {
        //            Console.WriteLine($" {check.ToString().ToUpper()} -- The Viewer could not be found at {DateTime.UtcNow} for {dto.MSToken} to start a session for {dto.showID}");
        //            return NotFound($" {check.ToString().ToUpper()} -- The Viewer could not be found at {DateTime.UtcNow} for {dto.MSToken} to start a session for {dto.showID}");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("This was a bad request");
        //    }
        //}//END of START/CREATE SHOW SESSION

        //[HttpPost("join-show-session")]
        //public async Task<ActionResult<Show?>> CREATE_SHOW_SESSION_JOIN(Create_Show_Session_JoinDTO dto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        CHECK_AccessLayer.CHECKSTATUS check = await this._check_Repo.CHECK_Viewer_by_MSToken(dto.MSToken);
        //        if (actions.REPO_ACTIONS.CHECK_ifStatus_To_CHEKCSTATUS(check, "TRUE") == true)
        //        {
        //            bool saved = await this._create_repo.CREATE_myJoin_to_ShowSession_by_ShowSessionID(dto.MSToken, dto.showsessionid);
        //            Console.WriteLine($"You joined the session {dto.showsessionid} at {DateTime.UtcNow.ToString().ToUpper()} as -- {saved.ToString().ToUpper()} ");
        //            return Created("join-show-session", $"You joined the session {dto.showsessionid} at {DateTime.UtcNow.ToString().ToUpper()} as -- {saved.ToString().ToUpper()} ");
        //        }
        //        else
        //        {
        //            Console.WriteLine($" {check.ToString().ToUpper()} -- The Viewer could not be found at {DateTime.UtcNow} for {dto.MSToken} to join {dto.showsessionid}");
        //            return NotFound($" {check.ToString().ToUpper()} -- The Viewer could not be found at {DateTime.UtcNow} for {dto.MSToken} to join {dto.showsessionid}");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("This was a bad request");
        //    }
        //}//END of START/CREATE SHOW SESSION





    }
}