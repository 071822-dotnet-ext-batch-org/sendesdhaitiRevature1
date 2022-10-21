using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// This meodel is a user's viewer wallet - it needs (Guid? id, Guid? id_Of_walletOwner, decimal? balance, DateTime? dateCreated, DateTime? dateUpdated)
    /// </summary>
    public class Wallet
    {
        public Guid? ID {get;set;}
        public Guid? FK_ViewerID_WalletOwner {get;set;}
        public decimal? Balance {get;set;}
        public DateTime? DateCreated {get;set;}
        public DateTime? DateUpdated {get;set;}

        /// <summary>
        /// This meodel is a user's viewer wallet - it needs (Guid? id, Guid? id_Of_walletOwner, decimal? balance, DateTime? dateCreated, DateTime? dateUpdated)
        /// </summary>
        public Wallet(){}
        /// <summary>
        /// This meodel is a user's viewer wallet - it needs (Guid? id, Guid? id_Of_walletOwner, decimal? balance, DateTime? dateCreated, DateTime? dateUpdated)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="id_Of_walletOwner"></param>
        /// <param name="balance"></param>
        /// <param name="dateCreated"></param>
        /// <param name="dateUpdated"></param>
        public Wallet(Guid? id, Guid? id_Of_walletOwner, decimal? balance, DateTime? dateCreated, DateTime? dateUpdated)
        {
            this.ID = id;
            this.FK_ViewerID_WalletOwner = id_Of_walletOwner;
            this.Balance = balance;
            this.DateCreated = dateCreated;
            this.DateUpdated = dateUpdated;
        }
    }

    /// <summary>
    /// This model is a user's show wallet - it needs (Guid? id, Guid? id_Of_walletOwner, Guid? fk_ShowID_WalletShow, decimal? balance, DateTime? dateCreated, DateTime? dateUpdated)
    /// </summary>
    public class ShowWallet
    {
        public Guid? ID {get;set;}
        public Guid? FK_ViewerID_WalletOwner {get;set;}
        public Guid? FK_ShowID_WalletShow {get;set;}
        public decimal? Balance {get;set;}
        public DateTime? DateCreated {get;set;}
        public DateTime? DateUpdated {get;set;}

        /// <summary>
        /// This model is a user's show wallet - it needs (Guid? id, Guid? id_Of_walletOwner, Guid? fk_ShowID_WalletShow, decimal? balance, DateTime? dateCreated, DateTime? dateUpdated)
        /// </summary>
        public ShowWallet(){}
        /// <summary>
        /// This model is a user's show wallet - it needs (Guid? id, Guid? id_Of_walletOwner, Guid? fk_ShowID_WalletShow, decimal? balance, DateTime? dateCreated, DateTime? dateUpdated)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="id_Of_walletOwner"></param>
        /// <param name="fk_ShowID_WalletShow"></param>
        /// <param name="balance"></param>
        /// <param name="dateCreated"></param>
        /// <param name="dateUpdated"></param>
        public ShowWallet(Guid? id, Guid? id_Of_walletOwner, Guid? fk_ShowID_WalletShow, decimal? balance, DateTime? dateCreated, DateTime? dateUpdated)
        {
            this.ID = id;
            this.FK_ViewerID_WalletOwner = id_Of_walletOwner;
            this.FK_ShowID_WalletShow = fk_ShowID_WalletShow;
            this.Balance = balance;
            this.DateCreated = dateCreated;
            this.DateUpdated = dateUpdated;
        }
    }

    /// <summary>
    /// This dto gets a user's viewer wallet - it needs (string? auth0ID, Guid? id_Of_walletOwner)
    /// </summary>
    public class GET_personalWalletDTO
    {
        public string? Auth0ID {get;set;}
        public Guid? FK_ViewerID_WalletOwner {get;set;}
        /// <summary>
        /// This dto gets a user's viewer wallet - it needs (string? auth0ID, Guid? id_Of_walletOwner)
        /// </summary>
        public GET_personalWalletDTO(){}
        /// <summary>
        /// This dto gets a user's viewer wallet - it needs (string? auth0ID, Guid? id_Of_walletOwner)
        /// </summary>
        /// <param name="auth0ID"></param>
        /// <param name="id_Of_walletOwner"></param>
        public GET_personalWalletDTO(string? auth0ID, Guid? id_Of_walletOwner)
        {
            this.Auth0ID = auth0ID;
            this.FK_ViewerID_WalletOwner = id_Of_walletOwner;
        }

    }

    /// <summary>
    /// This dto gets a user's show wallet - it needs (string? auth0ID, Guid? id_Of_walletOwner, Guid? fk_ShowID_WalletShow)
    /// </summary>
    public class GET_showWalletDTO
    {
        public string? Auth0ID {get;set;}
        public Guid? FK_ViewerID_WalletOwner {get;set;}
        public Guid? FK_ShowID_WalletShow {get;set;}
        /// <summary>
        /// This dto gets a user's show wallet - it needs (string? auth0ID, Guid? id_Of_walletOwner, Guid? fk_ShowID_WalletShow)
        /// </summary>
        public GET_showWalletDTO(){}
        /// <summary>
        /// This dto gets a user's show wallet - it needs (string? auth0ID, Guid? id_Of_walletOwner, Guid? fk_ShowID_WalletShow)
        /// </summary>
        /// <param name="auth0ID"></param>
        /// <param name="id_Of_walletOwner"></param>
        /// <param name="fk_ShowID_WalletShow"></param>
        public GET_showWalletDTO(string? auth0ID, Guid? id_Of_walletOwner, Guid? fk_ShowID_WalletShow)
        {
            this.Auth0ID = auth0ID;
            this.FK_ViewerID_WalletOwner = id_Of_walletOwner;
            this.FK_ShowID_WalletShow = fk_ShowID_WalletShow;
        }

    }
}