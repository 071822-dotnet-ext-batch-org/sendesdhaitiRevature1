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

namespace MS_API.Controllers
{
    [ApiController]
    [Route("mint-soup")]
    [Authorize]
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
    //Viewer is auto-generated when user signs up from the token api
        
        



    }
}