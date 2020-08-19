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
            List<UserAddCardModel> userAddCardModels = new List<UserAddCardModel>();
            UserAddCardModel userAddCardModel = new UserAddCardModel();           
            userAddCardModel.Payment = new List<UserAddPayment>();
            List<UserAddPayment> addpay = new List<UserAddPayment>();
            userAddCardModel.Payment.Add(new UserAddPayment() { Card_Id = 20, Last_Number = "42", Card_Type = "VISA", Is_Default = true });            
            return this.OKRESPONSE<UserAddCardModel>(userAddCardModel, userAddCardModel == null ? "Add_Card_Not_Found" : "Add_Card_found");
        }

        [HttpPost]
        [Route("deleteCard")]
        public IActionResult DeleteCard(GeneralModel generalModel)
        {
            UserDeleteCardModel userDeleteCardModel = new UserDeleteCardModel();
            userDeleteCardModel.Payment = new List<UserDeletePayment>();
            return this.OKRESPONSE<UserDeleteCardModel>(userDeleteCardModel, userDeleteCardModel == null ? "Delete_Card_Not_Found" : "Delete_Card_found");
        }

        [HttpPost]
        [Route("getwallet")]
        public IActionResult Getwallet(GeneralModel generalModel)
        {
            UserGetWalletModel userGetWalletModel = new UserGetWalletModel();
            userGetWalletModel.Amount_Added = 20;
            userGetWalletModel.Amount_Balance = 15;
            userGetWalletModel.Amount_Spent = 5;
            userGetWalletModel.Currency = "$";
            return this.OKRESPONSE<UserGetWalletModel>(userGetWalletModel, userGetWalletModel == null ? "Get_Wallet_Not_Found" : "Get_Wallet_found");
        }

        [HttpPost]
        [Route("cardlist")]
        public IActionResult Cardlist(GeneralModel generalModel)
        {
            UserCardListModel userCardListModel = new UserCardListModel();
            userCardListModel.Payment = new List<CardListPayment>();
            return this.OKRESPONSE<UserCardListModel>(userCardListModel, userCardListModel == null ? "Card_List_Not_Found" : "Card_List_found");
        }

        [HttpPost]
        [Route("client_token")]
        public IActionResult Client_Token(GeneralModel generalModel)
        {
            UserClientTokenModel userClientTokenModel = new UserClientTokenModel();
            userClientTokenModel.Client_Token = "eyJ2ZXJzaW9uIjoyLCJhdXRob3JpemF0aW9uRmluZ2VycHJpbnQiOiJleUowZVhBaU9pSktWMVFpTENKaGJHY2lPaUpGVXpJMU5pSXNJbXRwWkNJNklqSXdNVGd3TkRJMk1UWXRjMkZ1WkdKdmVDSjkuZXlKbGVIQWlPakUxTlRrNE1EYzRNak1zSW1wMGFTSTZJakk1TXpnNU1XWTRMVEpoWm1VdE5EYzJZaTFpT1ROaUxUUTFaV0ZtTVRGbVpXVmtOQ0lzSW5OMVlpSTZJbkIzWXpKb1pEUTJaemt6Y3pSNmVUSWlMQ0pwYzNNaU9pSkJkWFJvZVNJc0ltMWxjbU5vWVc1MElqcDdJbkIxWW14cFkxOXBaQ0k2SW5CM1l6Sm9aRFEyWnpremN6UjZlVElpTENKMlpYSnBabmxmWTJGeVpGOWllVjlrWldaaGRXeDBJanBtWVd4elpYMHNJbkpwWjJoMGN5STZXeUp0WVc1aFoyVmZkbUYxYkhRaVhTd2liM0IwYVc5dWN5STZlMzE5LjM1SzVwVXI3TDk0UV9PcnFGbTlPYmlJdDhQWjJBU3YzNGM2MXd3OVhFTWlXeXB2SWx6NDF0ZlFCN0NSRGJnXzM4cXdGZlJLUXF3cm5pbVFTQlk3VnlRIiwiY29uZmlnVXJsIjoiaHR0cHM6Ly9hcGkuc2FuZGJveC5icmFpbnRyZWVnYXRld2F5LmNvbTo0NDMvbWVyY2hhbnRzL3B3YzJoZDQ2ZzkzczR6eTIvY2xpZW50X2FwaS92MS9jb25maWd1cmF0aW9uIiwiZ3JhcGhRTCI6eyJ1cmwiOiJodHRwczovL3BheW1lbnRzLnNhbmRib3guYnJhaW50cmVlLWFwaS5jb20vZ3JhcGhxbCIsImRhdGUiOiIyMDE4LTA1LTA4In0sImNoYWxsZW5nZXMiOltdLCJlbnZpcm9ubWVudCI6InNhbmRib3giLCJjbGllbnRBcGlVcmwiOiJodHRwczovL2FwaS5zYW5kYm94LmJyYWludHJlZWdhdGV3YXkuY29tOjQ0My9tZXJjaGFudHMvcHdjMmhkNDZnOTNzNHp5Mi9jbGllbnRfYXBpIiwiYXNzZXRzVXJsIjoiaHR0cHM6Ly9hc3NldHMuYnJhaW50cmVlZ2F0ZXdheS5jb20iLCJhdXRoVXJsIjoiaHR0cHM6Ly9hdXRoLnZlbm1vLnNhbmRib3guYnJhaW50cmVlZ2F0ZXdheS5jb20iLCJhbmFseXRpY3MiOnsidXJsIjoiaHR0cHM6Ly9vcmlnaW4tYW5hbHl0aWNzLXNhbmQuc2FuZGJveC5icmFpbnRyZWUtYXBpLmNvbS9wd2MyaGQ0Nmc5M3M0enkyIn0sInRocmVlRFNlY3VyZUVuYWJsZWQiOnRydWUsInBheXBhbEVuYWJsZWQiOnRydWUsInBheXBhbCI6eyJkaXNwbGF5TmFtZSI6Im5wbHVzVGVjaG5vbG9naWVzIiwiY2xpZW50SWQiOiJBYW8zYVQzQ0xvRmwteW9MWnd1MWM1SEZQZ0pkX2NlWHRYeE5SZUcxQ0dTbmJWRThGckpWLU91YkhhOGh3QXVwSi1fSm13SWdKSGJZa0NuOCIsInByaXZhY3lVcmwiOiJodHRwOi8vZXhhbXBsZS5jb20vcHAiLCJ1c2VyQWdyZWVtZW50VXJsIjoiaHR0cDovL2V4YW1wbGUuY29tL3RvcyIsImJhc2VVcmwiOiJodHRwczovL2Fzc2V0cy5icmFpbnRyZWVnYXRld2F5LmNvbSIsImFzc2V0c1VybCI6Imh0dHBzOi8vY2hlY2tvdXQucGF5cGFsLmNvbSIsImRpcmVjdEJhc2VVcmwiOm51bGwsImFsbG93SHR0cCI6dHJ1ZSwiZW52aXJvbm1lbnROb05ldHdvcmsiOmZhbHNlLCJlbnZpcm9ubWVudCI6Im9mZmxpbmUiLCJ1bnZldHRlZE1lcmNoYW50IjpmYWxzZSwiYnJhaW50cmVlQ2xpZW50SWQiOiJtYXN0ZXJjbGllbnQzIiwiYmlsbGluZ0FncmVlbWVudHNFbmFibGVkIjp0cnVlLCJtZXJjaGFudEFjY291bnRJZCI6Im5wbHVzdGVjaG5vbG9naWVzIiwiY3VycmVuY3lJc29Db2RlIjoiVVNEIn0sIm1lcmNoYW50SWQiOiJwd2MyaGQ0Nmc5M3M0enkyIiwidmVubW8iOiJvZmYifQ==";
            return this.OKRESPONSE<UserClientTokenModel>(userClientTokenModel, userClientTokenModel == null ? "Card_List_Not_Found" : "Card_List_found");
        }
    }
}
