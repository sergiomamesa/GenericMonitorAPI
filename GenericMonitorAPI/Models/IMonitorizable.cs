using System;

namespace GenericMonitorAPI.Context
{
    internal interface IMonitorizable
    {
        int Id { get; set; }
        string Title { get; set; }
        string Message { get; set; }
        DateTime CreationDate { get; }
    }
}