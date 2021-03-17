using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HTask1.Interfaces;

namespace HTask1.Controllers{
    /*Inject,on Life Cycle
    Object summoned as trainsient is reconstructed each time
    The object we put up with Scoped creates a copy and we come across it, it changes according to the request.
    In Singleton, it gives the same value as long as the project is standing.
    We can give constructor injection and method injection as parameters.
    We need to write ourselves in property injection service i.
    */
    [ApiController]
    [Route("[controller]")]
    public class InjectionController : ControllerBase
    {

        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;
        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;


        public InjectionController(ITransientService transientService1,
                                         ITransientService transientService2,
                                         IScopedService scopedService1,
                                         IScopedService scopedService2,
                                         ISingletonService singletonService1,
                                         ISingletonService singletonService2)
        {
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
        }

        //method injections da from services sayesinde parametre olarak alabiliyoruz instance'ı

        [HttpGet]
        [Route("GetActionInjection")]
        public string GetActionInjection([FromServices] IScopedService scopedService)
        {
            string result = $"ScopedService : {scopedService.GetId()}";
            return result;
        }

        //Property Injectionda services kısmını kendimiz yazmamız lazım otomatik olarak gelmiyor parametreyle.

        [HttpGet]
        [Route("GetPropertyInjection")]
        public string GetPropertyInjection()
        {

            var services = this.HttpContext.RequestServices;
            var scopedService = (IScopedService)services.GetService(typeof(IScopedService));
            string res = $"Scoped Propery : {scopedService.GetId()}";
            return res;

        }

        [HttpGet]
        public string Get()
        {
            string result = $"Transient1 : {_transientService1.GetId()} {Environment.NewLine}" +
                            $"Transient2 : {_transientService2.GetId()} {Environment.NewLine}" +
                            $"Scoped1    : {_scopedService1.GetId() } {Environment.NewLine}" +
                            $"Scoped2    : {_scopedService2.GetId()} {Environment.NewLine}" +
                            $"Singleton1  : {_singletonService1.GetId() } {Environment.NewLine}" +
                            $"singleton2    : {_singletonService2.GetId()} {Environment.NewLine}";

            return result;



        }
    }
}