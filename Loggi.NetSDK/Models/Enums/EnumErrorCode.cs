﻿#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Loggi.NetSDK.Models.Enums
{
    /// <summary>
    /// Representa os codigos de erros possiveis ao falhar em uma chamada da API.
    /// </summary>
    public enum EnumErrorCode
    {
        Cancelled = 1,
        Unknown = 2,
        InvalidArgument = 3,
        DeadlineExceeded = 4,
        NotFound = 5,
        AlreadyExists = 6,
        PermissionDenied = 7,
        ResourceExhausted = 8,
        FailedPrecondition = 9,
        Aborted = 10,
        OutOfRange = 11,
        Unimplemented = 12,
        Internal = 13,
        Unavailable = 14,
        DataLoss = 15,
        Unauthenticated = 16
    }
}