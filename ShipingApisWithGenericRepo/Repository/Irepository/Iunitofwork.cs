using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithGenericRepo.Repository.Irepository
{
    public interface Iunitofwork
    {
        IshipFromAddress IshipFromAddress { get; }
        IshipToAddress ishipToAddress { get; }
        IshipmentPackages IshipmentPackages { get; }
        Ishipment ishipment { get; }
        Iclient iclient { get; }
        void save();

    }
}
