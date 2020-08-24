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

        #region Payment_getwallet
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("getwallet")]
        public IActionResult GetWallet(GeneralModel generalModel)
        {
            List<GetWalletModel> getWalletModel = new List<GetWalletModel>();
            getWalletModel[0].Amount_Added = 500;
            getWalletModel[0].Amount_Balance = 100;
            getWalletModel[0].Amount_Spent = 400;
            getWalletModel[0].Currency = "&";
            return this.OK<List<GetWalletModel>>(getWalletModel, getWalletModel == null ? "wallet_not_found" : "wallet_found", getWalletModel == null ? 0 : 1);
        }
        #endregion

        #region Payment_cardlist
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("cardlist")]
        public IActionResult CardList(GeneralModel generalModel)
        {
            List<CardListModel> cardListModel = new List<CardListModel>();
            cardListModel[0].Payment = new Payment();
            cardListModel[0].Payment.Card_Id = 1;
            cardListModel[0].Payment.Last_Number = "555";
            cardListModel[0].Payment.Card_Type = "VISA";
            cardListModel[0].Payment.Is_Default = true;
            return this.OK<List<CardListModel>>(cardListModel, cardListModel == null ? "CardList_Not_Found" : "CardList_Found", cardListModel == null ? 0 : 1);
        }
        #endregion

        #region Payment_addwallet
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("addwallet")]
        public IActionResult AddWallet(GeneralModel generalModel)
        {
            List<AddWalletModel> addWalletModel = new List<AddWalletModel>();
            addWalletModel[0].Amount_Added = 500;
            addWalletModel[0].Amount_Balance = 100;
            addWalletModel[0].Amount_Spent = 400;
            addWalletModel[0].Currency = "&";
            return this.OK<List<AddWalletModel>>(addWalletModel, addWalletModel == null ? "AddWallet_not_found" : "AddWallet_found", addWalletModel == null ? 0 : 1);
        }
        #endregion

        #region Payment_addcard
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("addcard")]
        public IActionResult AddCard(GeneralModel generalModel)
        {
            List<AddCardModel> addCardModel = new List<AddCardModel>();
            addCardModel[0].Payment = new Payment();
            addCardModel[0].Payment.Card_Id = 1;
            addCardModel[0].Payment.Last_Number = "555";
            addCardModel[0].Payment.Card_Type = "VISA";
            addCardModel[0].Payment.Is_Default = true;
            return this.OK<List<AddCardModel>>(addCardModel, addCardModel == null ? "AddWallet_not_found" : "AddWallet_found", addCardModel == null ? 0 : 1);
        }
        #endregion
    }
}
