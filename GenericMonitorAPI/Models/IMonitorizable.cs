using System;

namespace GenericMonitorAPI.Context
{
    internal interface IMonitorizable
    {
        int Key { get; set; }
        string Title { get; set; }
        string Message { get; set; }
        DateTime CreationDate { get; }
    }
}