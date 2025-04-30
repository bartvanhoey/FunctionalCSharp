namespace FunctionalCSharp.Shared.ResultClass;

public  class BaseResultError
{
    private BaseResultError(List<string> errors) => Messages = errors ?? throw new ArgumentNullException(nameof(errors));

    protected BaseResultError(string? errorMessage) : this([errorMessage ?? string.Empty])
    {
    }
    public List<string> Messages { get; }
    public static implicit operator string(BaseResultError error) => string.Join(";", error.Messages);
}