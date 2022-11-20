using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DTOs;

using MS_API1_Users_LogicLayer;
using MS_API1_Users_Model;
using MS_API1_Users_Repo;
using Models;
using actions;
using static DTOs.MSTokenACTIONDTO;

namespace MS_API.Controllers
{
    [ApiController]
    [Route("mint-soup")]
    [Authorize]
    public class GET_CONTROLLER : ControllerBase
    {
        private readonly IGET_LogicLayer _LogicLayer;
        private readonly ICHECK_AccessLayer _CheckRepo;
        private readonly IGET_AccessLayer _GET;
        private CHECK_AccessLayer.CHECKSTATUS checkSTATUS;

        private CHECK_AccessLayer.CHECKSTATUS CheckSTATUS { get => checkSTATUS; set => checkSTATUS = value; }

        private bool CompareCheckStatus(CHECK_AccessLayer.CHECKSTATUS check, string expected)
        {
            bool res = false;
            string? name = Enum.GetName<CHECK_AccessLayer.CHECKSTATUS>(check);
            if (name == expected)
            {
                return true;
            }
            else return res;
        }
        public GET_CONTROLLER(IGET_LogicLayer _Logic, ICHECK_AccessLayer _check, IGET_AccessLayer _get)
        {
            this._LogicLayer = _Logic;
            this._CheckRepo = _check;
            this._GET = _get;

        }

//-------------------------------------------------------GET VIEWER SECTION----------------------------------------------------
        [HttpGet("all-viewers")]
        //[Authorize(Roles="Admin")]
        public async Task<ActionResult<List<Viewer?>>> GET_ALL_VIEWERS(DTOs.MSTokenACTIONDTO dto)
        {
            if (ModelState.IsValid)
            {
                //(List<Viewer?>, string) allViewers =  await this._LogicLayer.GET_allViewers_by_MSToken();
                List<Viewer?> allViewers = await this._GET.GET_allViewers(dto.GetMSToken());
                //return Ok(allViewers.Item1);
                return Ok(allViewers);
            }
            else
            {
                return NoContent();
            }
        }//End GET ALL Viewers

        /// <summary>
        /// This is the method to test if a viewer successfully gets their account with their aith0ID
        /// </summary>
        /// <param name="MSToken"></param>
        /// <returns>returns an async action result as a Viewer</returns>
        [HttpGet("my-viewer/")]
        //[AllowAnonymous]
        public async Task<ActionResult<Models.Viewer?>> GET_myViewer_by_MSToken()
        {
            if(ModelState.IsValid)
            {
                DTOs.MSTokenACTIONDTO dto = new DTOs.MSTokenACTIONDTO(new Guid());
                if (Request.Headers["headers"].Count() > 0) {
                    Console.WriteLine($"At {DateTime.Now} The header was gotten as {Request.Headers["headers"]}");
                    DTOs.MSTokenACTIONDTO dto2 = new DTOs.MSTokenACTIONDTO(new Guid(Request.Headers["headers"]));
                    dto = dto2;
                }
                Models.Viewer? viewer = await this._GET.GET_myViewer_by_MSToken(dto.GetMSToken());
                if(viewer?.MSToken == dto.GetMSToken())
                {
                    // ActionResult<Viewer?> res1 =  new ActionResult<Viewer?>(viewer.Item1);
                    // OkObjectResult<string> res2 =  new OkObjectResult<string>(viewer.Item2);
                    return Ok(viewer);
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End GET_myViewer_by_MSToken



//-------------------------------------------------------GET ADMIN SECTION----------------------------------------------------
        /// <summary>
        /// This is the method gets your admin account with your aith0ID
        /// </summary>
        /// <param name="MSToken"></param>
        /// <returns>returns an async action result as a admin</returns>
        [HttpGet("my-admin")]
        public async Task<ActionResult<Models.Admin?>> GET_myAdmin_by_MSToken([FromHeader] DTOs.MSTokenACTIONDTO dto)
        {
            if(ModelState.IsValid)
            {

                Guid? myToken = dto.GetMSToken();
                if(myToken != null)
                {
                    CHECK_AccessLayer.CHECKSTATUS check = await this._CheckRepo.CHECK_Viewer_by_MSToken(myToken);
                    if(this.CompareCheckStatus(check, "TRUE"))
                    {
                        Models.Admin? admin = await this._GET.GET_myAdmin_by_MSToken(myToken);
                        if(admin?.MSToken == dto.GetMSToken())
                        {
                            return Ok(admin);
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End 

        [HttpGet("all-shows")]
        public async Task<ActionResult<(Models.Admin?, string)>> GET_allShows([FromHeader] DTOs.MSTokenACTIONDTO dto)
        {
            if (ModelState.IsValid)
            {
                List<Models.Show?> show = await this._GET.GET_allShows(dto.GetMSToken());
                return Ok(show);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End

        [HttpGet("all-show-sessions")]
        public async Task<ActionResult<List<Models.ShowSession?>>> GET_allShowSessions([FromHeader] DTOs.MSTokenACTIONDTO dto)
        {
            if (ModelState.IsValid)
            {
                List<Models.ShowSession?> ret = await this._GET.GET_allShowSessions(dto.GetMSToken());
                return Ok(ret);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End


        [HttpGet("all-show-sessions-joins")]
        public async Task<ActionResult<List<Models.ShowSessionJoins?>>> GET_allShowSessionJoins([FromHeader] DTOs.MSTokenACTIONDTO dto)
        {
            if (ModelState.IsValid)
            {
                List<Models.ShowSessionJoins?> ret = await this._GET.GET_allShowSessionJoins(dto.GetMSToken());
                return Ok(ret);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End

        [HttpGet("all-show-donations")]
        public async Task<ActionResult<List<Models.ShowDonation?>>> GET_allShowDonations([FromHeader] DTOs.MSTokenACTIONDTO dto)
        {
            if (ModelState.IsValid)
            {
                List<Models.ShowDonation?> ret = await this._GET.GET_allShowDonations(dto.GetMSToken());
                return Ok(ret);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End

        [HttpGet("my-viewer-wallet/")]
        public async Task<ActionResult<Models.Wallet?>> GET_myViewerWallet([FromHeader] DTOs.MSTokenACTIONDTO dto)
        {
            if (ModelState.IsValid)
            {
                CHECK_AccessLayer.CHECKSTATUS check = await this._CheckRepo.CHECK_Viewer_by_MSToken(dto.GetMSToken());
                if(this.CompareCheckStatus(check, "TRUE"))
                {
                    Models.Wallet? ret = await this._GET.GET_myPersonalWallet_by_viewerID(dto.GetMSToken());
                    return Ok(ret);
                }
                return NoContent();
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End

        [HttpGet("my-show-wallet/")]
        public async Task<ActionResult<Models.ShowWallet?>> GET_myShowWallet([FromHeader] DTOs.MSTokenACTIONDTO.ShowDTO dto)
        {
            if (ModelState.IsValid)
            {
                Guid? myToken = dto.GetMSToken();
                Guid? ShowId = dto.GetShowID();
                if (myToken == null && ShowId == null) { return NotFound($"At {DateTime.Now} - Your show's wallet could not be retrieved! - Give us a second..."); }
                else
                {
                    CHECK_AccessLayer.CHECKSTATUS check = await this._CheckRepo.CHECK_Viewer_by_MSToken(myToken);
                    CHECK_AccessLayer.CHECKSTATUS check2 = await this._CheckRepo.CHECK_Viewer_by_MSToken(ShowId);
                    if (this.CompareCheckStatus(check, "TRUE") && this.CompareCheckStatus(check2, "TRUE"))
                    {
                        Models.ShowWallet? ret = await this._GET.GET_myShowWallet_by_viewer_AND_showID(myToken, ShowId );
                        return Ok(ret);
                    }
                    return NoContent();
                }
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End

        [HttpGet("all-friends/")]
        public async Task<ActionResult<List<Models.Friend?>>> GET_allFriends([FromHeader] DTOs.MSTokenACTIONDTO dto)
        {
            if (ModelState.IsValid)
            {
                List<Models.Friend?> ret = await this._GET.GET_allFriends(dto.GetMSToken());
                return Ok(ret);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End

        [HttpGet("all-followers/")]
        public async Task<ActionResult<List<Models.Follower?>>> GET_allFollowers([FromHeader] DTOs.MSTokenACTIONDTO dto)
        {
            if (ModelState.IsValid)
            {
                List<Models.Follower?> ret = await this._GET.GET_allFollowers(dto.GetMSToken());
                return Ok(ret);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End

        [HttpGet("all-likes")]
        public async Task<ActionResult<List<Models.ShowLikes?>>> GET_allLikes([FromHeader] DTOs.MSTokenACTIONDTO dto)
        {
            if (ModelState.IsValid)
            {
                List<Models.ShowLikes?> ret = await this._GET.GET_allShowLikes(dto.GetMSToken());
                return Ok(ret);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End

        [HttpGet("all-comments")]
        public async Task<ActionResult<List<Models.ShowComment?>>> GET_allComments([FromHeader] DTOs.MSTokenACTIONDTO dto)
        {
            if (ModelState.IsValid)
            {
                List<Models.ShowComment?> ret = await this._GET.GET_allShowComments(dto.GetMSToken());
                return Ok(ret);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End

        [HttpGet("all-comment-likes")]
        public async Task<ActionResult<List<Models.ShowCommentLike?>>> GET_allCommentLikes([FromHeader] DTOs.MSTokenACTIONDTO dto)
        {
            if (ModelState.IsValid)
            {
                List<Models.ShowCommentLike?> ret = await this._GET.GET_allShowCommentLikes(dto.GetMSToken());
                return Ok(ret);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End


        







    }
}