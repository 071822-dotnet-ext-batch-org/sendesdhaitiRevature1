using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MS_API1_Users_Repo;
using MS_API1_Users_Model;
using Models;

namespace MS_API1_Users_LogicLayer
{
    public interface ICREATE_LogicLayer
    {
        Task<(Viewer?, CHECK_AccessLayer.CHECKSTATUS)> CREATE_myViewer_by_auth0ID(CREATE_Viewer_on_signUP_with_auth0ID_DTO? createViewerDTO);
    }

    public class CREATE_LogicLayer : ICREATE_LogicLayer
    {
        private readonly IGET_AccessLayer _get_Repo;
        private readonly ICREATE_AccessLayer _create_Repo;
        private readonly ICHECK_AccessLayer _check_Repo;
        public CREATE_LogicLayer(IGET_AccessLayer _get, ICREATE_AccessLayer _create, ICHECK_AccessLayer _check)
        {
            this._get_Repo = _get;
            this._create_Repo = _create;
            this._check_Repo = _check;
        }



        //--------------------------------------CREATE VIEWER SECTION------------------------------------------------------------------------------
        /// <summary>
        /// This method lets a user create a Viewer account, If something went wrong, a message will come with the response - it needs (createViewerDTO)
        /// </summary>
        /// <param name="createViewerDTO"></param>
        /// <returns>an async Task<(Models.Viewer?, string)</returns>
        public async Task<(Models.Viewer?, CHECK_AccessLayer.CHECKSTATUS)> CREATE_myViewer_by_auth0ID(Models.CREATE_Viewer_on_signUP_with_auth0ID_DTO? createViewerDTO)
        {
            //the email does not belong to a viewer
            CHECK_AccessLayer.CHECKSTATUS checkIfCreated = await this._create_Repo.CREATE_myViewer_by_auth0ID(createViewerDTO?.Auth0ID, createViewerDTO?.Email);
            
            if (checkIfCreated.ToString() == "SAVED")
            {
                Viewer? viewer = await this._get_Repo.GET_myViewer_by_auth0ID(createViewerDTO?.Auth0ID);
                return (viewer, CHECK_AccessLayer.CHECKSTATUS.SAVED);
            }

            else if(checkIfCreated.ToString() == "NOT_SAVED"){ return (null, CHECK_AccessLayer.CHECKSTATUS.NOT_SAVED); }

            else { return (null, CHECK_AccessLayer.CHECKSTATUS.NO_AUTH0); }
        }//END OF CREATE_myViewer_by_auth0ID


    }
}