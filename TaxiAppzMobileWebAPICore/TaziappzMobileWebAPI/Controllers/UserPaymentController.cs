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
    public class UserPaymentController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        private IValidate validate;
        public UserPaymentController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("historySingle")]
        public IActionResult HistorySingle(GeneralModel generalModel)
        {
            UserPaymentModel userPaymentModel = new UserPaymentModel();
            userPaymentModel.Preferred_Payment_Type = 1;
            return this.OKRESPONSE<UserPaymentModel>(userPaymentModel, userPaymentModel == null ? "Preferred_Payment_Not_Found" : "Preferred_Payment_found");
        }

        [HttpPost]
        [Route("addwallet")]
        public IActionResult AddWallet(GeneralModel generalModel)
        {
            UserAddWalletModel userAddWalletModel = new UserAddWalletModel();
            userAddWalletModel.Amount_Added = 20;
            userAddWalletModel.Amount_Balance = 15;
            userAddWalletModel.Amount_Spent = 5;
            userAddWalletModel.Currency = "$";
            return this.OKRESPONSE<UserAddWalletModel>(userAddWalletModel, userAddWalletModel == null ? "Add_Wallet_Not_Found" : "Add_Wallet_found");
        }

        [HttpPost]
        [Route("addCard")]
        public IActionResult AddCard(GeneralModel generalModel)
        {
            UserAddCardModel userAddCardModel = new UserAddCardModel();
            userAddCardModel.Card_Id = 20;
            userAddCardModel.Last_Number = "42";
            userAddCardModel.Card_Type = "VISA";
            userAddCardModel.Is_Default = true;
            return this.OKRESPONSE<UserAddCardModel>(userAddCardModel, userAddCardModel == null ? "Add_Card_Not_Found" : "Add_Card_found");
        }

        [HttpPost]
        [Route("deleteCard")]
        public IActionResult DeleteCard(GeneralModel generalModel)
        {
            UserDeleteCardModel userDeleteCardModel = new UserDeleteCardModel();
            userDeleteCardModel.Payment = new UserPayment();
            return this.OKRESPONSE<UserDeleteCardModel>(userDeleteCardModel, userDeleteCardModel == null ? "Delete_Card_Not_Found" : "Delete_Card_found");
        }
    }
}
