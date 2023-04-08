using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common
{
    public interface IHandler<T> where T : class
    {
        IHandler<T> SetSuccessor(IHandler<T> successor);
        void Handle(T request);
    }

}
