using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Business.BusinessAspects.Autofac
{

    public class IpBan : MethodInterception
    {
        private IHttpContextAccessor _httpContextAccessor;
        private List<IpDetailDto> _ipDetails;
        public readonly int _maxWarningCount = 5;
        public readonly int _banDuration = 60;
        public readonly double _maxIntervalTime = 50;

        public IpBan(int banDuration = 60)
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            _ipDetails = new List<IpDetailDto>();
            _banDuration = banDuration;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            string ipAdress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            foreach (var ipDetail in _ipDetails)
            {
                if (ipDetail.IpAdress == ipAdress)
                {
                    if (ipDetail.WarningCount >= _maxWarningCount - 1)
                    {
                        if (ipDetail.Time.AddSeconds(_banDuration) > DateTime.Now)
                        {
                            throw new Exception($"Bu ip adresi {ipDetail.Time.AddSeconds(_banDuration)} tarihine kadar banlandı.");
                        }
                        else
                        {
                            ipDetail.WarningCount = 0;
                        }
                    }

                    var interval = DateTime.Now - ipDetail.Time;
                    if (interval.Milliseconds < _maxIntervalTime)
                    {
                        ipDetail.WarningCount++;
                    }
                }
            }

            _ipDetails.Add(new IpDetailDto()
            {
                IpAdress = ipAdress,
                Time = DateTime.Now,
                WarningCount = 0
            });

        }
    }
}
