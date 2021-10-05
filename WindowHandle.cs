using System;
using System.Collections.Generic;
using System.Text;

namespace scape
{
    public interface IWindowHandle
    {
        public string handle { get; set; }
        public void GetHandle(string wndTitle);
    }
}
