using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Entities.Recipes.Interfaces
{
    public interface IMeasurment
    {
        string ShortName { get; set; }
        IMeasurment SetShortName(string shortName);
        IMeasurment SetName(string name);
    }
}
