using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Wallet
    {
        public Guid? ID {get;set;}
        public Guid? FK_ViewerID_WalletOwner {get;set;}
        public decimal? Balance {get;set;}
        public DateTime? DateCreated {get;set;}
        public DateTime? DateUpdated {get;set;}

        //Constructor
        public Wallet(){}
        public Wallet(Guid? id, Guid? id_Of_walletOwner, decimal? balance, DateTime? dateCreated, DateTime? dateUpdated)
        {
            this.ID = id;
            this.FK_ViewerID_WalletOwner = id_Of_walletOwner;
            this.Balance = balance;
            this.DateCreated = dateCreated;
            this.DateUpdated = dateUpdated;
        }
    }

    public class ShowWallet
    {
        public Guid? ID {get;set;}
        public Guid? FK_ViewerID_WalletOwner {get;set;}
        public Guid? FK_ShowID_WalletShow {get;set;}
        public decimal? Balance {get;set;}
        public DateTime? DateCreated {get;set;}
        public DateTime? DateUpdated {get;set;}

        //Constructor
        public ShowWallet(){}
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

    public class GET_personalWalletDTO
    {
        public string? Auth0ID {get;set;}
        public Guid? FK_ViewerID_WalletOwner {get;set;}

        public GET_personalWalletDTO(){}
        public GET_personalWalletDTO(string? auth0ID, Guid? id_Of_walletOwner)
        {
            this.Auth0ID = auth0ID;
            this.FK_ViewerID_WalletOwner = id_Of_walletOwner;
        }

    }

    public class GET_showWalletDTO
    {
        public string? Auth0ID {get;set;}
        public Guid? FK_ViewerID_WalletOwner {get;set;}
        public Guid? FK_ShowID_WalletShow {get;set;}

        public GET_showWalletDTO(){}
        public GET_showWalletDTO(string? auth0ID, Guid? id_Of_walletOwner, Guid? fk_ShowID_WalletShow)
        {
            this.Auth0ID = auth0ID;
            this.FK_ViewerID_WalletOwner = id_Of_walletOwner;
            this.FK_ShowID_WalletShow = fk_ShowID_WalletShow;
        }

    }
}