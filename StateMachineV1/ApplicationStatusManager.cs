namespace StateMachineV1;

public static class ApplicationStatusManager
{
    public static bool CanTransitionToNextState(ApplicationStatus currentStatus, ApplicationStatus nextStatus)
    {
        var currentStatusRules = ApplicationStatusTransitionRules.GetTransitionRules(currentStatus);
        return currentStatusRules.AllowedNextStatus.Contains(nextStatus) ||
               currentStatusRules.AllowedPreviousStatus.Contains(nextStatus);
    }

    public static void ChangeStatus(ApplicationStatus currentStatus, ApplicationStatus nextStatus)
    {
        if (!CanTransitionToNextState(currentStatus, nextStatus))
            throw new InvalidOperationException($"Cannot transition from {currentStatus} to {nextStatus}");
        
            Console.WriteLine($"Application status changed from {currentStatus} to {nextStatus}");
    }
}