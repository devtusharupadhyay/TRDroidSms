using System;
using System.Collections.Generic;
using System.Text;

namespace TRDroidSms
{
    public interface IStartSmsService
    {
        void ChangeNumberAndStartService(string number);
    }
}
