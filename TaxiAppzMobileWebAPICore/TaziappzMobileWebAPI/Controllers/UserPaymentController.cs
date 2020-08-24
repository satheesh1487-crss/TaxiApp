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

        #region Payment-historySingle
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("historySingle")]
        public IActionResult HistorySingle(GeneralModel generalModel)
        {
            List<UserPaymentModel> userPaymentModel = new List<UserPaymentModel>();
            userPaymentModel[0].Preferred_Payment_Type = 1;
            return this.OK<List<UserPaymentModel>>(userPaymentModel, userPaymentModel == null ? "Preferred_Payment_Not_Found" : "Preferred_Payment_found", userPaymentModel == null ? 0 : 1);
        }
        #endregion

        #region Payment-addwallet
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("addwallet")]
        public IActionResult AddWallet(GeneralModel generalModel)
        {
            List<UserAddWalletModel> userAddWalletModel = new List<UserAddWalletModel>();
            userAddWalletModel[0].Amount_Added = 20;
            userAddWalletModel[0].Amount_Balance = 15;
            userAddWalletModel[0].Amount_Spent = 5;
            userAddWalletModel[0].Currency = "$";
            return this.OK<List<UserAddWalletModel>>(userAddWalletModel, userAddWalletModel == null ? "Add_Wallet_Not_Found" : "Add_Wallet_found", userAddWalletModel == null ? 0 : 1);
        }
        #endregion

        #region Payment-addCard
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
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
        #endregion

        #region Payment-deleteCard
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("deleteCard")]
        public IActionResult DeleteCard(GeneralModel generalModel)
        {
            List<UserDeleteCardModel> userDeleteCardModel = new List<UserDeleteCardModel>();
            userDeleteCardModel[0].Payment = new List<UserDeletePayment>();
            return this.OK<List<UserDeleteCardModel>>(userDeleteCardModel, userDeleteCardModel == null ? "Delete_Card_Not_Found" : "Delete_Card_found", userDeleteCardModel == null ? 0 : 1);
        }
        #endregion

        #region Payment-getwallet
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("getwallet")]
        public IActionResult Getwallet(GeneralModel generalModel)
        {
            List<UserGetWalletModel> userGetWalletModel = new List<UserGetWalletModel>();
            userGetWalletModel[0].Amount_Added = 20;
            userGetWalletModel[0].Amount_Balance = 15;
            userGetWalletModel[0].Amount_Spent = 5;
            userGetWalletModel[0].Currency = "$";
            return this.OK<List<UserGetWalletModel>>(userGetWalletModel, userGetWalletModel == null ? "Get_Wallet_Not_Found" : "Get_Wallet_found", userGetWalletModel == null ? 0 : 1);
        }
        #endregion

        #region Payment-cardlist
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("cardlist")]
        public IActionResult Cardlist(GeneralModel generalModel)
        {
            List<UserCardListModel> userCardListModel = new List<UserCardListModel>();
            userCardListModel[0].Payment = new List<CardListPayment>();
            return this.OK<List<UserCardListModel>>(userCardListModel, userCardListModel == null ? "Card_List_Not_Found" : "Card_List_found", userCardListModel == null ? 0 : 1);
        }
        #endregion

        #region Payment-client_token
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("client_token")]
        public IActionResult Client_Token(GeneralModel generalModel)
        {
            List<UserClientTokenModel> userClientTokenModel = new List<UserClientTokenModel>();
            userClientTokenModel[0].Client_Token = "eyJ2ZXJzaW9uIjoyLCJhdXRob3JpemF0aW9uRmluZ2VycHJpbnQiOiJleUowZVhBaU9pSktWMVFpTENKaGJHY2lPaUpGVXpJMU5pSXNJbXRwWkNJNklqSXdNVGd3TkRJMk1UWXRjMkZ1WkdKdmVDSjkuZXlKbGVIQWlPakUxTlRrNE1EYzRNak1zSW1wMGFTSTZJakk1TXpnNU1XWTRMVEpoWm1VdE5EYzJZaTFpT1ROaUxUUTFaV0ZtTVRGbVpXVmtOQ0lzSW5OMVlpSTZJbkIzWXpKb1pEUTJaemt6Y3pSNmVUSWlMQ0pwYzNNaU9pSkJkWFJvZVNJc0ltMWxjbU5vWVc1MElqcDdJbkIxWW14cFkxOXBaQ0k2SW5CM1l6Sm9aRFEyWnpremN6UjZlVElpTENKMlpYSnBabmxmWTJGeVpGOWllVjlrWldaaGRXeDBJanBtWVd4elpYMHNJbkpwWjJoMGN5STZXeUp0WVc1aFoyVmZkbUYxYkhRaVhTd2liM0IwYVc5dWN5STZlMzE5LjM1SzVwVXI3TDk0UV9PcnFGbTlPYmlJdDhQWjJBU3YzNGM2MXd3OVhFTWlXeXB2SWx6NDF0ZlFCN0NSRGJnXzM4cXdGZlJLUXF3cm5pbVFTQlk3VnlRIiwiY29uZmlnVXJsIjoiaHR0cHM6Ly9hcGkuc2FuZGJveC5icmFpbnRyZWVnYXRld2F5LmNvbTo0NDMvbWVyY2hhbnRzL3B3YzJoZDQ2ZzkzczR6eTIvY2xpZW50X2FwaS92MS9jb25maWd1cmF0aW9uIiwiZ3JhcGhRTCI6eyJ1cmwiOiJodHRwczovL3BheW1lbnRzLnNhbmRib3guYnJhaW50cmVlLWFwaS5jb20vZ3JhcGhxbCIsImRhdGUiOiIyMDE4LTA1LTA4In0sImNoYWxsZW5nZXMiOltdLCJlbnZpcm9ubWVudCI6InNhbmRib3giLCJjbGllbnRBcGlVcmwiOiJodHRwczovL2FwaS5zYW5kYm94LmJyYWludHJlZWdhdGV3YXkuY29tOjQ0My9tZXJjaGFudHMvcHdjMmhkNDZnOTNzNHp5Mi9jbGllbnRfYXBpIiwiYXNzZXRzVXJsIjoiaHR0cHM6Ly9hc3NldHMuYnJhaW50cmVlZ2F0ZXdheS5jb20iLCJhdXRoVXJsIjoiaHR0cHM6Ly9hdXRoLnZlbm1vLnNhbmRib3guYnJhaW50cmVlZ2F0ZXdheS5jb20iLCJhbmFseXRpY3MiOnsidXJsIjoiaHR0cHM6Ly9vcmlnaW4tYW5hbHl0aWNzLXNhbmQuc2FuZGJveC5icmFpbnRyZWUtYXBpLmNvbS9wd2MyaGQ0Nmc5M3M0enkyIn0sInRocmVlRFNlY3VyZUVuYWJsZWQiOnRydWUsInBheXBhbEVuYWJsZWQiOnRydWUsInBheXBhbCI6eyJkaXNwbGF5TmFtZSI6Im5wbHVzVGVjaG5vbG9naWVzIiwiY2xpZW50SWQiOiJBYW8zYVQzQ0xvRmwteW9MWnd1MWM1SEZQZ0pkX2NlWHRYeE5SZUcxQ0dTbmJWRThGckpWLU91YkhhOGh3QXVwSi1fSm13SWdKSGJZa0NuOCIsInByaXZhY3lVcmwiOiJodHRwOi8vZXhhbXBsZS5jb20vcHAiLCJ1c2VyQWdyZWVtZW50VXJsIjoiaHR0cDovL2V4YW1wbGUuY29tL3RvcyIsImJhc2VVcmwiOiJodHRwczovL2Fzc2V0cy5icmFpbnRyZWVnYXRld2F5LmNvbSIsImFzc2V0c1VybCI6Imh0dHBzOi8vY2hlY2tvdXQucGF5cGFsLmNvbSIsImRpcmVjdEJhc2VVcmwiOm51bGwsImFsbG93SHR0cCI6dHJ1ZSwiZW52aXJvbm1lbnROb05ldHdvcmsiOmZhbHNlLCJlbnZpcm9ubWVudCI6Im9mZmxpbmUiLCJ1bnZldHRlZE1lcmNoYW50IjpmYWxzZSwiYnJhaW50cmVlQ2xpZW50SWQiOiJtYXN0ZXJjbGllbnQzIiwiYmlsbGluZ0FncmVlbWVudHNFbmFibGVkIjp0cnVlLCJtZXJjaGFudEFjY291bnRJZCI6Im5wbHVzdGVjaG5vbG9naWVzIiwiY3VycmVuY3lJc29Db2RlIjoiVVNEIn0sIm1lcmNoYW50SWQiOiJwd2MyaGQ0Nmc5M3M0enkyIiwidmVubW8iOiJvZmYifQ==";
            return this.OK<List<UserClientTokenModel>>(userClientTokenModel, userClientTokenModel == null ? "Card_List_Not_Found" : "Card_List_found", userClientTokenModel == null ? 0 : 1);
        }
        #endregion
    }
}
