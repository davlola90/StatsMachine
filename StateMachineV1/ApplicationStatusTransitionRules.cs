namespace StateMachineV1;

public static class ApplicationStatusTransitionRules
{
    
    private static ApplicationStatusTransition WaitingForApprovalRules { get; } = new()
    {
        CurrentStatus = ApplicationStatus.WaitingForApproval,
        AllowedNextStatus = new List<ApplicationStatus>
        {
            ApplicationStatus.Started,
            ApplicationStatus.Rejected
        }
    };
    private static ApplicationStatusTransition StartStepRules { get; } = new()
    {
        CurrentStatus = ApplicationStatus.Started,
        AllowedNextStatus = new List<ApplicationStatus>
        {
            ApplicationStatus.Stage1Test,
            ApplicationStatus.Rejected
        },
        AllowedPreviousStatus = new List<ApplicationStatus>
        {
            ApplicationStatus.WaitingForApproval
        }
    };

    private static ApplicationStatusTransition Stage1TestRules { get; } = new()
    {
        CurrentStatus = ApplicationStatus.Stage1Test,
        AllowedPreviousStatus = new List<ApplicationStatus>
        {
            ApplicationStatus.Started
        },
        AllowedNextStatus = new List<ApplicationStatus>
        {
            ApplicationStatus.PassedStage1Test,
            ApplicationStatus.FailedStage1Test,
            ApplicationStatus.Rejected
        }
    };

    private static ApplicationStatusTransition PassedStage1TestRules { get; } = new()
    {
        CurrentStatus = ApplicationStatus.PassedStage1Test,
        AllowedPreviousStatus = new List<ApplicationStatus>
        {
            ApplicationStatus.Stage1Test,
            ApplicationStatus.Started
        },
        AllowedNextStatus = new List<ApplicationStatus>
        {   
            ApplicationStatus.CodingTest,
            ApplicationStatus.Rejected
        }
    };
    
    private static ApplicationStatusTransition FailedStage1TestRules { get; } = new()
    {
        CurrentStatus = ApplicationStatus.FailedStage1Test,
        AllowedPreviousStatus = new List<ApplicationStatus>
        {
            ApplicationStatus.Stage1Test,
            ApplicationStatus.Started
        },
        AllowedNextStatus = new List<ApplicationStatus>
        {
            ApplicationStatus.Rejected
        }
    };
    
    private static ApplicationStatusTransition CodingTestRules { get; } = new()
    {
        CurrentStatus = ApplicationStatus.CodingTest,
        AllowedPreviousStatus = new List<ApplicationStatus>
        {
            ApplicationStatus.Started
        },
        AllowedNextStatus = new List<ApplicationStatus>
        {
            ApplicationStatus.CodingTestPassed,
            ApplicationStatus.CodingTestFailed,
            ApplicationStatus.Rejected
        }
    };
    
    private static ApplicationStatusTransition CodingTestPassedRules { get; } = new()
    {
        CurrentStatus = ApplicationStatus.CodingTestPassed,
        AllowedPreviousStatus = new List<ApplicationStatus>
        {
            ApplicationStatus.CodingTest,
            ApplicationStatus.Started
        },
        AllowedNextStatus = new List<ApplicationStatus>
        {
            ApplicationStatus.Decision,
            ApplicationStatus.Rejected
        }
    };
    
    private static ApplicationStatusTransition CodingTestFailedRules { get; } = new()
    {
        CurrentStatus = ApplicationStatus.CodingTestFailed,
        AllowedPreviousStatus = new List<ApplicationStatus>
        {
            ApplicationStatus.CodingTest,
            ApplicationStatus.Started
        },
        AllowedNextStatus = new List<ApplicationStatus>
        {
            ApplicationStatus.Rejected
        }
    };
    
    private static ApplicationStatusTransition DecisionRules { get; } = new()
    {
        CurrentStatus = ApplicationStatus.Decision,
        AllowedPreviousStatus = new List<ApplicationStatus>
        {
            ApplicationStatus.CodingTestPassed,
            ApplicationStatus.Started
        },
        AllowedNextStatus = new List<ApplicationStatus>
        {
            ApplicationStatus.Hired,
            ApplicationStatus.Rejected
        }
    };

    public static ApplicationStatusTransition GetTransitionRules(ApplicationStatus applicationStatus)
    {
        return applicationStatus switch
        {
            ApplicationStatus.WaitingForApproval => WaitingForApprovalRules,
            ApplicationStatus.Started => StartStepRules,
            ApplicationStatus.Stage1Test => Stage1TestRules,
            ApplicationStatus.PassedStage1Test => PassedStage1TestRules,
            ApplicationStatus.FailedStage1Test => FailedStage1TestRules,
            ApplicationStatus.CodingTest => CodingTestRules,
            ApplicationStatus.CodingTestPassed => CodingTestPassedRules,
            ApplicationStatus.CodingTestFailed => CodingTestFailedRules,
            ApplicationStatus.Decision => DecisionRules,
            _ => throw new ArgumentOutOfRangeException(nameof(applicationStatus), applicationStatus, null)
        };
    }
}