﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.Services;
using TaziappzMobileWebAPI.DALayer;
using TaziappzMobileWebAPI.Interface;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        public ISign sign;
        public IToken token;
        public UserController(TaxiAppzDBContext context, ISign _sign, IToken _token)
        {
            _context = context;
           sign = _sign;
            token = _token;
          
        }
        /// <summary>
        /// Use to Get Existing user records
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("UserSignIndetails")]
        public IActionResult UserSignIndetails([FromBody] SignInmodel signInmodel)
        {
            sign = new DASign(_context, token);
           List<DetailsWithToken> detailsWithToken = new List<DetailsWithToken>();
            detailsWithToken =sign.SignIn(signInmodel);
            return this.OK<DetailsWithToken>(detailsWithToken, detailsWithToken.Count == 0 ? "User_SignDetails_Not_Found" : "User_Signdetails_Found", detailsWithToken.Count == 0 ? 0 : 1);
        }
        /// <summary>
        /// Use to Register User
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("RegisterUser")]
        public IActionResult RegisterUser([FromBody] SignUpmodel signUpmodel)
        {
            sign = new DASign(_context, token);
            bool result = sign.SignUp(signUpmodel);
            return this.OKStatus(result ? "User_Creation_Success" : "User_Creation_Failed", result ? 1 : 0);
        }

    } private static bool EstaDentroDeZona(double latitudActual, double longitudActual, List<PuntoPorZona> listaPuntosPorZona)
        {
            Punto<double> vector1 = new Punto<double>();
            Punto<double> vector2 = new Punto<double>();



            int i = 0;
            double a = 0;

            for (i = 0; i < listaPuntosPorZona.Count - 1; i++)
            {
                vector1.X = Convert.ToDouble(listaPuntosPorZona[i].Latitud) - latitudActual;
                vector1.Y = Convert.ToDouble(listaPuntosPorZona[i].Longitud) - longitudActual;
                vector2.X = Convert.ToDouble(listaPuntosPorZona[i + 1].Latitud) - latitudActual;
                vector2.Y = Convert.ToDouble(listaPuntosPorZona[i + 1].Longitud) - longitudActual;

                a = a + Angulo(vector1, vector2);
            }

            double grados = a * 180 / Math.PI;
            return Math.Abs(grados) > 180;
        }
        private static double Angulo(Punto<double> v1, Punto<double> v2)
        {
            double angulo;
            double calculoModulos;
            double calculoProductoEscalar;
            calculoModulos = Modulo(v1) * Modulo(v2);
            calculoProductoEscalar = ProductoEscalar(v1, v2);

            if (ModuloDelProductoVectorialConSigno(v1, v2) > 0)
            {
                angulo = Math.Acos(calculoProductoEscalar / calculoModulos);
            }
            else
            {
                angulo = -1 * (Math.Acos(calculoProductoEscalar / calculoModulos));
            }
            return angulo;
        }
        private static double ProductoEscalar(Punto<double> punto1, Punto<double> punto2)
        {
            double productoEscalcar;
            productoEscalcar = (punto1.X * punto2.X) + (punto1.Y * punto2.Y);
            return productoEscalcar;
        }

        private static double Modulo(Punto<double> punto)
        {
            double modulo;
            modulo = Math.Sqrt(punto.X * punto.X + punto.Y * punto.Y);
            return modulo;
        }
        private static double ModuloDelProductoVectorialConSigno(Punto<double> v1, Punto<double> v2)
        {
            double angulo = ((v1.X * v2.Y) - (v1.Y * v2.X));
            return angulo;
        }

        private struct Punto<T>
        {
            T x;
            T y;

            public Punto(T a, T b)
            {
                x = a;
                y = b;
            }

            public T X
            {
                get { return x; }
                set { x = value; }
            }

            public T Y
            {
                get { return y; }
                set { y = value; }
            }
        }
    }

    public class PuntoPorZona
    {
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
