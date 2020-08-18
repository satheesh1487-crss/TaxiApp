using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaziappzMobileWebAPI.Interface;
using TaziappzMobileWebAPI.Models;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverPaymentController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        private IValidate validate;
        public DriverPaymentController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        #region Payment_Apis
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("getwallet")]
        public IActionResult GetWallet(GeneralModel generalModel)
        {
            GetWalletModel getWalletModel = new GetWalletModel();
            getWalletModel.Amount_Added = 500;
            getWalletModel.Amount_Balance = 100;
            getWalletModel.Amount_Spent = 400;
            getWalletModel.Currency = "&";
            return this.OKRESPONSE<GetWalletModel>(getWalletModel, getWalletModel == null ? "wallet_not_found" : "wallet_found");
        }

        [HttpPost]
        [Route("cardlist")]
        public IActionResult CardList(GeneralModel generalModel)
        {
            CardListModel cardListModel = new CardListModel();
            cardListModel.Payment = new Payment();
            cardListModel.Payment.Card_Id = 1;
            cardListModel.Payment.Last_Number = "555";
            cardListModel.Payment.Card_Type = "VISA";
            cardListModel.Payment.Is_Default = true;
            return this.OKRESPONSE<CardListModel>(cardListModel, cardListModel == null ? "CardList_Not_Found" : "CardList_Found");
        }

        [HttpPost]
        [Route("addwallet")]
        public IActionResult AddWallet(GeneralModel generalModel)
        {
            AddWalletModel addWalletModel = new AddWalletModel();
            addWalletModel.Amount_Added = 500;
            addWalletModel.Amount_Balance = 100;
            addWalletModel.Amount_Spent = 400;
            addWalletModel.Currency = "&";
            return this.OKRESPONSE<AddWalletModel>(addWalletModel, addWalletModel == null ? "AddWallet_not_found" : "AddWallet_found");
        }

        [HttpPost]
        [Route("addcard")]
        public IActionResult AddCard(GeneralModel generalModel)
        {
            AddCardModel addCardModel = new AddCardModel();
            addCardModel.Payment = new Payment();
            addCardModel.Payment.Card_Id = 1;
            addCardModel.Payment.Last_Number = "555";
            addCardModel.Payment.Card_Type = "VISA";
            addCardModel.Payment.Is_Default = true;
            return this.OKRESPONSE<AddCardModel>(addCardModel, addCardModel == null ? "AddWallet_not_found" : "AddWallet_found");
        }

        #endregion
    }
}
