namespace StateMachineV1;

public enum ApplicationStatus
{
    WaitingForApproval,
    Started,
    Stage1Test,
    PassedStage1Test,
    FailedStage1Test,
    CodingTest,
    CodingTestPassed,
    CodingTestFailed,
    Decision,
    Rejected,
    Hired
}