using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurisDict.Wpf.ViewModels.Interfaces
{
    public interface IUpdatable<TModel>
    {
        bool IsUpdated { get; set; }
        TModel Model { get; set; }
    }
}
