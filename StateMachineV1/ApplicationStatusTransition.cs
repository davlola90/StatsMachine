namespace StateMachineV1;

public class ApplicationStatusTransition
{
    public ApplicationStatus CurrentStatus { get; init; }
    public List<ApplicationStatus> AllowedPreviousStatus { get; init; } = new();
    
    public List<ApplicationStatus> AllowedNextStatus { get; init; } = new();
}