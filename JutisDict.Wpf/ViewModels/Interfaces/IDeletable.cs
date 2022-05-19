using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurisDict.Wpf.ViewModels.Interfaces
{
    public interface IDeletable
    {
        bool IsDelete { get; set; }
        Guid Id { get; }
    }
}
