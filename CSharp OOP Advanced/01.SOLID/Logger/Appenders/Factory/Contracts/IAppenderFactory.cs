using Logger.Appenders.Contracts;
using Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders.Factory.Interfaces
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
