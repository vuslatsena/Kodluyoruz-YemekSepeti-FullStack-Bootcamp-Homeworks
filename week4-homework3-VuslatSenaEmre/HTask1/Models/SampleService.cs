using System;
using HTask1.Interfaces;

namespace HTask1.Models
{
    public class SampleService : IScoppedService, ITransientService, ISingletonService
    {
        Guid _Id;
        public SampleService()
        {
            _Id = Guid.NewGuid();
        }

        public Guid GetId()
        {
            return _Id;
        }
    }

    public interface IScoppedService
    {
    }
    public interface ITransientService{

    }
     public interface ISingletonService{

    }
}
