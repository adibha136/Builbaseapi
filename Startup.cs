using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Owin;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.DataHandler.Encoder;


namespace RabbittAPI
{
    public class Startup : ApiController
    {
        // GET api/<controller>
        //public static void main(string[] args)
        //{
        //    var builder = new ConfigurationBuilder();
          
        //}
        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }


        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            var issuer = "yourIssuer";
            var audience = "yourAudience";
            var secret = TextEncodings.Base64Url.Decode("401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1");

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(secret)
                }
            });

            //var issuer = "http://yourdomain.com";
            //var audience = "yourAudience";
            //var secret = Convert.FromBase64String("401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1");

            //app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            //{
            //    AuthenticationMode = AuthenticationMode.Active,
            //    TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidIssuer = issuer,
            //        ValidAudience = audience,
            //        IssuerSigningKey = new SymmetricSecurityKey(secret)
            //    }
            //});

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            //app.UseWebApi(config);

        }
        //public void Configuration(IAppBuilder app)
        //{
        //    // Configure the OWIN pipeline here.
        //}

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    string someConfigValue = Configuration.GetValue<string>("401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1");
        //}

        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    // ...
        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapHub<ChatHub>("/chatHub");
        //        endpoints.MapControllerRoute(
        //            name: "default",
        //            pattern: "{controller=Home}/{action=Index}/{id?}");
        //    });
        //}
    }
}