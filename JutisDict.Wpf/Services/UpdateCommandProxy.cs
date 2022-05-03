using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurisDict.Wpf.Services
{
    public class UpdateCommandProxy
    {
        public event Action OnUpdate;
        public void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}
