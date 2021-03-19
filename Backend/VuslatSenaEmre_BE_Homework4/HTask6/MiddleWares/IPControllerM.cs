using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;


namespace HTask6.MiddleWares
{
    public class IPControllerM
    {
        readonly RequestDelegate _next;
        IConfiguration _configuration;
        public IPControlMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _configuration = configuration;
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            //Client'ın IP adresini al
            IPAddress remoteIp = context.Connection.RemoteIpAddress;
            //Whitelist'te ki tüm IP'leri çek
            var ips = _configuration.GetSection("WhiteList").AsEnumerable().Where(ip => !string.IsNullOrEmpty(ip.Value)).Select(ip => ip.Value).ToList();

            //Client IP, whitelist'te var mı kontrol et
            if (!ips.Where(ip => IPAddress.Parse(ip).Equals(remoteIp)).Any())
            {
                //Eğer yoksa 403 hatası ver
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsync("Bu IP'nin erişim yetkisi yoktur.");
                return;
            }

            await _next.Invoke(context);
        }
    }
}