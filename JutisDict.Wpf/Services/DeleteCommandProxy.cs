using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurisDict.Wpf.Services
{
    public class DeleteCommandProxy
    {
        public event Action OnDelete;
        public void Delete()
        {
            OnDelete?.Invoke();
        }
    }
}
