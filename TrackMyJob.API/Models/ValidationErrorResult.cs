namespace TrackMyJob.API.Models;

#pragma warning disable CA1819 // Properties should not return arrays (suppressed as this is a DTO class)

public record ValidationErrorResultModel(string[] errors);

#pragma warning restore CA1819 // Properties should not return arrays