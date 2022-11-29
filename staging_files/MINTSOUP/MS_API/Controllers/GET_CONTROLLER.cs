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
using Microsoft.AspNetCore.Cors;

namespace MS_API.Controllers
{
    [EnableCors("MyAllowAllOrigins")]
    [Route("mint-soup/")]
    [Authorize]
    public class GET_CONTROLLER : ControllerBase
    {
        private readonly IGET_LogicLayer _LogicLayer;
        private readonly ICHECK_AccessLayer _CheckRepo;
        private readonly IGET_AccessLayer _GET;
        private CHECK_AccessLayer.CHECKSTATUS checkSTATUS;

        private CHECK_AccessLayer.CHECKSTATUS CheckSTATUS { get => checkSTATUS; set => checkSTATUS = value; }

        [NonAction]
        public bool CompareCheckStatus(CHECK_AccessLayer.CHECKSTATUS check, string expected)
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
        public async Task<ActionResult<List<Viewer?>>> GET_ALL_VIEWERS()
        {
            if (ModelState.IsValid)
            {
                DTOs.MSTokenACTIONDTO dto = new DTOs.MSTokenACTIONDTO(new Guid(Request.Headers["mstoken"]));
                Console.WriteLine($"At {DateTime.Now} The header was converted to dto as {dto.GetMSToken()}");
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
        [HttpGet("my-viewer")]
        //[AllowAnonymous]
        public async Task<ActionResult<Models.Viewer?>> GET_myViewer_by_MSToken()
        {
            if(ModelState.IsValid)
            {
                DTOs.MSTokenACTIONDTO dto = new DTOs.MSTokenACTIONDTO(new Guid(Request.Headers["mstoken"]));
                Console.WriteLine($"At {DateTime.Now} The header was converted to dto as {dto.GetMSToken()}");
                Models.Viewer? viewer = await this._GET.GET_myViewer_by_MSToken(dto.GetMSToken());
                if(viewer?.MSToken != null)
                {
                    return Ok(viewer);
                }
                else
                {
                    return NotFound($"You could not get your viewer at - {DateTime.UtcNow.ToString().ToUpper()}");
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
                //string? s = dto.GetMSToken();
                Guid? myToken = dto.GetMSToken();
                if(myToken != null)
                {
                    CHECK_AccessLayer.CHECKSTATUS check = await this._CheckRepo.CHECK_Viewer_by_MSToken((Guid)myToken);
                    if(this.CompareCheckStatus(check, "TRUE"))
                    {
                        Models.Admin? admin = await this._GET.GET_myAdmin_by_MSToken(myToken);
                        if(admin?.MSToken == dto.GetMSToken())
                        {
                            return Ok(admin);
                        }
                        else
                        {
                            return NotFound($"You could not get your admin at - {DateTime.UtcNow.ToString().ToUpper()}");
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
        public async Task<ActionResult<List<Models.Show?>>> GET_allShows()
        {
            if (ModelState.IsValid)
            {
                DTOs.MSTokenACTIONDTO dto = new DTOs.MSTokenACTIONDTO(new Guid(Request.Headers["mstoken"]));
                Console.WriteLine($"At {DateTime.Now} The header was converted to dto as {dto.GetMSToken()}");
                List<Models.Show?> show = await this._GET.GET_allShows(dto.GetMSToken());
                return Ok(show);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End

        [HttpGet("show")]
        public async Task<ActionResult<Models.Show?>> GET_aShow()
        {
            if (ModelState.IsValid)
            {
                DTOs.MSTokenACTIONDTO.ShowDTO dto = new DTOs.MSTokenACTIONDTO.ShowDTO(new Guid(Request.Headers["mstoken"]), new Guid(Request.Headers["showid"]));
                Console.WriteLine($"At {DateTime.Now} The header was converted to dto as {dto.GetMSToken()}");
                Models.Show? show = await this._GET.GET_aShow_by_ShowID_with_MSToken(dto.GetMSToken(), dto.GetShowID());
                if (show == null)
                {
                    return NotFound($"You could not get the show at - {DateTime.UtcNow.ToString().ToUpper()}");
                }
                return Ok(show);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End

        [HttpGet("all-show-sessions")]
        public async Task<ActionResult<List<Models.ShowSession?>>> GET_allShowSessions()
        {
            if (ModelState.IsValid)
            {
                DTOs.MSTokenACTIONDTO dto = new DTOs.MSTokenACTIONDTO(new Guid(Request.Headers["mstoken"]));
                Console.WriteLine($"At {DateTime.Now} The header was converted to dto as {dto.GetMSToken()}");
                List<Models.ShowSession?> ret = await this._GET.GET_allShowSessions(dto.GetMSToken());
                return Ok(ret);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End

        [HttpGet("session")]
        public async Task<ActionResult<List<Models.ShowSession?>>> GET_aShowSessions()
        {
            if (ModelState.IsValid)
            {
                DTOs.MSTokenACTIONDTO.ShowDTO.ShowSessionDTO dto = new DTOs.MSTokenACTIONDTO.ShowDTO.ShowSessionDTO(new Guid(Request.Headers["mstoken"]), new Guid(Request.Headers["showid"]), new Guid(Request.Headers["sessionid"]));
                Console.WriteLine($"At {DateTime.Now} The header was converted to dto as {dto.GetMSToken()}");
                Models.ShowSession? ret = await this._GET.GET_aShowSession_by_ShowSessionID_with_MSToken(dto.GetMSToken(), dto.GetSessionID());
                if (ret == null)
                {
                    return NotFound($"You could not get the session at - {DateTime.UtcNow.ToString().ToUpper()}");
                }
                return Ok(ret);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End


        [HttpGet("all-show-sessions-joins")]
        public async Task<ActionResult<List<Models.ShowSessionJoins?>>> GET_allShowSessionJoins()
        {
            if (ModelState.IsValid)
            {
                DTOs.MSTokenACTIONDTO dto = new DTOs.MSTokenACTIONDTO(new Guid(Request.Headers["mstoken"]));
                Console.WriteLine($"At {DateTime.Now} The header was converted to dto as {dto.GetMSToken()}");
                List<Models.ShowSessionJoins?> ret = await this._GET.GET_allShowSessionJoins(dto.GetMSToken());
                return Ok(ret);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End

        [HttpGet("sessions-joins")]
        public async Task<ActionResult<Models.ShowSessionJoins?>> GET_aSessionJoin()
        {
            if (ModelState.IsValid)
            {
                DTOs.MSTokenACTIONDTO.ShowDTO.ShowSessionDTO.SessionJoinDTO dto = new DTOs.MSTokenACTIONDTO.ShowDTO.ShowSessionDTO.SessionJoinDTO(new Guid(Request.Headers["mstoken"]), new Guid(Request.Headers["sessionjoinid"]));
                Console.WriteLine($"At {DateTime.Now} The header was converted to dto as {dto.GetMSToken()}");
                Models.ShowSessionJoins? ret = await this._GET.GET_aShowSessionJoin_by_ShowSessionJoinID_with_MSToken(dto.GetMSToken(), dto.GetsessionJoinID());
                if (ret == null)
                {
                    return NotFound($"You could not get the session join at - {DateTime.UtcNow.ToString().ToUpper()}");
                }
                return Ok(ret);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End

        [HttpGet("all-show-donations")]
        public async Task<ActionResult<List<Models.ShowDonation?>>> GET_allShowDonations()
        {
            if (ModelState.IsValid)
            {
                DTOs.MSTokenACTIONDTO dto = new DTOs.MSTokenACTIONDTO(new Guid(Request.Headers["mstoken"]));
                Console.WriteLine($"At {DateTime.Now} The header was converted to dto as {dto.GetMSToken()}");
                List<Models.ShowDonation?> ret = await this._GET.GET_allShowDonations(dto.GetMSToken());
                return Ok(ret);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End

        [HttpGet("donation")]
        public async Task<ActionResult<Models.ShowDonation?>> GET_aDonation()
        {
            if (ModelState.IsValid)
            {
                DTOs.DonationDTO dto = new DTOs.DonationDTO(new Guid(Request.Headers["mstoken"]), new Guid(Request.Headers["donationid"]));
                Console.WriteLine($"At {DateTime.Now} The header was converted to dto as {dto.GetMSToken()}");
                Models.ShowDonation? ret = await this._GET.GET_aShowDonation_by_ShowDonationID_with_MSToken(dto.GetMSToken(), dto.GetDonationID());
                if(ret == null)
                {
                    return NotFound($"You could not get the donation at - {DateTime.UtcNow.ToString().ToUpper()}");
                }
                return Ok(ret);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End

        [HttpGet("my-viewer-wallet/")]
        public async Task<ActionResult<Models.Wallet?>> GET_myViewerWallet()
        {
            if (ModelState.IsValid)
            {
                DTOs.MSTokenACTIONDTO dto = new DTOs.MSTokenACTIONDTO(new Guid(Request.Headers["mstoken"]));
                Console.WriteLine($"At {DateTime.Now} The header was converted to dto as {dto.GetMSToken()}");
                Guid? myToken = dto.GetMSToken();
                if(myToken != null)
                {
                    CHECK_AccessLayer.CHECKSTATUS check = await this._CheckRepo.CHECK_Viewer_by_MSToken((Guid)myToken);
                    if(this.CompareCheckStatus(check, "TRUE"))
                    {
                        Models.Wallet? ret = await this._GET.GET_myPersonalWallet_by_viewerID(dto.GetMSToken());
                        return Ok(ret);
                    }
                    return NoContent();
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
                if (myToken != null && ShowId != null)
                {
                    CHECK_AccessLayer.CHECKSTATUS check = await this._CheckRepo.CHECK_Viewer_by_MSToken((Guid)myToken);
                    CHECK_AccessLayer.CHECKSTATUS check2 = await this._CheckRepo.CHECK_Viewer_by_MSToken((Guid)ShowId);
                    if (this.CompareCheckStatus(check, "TRUE") && this.CompareCheckStatus(check2, "TRUE"))
                    {
                        Models.ShowWallet? ret = await this._GET.GET_myShowWallet_by_viewer_AND_showID(myToken, ShowId );
                        return Ok(ret);
                    }
                    return NoContent();
                }
                else { return NotFound($"At {DateTime.Now} - Your show's wallet could not be retrieved! - Give us a second..."); }
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

        [HttpGet("friend")]
        public async Task<ActionResult<Models.Friend?>> GET_aFriend()
        {
            if (ModelState.IsValid)
            {
                DTOs.GETDTO dto = new DTOs.GETDTO(new Guid(Request.Headers["mstoken"]), new Guid(Request.Headers["friendid"]));
                Console.WriteLine($"At {DateTime.Now} The header was converted to dto as {dto.GetMSToken()}");
                Models.Friend? ret = await this._GET.GET_aFriend_by_ViewerID_Freinder(dto.GetMSToken(), dto.GetOBJID());
                if (ret == null)
                {
                    return NotFound($"You could not get the friend '{dto.GetOBJID()}' at - {DateTime.UtcNow.ToString().ToUpper()}");
                }
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

        [HttpGet("follower")]
        public async Task<ActionResult<Models.Follower?>> GET_aFollower()
        {
            if (ModelState.IsValid)
            {
                DTOs.GETDTO dto = new DTOs.GETDTO(new Guid(Request.Headers["mstoken"]), new Guid(Request.Headers["followieid"]));
                Console.WriteLine($"At {DateTime.Now} The header was converted to dto as {dto.GetMSToken()}");
                Models.Follower? ret = await this._GET.GET_aFollower_by_ViewerID_Followie(dto.GetMSToken(), dto.GetOBJID());
                if (ret == null)
                {
                    return NotFound($"You could not get the follow '{dto.GetOBJID()}' at - {DateTime.UtcNow.ToString().ToUpper()}");
                }
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

        [HttpGet("like")]
        public async Task<ActionResult<Models.ShowLikes?>> GET_aLike()
        {
            if (ModelState.IsValid)
            {
                DTOs.GETDTO dto = new DTOs.GETDTO(new Guid(Request.Headers["mstoken"]), new Guid(Request.Headers["sessionid"]));
                Console.WriteLine($"At {DateTime.Now} The header was converted to dto as {dto.GetMSToken()}");
                Models.ShowLikes? ret = await this._GET.GET_aShowLike_by_ShowSessionID_with_MSToken(dto.GetMSToken(), dto.GetOBJID());
                if (ret == null)
                {
                    return NotFound($"You could not get the sessions like for '{dto.GetOBJID()}' at - {DateTime.UtcNow.ToString().ToUpper()}");
                }
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

        [HttpGet("comment")]
        public async Task<ActionResult<Models.ShowComment?>> GET_aComment()
        {
            if (ModelState.IsValid)
            {
                DTOs.GETDTO dto = new DTOs.GETDTO(new Guid(Request.Headers["mstoken"]), new Guid(Request.Headers["commentid"]));
                Console.WriteLine($"At {DateTime.Now} The header was converted to dto as {dto.GetMSToken()}");
                Models.ShowComment? ret = await this._GET.GET_aShowComment_by_ShowCommentID_with_MSToken(dto.GetMSToken(), dto.GetOBJID());
                if (ret == null)
                {
                    return NotFound($"You could not get the comment for '{dto.GetOBJID()}' at - {DateTime.UtcNow.ToString().ToUpper()}");
                }
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

        [HttpGet("comment-like")]
        public async Task<ActionResult<Models.ShowCommentLike?>> GET_aCommentLike()
        {
            if (ModelState.IsValid)
            {
                DTOs.GETDTO dto = new DTOs.GETDTO(new Guid(Request.Headers["mstoken"]), new Guid(Request.Headers["commentid"]));
                Console.WriteLine($"At {DateTime.Now} The header was converted to dto as {dto.GetMSToken()}");
                Models.ShowCommentLike? ret = await this._GET.GET_aShowCommentLike_by_ShowCommentID_with_MSToken(dto.GetMSToken(), dto.GetOBJID());
                if (ret == null)
                {
                    return NotFound($"You could not get the comment like for '{dto.GetOBJID()}' at - {DateTime.UtcNow.ToString().ToUpper()}");
                }
                return Ok(ret);
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }//End










    }
}