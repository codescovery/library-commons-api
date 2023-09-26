using Codescovery.Library.Commons.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Codescovery.Library.Api.Exceptions;

public class ModelStateException : Exception
{
    public const string DefaultMessage = "Error while validating request model";

    public ModelStateException(ModelStateDictionary modelStateDictionary, string? aditionalMessage = null, Exception? innerException = null) :
        base($"{DefaultMessage}{(aditionalMessage == null || aditionalMessage.IsNullOrWhiteSpace() ? string.Empty : $" AditionalMessage: {aditionalMessage}")}",
            innerException)
    {
        Errors = modelStateDictionary.Values
            .SelectMany(entry => entry.Errors)
            .Select(error => error.ErrorMessage)
            .ToList();
    }
    public IReadOnlyList<string> Errors { get; set; }
}