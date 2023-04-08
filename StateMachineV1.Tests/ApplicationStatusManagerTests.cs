namespace StateMachineV1.Tests;

public class ApplicationStatusManagerTests
{
    [Fact]
    public void GetTransitionRules_ValidApplicationStatus_ReturnsCorrectTransitionRules()
    {
        var currentStatus = ApplicationStatus.WaitingForApproval;
        var expectedAllowedPreviousStatus = new List<ApplicationStatus>();
        var expectedAllowedNextStatus = new List<ApplicationStatus>()
        {
            ApplicationStatus.Started,
            ApplicationStatus.Rejected
        };

        var transitionRules = ApplicationStatusTransitionRules.GetTransitionRules(currentStatus);

        Assert.Equal(currentStatus, transitionRules.CurrentStatus);
        Assert.Equal(expectedAllowedPreviousStatus, transitionRules.AllowedPreviousStatus);
        Assert.Equal(expectedAllowedNextStatus, transitionRules.AllowedNextStatus);
    }


    
    [Fact]
    public void ChangeStatus_WaitingForApprovalToStarted_Success()
    {
        TestValidTransition(ApplicationStatus.WaitingForApproval, ApplicationStatus.Started);
    }

    [Fact]
    public void ChangeStatus_WaitingForApprovalToRejected_Success()
    {
        TestValidTransition(ApplicationStatus.WaitingForApproval, ApplicationStatus.Rejected);
    }

    [Fact]
    public void ChangeStatus_StartedToStage1Test_Success()
    {
        TestValidTransition(ApplicationStatus.Started, ApplicationStatus.Stage1Test);
    }

    [Fact]
    public void ChangeStatus_StartedToRejected_Success()
    {
        TestValidTransition(ApplicationStatus.Started, ApplicationStatus.Rejected);
    }

    [Fact]
    public void ChangeStatus_Stage1TestToPassedStage1Test_Success()
    {
        TestValidTransition(ApplicationStatus.Stage1Test, ApplicationStatus.PassedStage1Test);
    }

    [Fact]
    public void ChangeStatus_Stage1TestToFailedStage1Test_Success()
    {
        TestValidTransition(ApplicationStatus.Stage1Test, ApplicationStatus.FailedStage1Test);
    }

    [Fact]
    public void ChangeStatus_Stage1TestToRejected_Success()
    {
        TestValidTransition(ApplicationStatus.Stage1Test, ApplicationStatus.Rejected);
    }

    [Fact]
    public void ChangeStatus_PassedStage1TestToCodingTest_Success()
    {
        TestValidTransition(ApplicationStatus.PassedStage1Test, ApplicationStatus.CodingTest);
    }

    [Fact]
    public void ChangeStatus_PassedStage1TestToRejected_Success()
    {
        TestValidTransition(ApplicationStatus.PassedStage1Test, ApplicationStatus.Rejected);
    }

    [Fact]
    public void ChangeStatus_FailedStage1TestToRejected_Success()
    {
        TestValidTransition(ApplicationStatus.FailedStage1Test, ApplicationStatus.Rejected);
    }

    [Fact]
    public void ChangeStatus_CodingTestToCodingTestPassed_Success()
    {
        TestValidTransition(ApplicationStatus.CodingTest, ApplicationStatus.CodingTestPassed);
    }

    [Fact]
    public void ChangeStatus_CodingTestToCodingTestFailed_Success()
    {
        TestValidTransition(ApplicationStatus.CodingTest, ApplicationStatus.CodingTestFailed);
    }

    [Fact]
    public void ChangeStatus_CodingTestToRejected_Success()
    {
        TestValidTransition(ApplicationStatus.CodingTest, ApplicationStatus.Rejected);
    }

    [Fact]
    public void ChangeStatus_CodingTestPassedToDecision_Success()
    {
        TestValidTransition(ApplicationStatus.CodingTestPassed, ApplicationStatus.Decision);
    }

    [Fact]
    public void ChangeStatus_CodingTestPassedToRejected_Success()
    {
        TestValidTransition(ApplicationStatus.CodingTestPassed, ApplicationStatus.Rejected);
    }

    [Fact]
    public void ChangeStatus_CodingTestFailedToRejected_Success()
    {
        TestValidTransition(ApplicationStatus.CodingTestFailed, ApplicationStatus.Rejected);
    }

    [Fact]
    public void ChangeStatus_DecisionToHired_Success()
    {
        TestValidTransition(ApplicationStatus.Decision, ApplicationStatus.Hired);
    }

    [Fact]
    public void ChangeStatus_DecisionToRejected_Success()
    {
        TestValidTransition(ApplicationStatus.Decision, ApplicationStatus.Rejected);
    }

    // Helper method to test valid transitions
    private void TestValidTransition(ApplicationStatus currentStatus, ApplicationStatus nextStatus)
    {
        Assert.True(ApplicationStatusManager.CanTransitionToNextState(currentStatus, nextStatus));
        ApplicationStatusManager.ChangeStatus(currentStatus, nextStatus); // No exception should be thrown
    }

    // Invalid transition tests
    [Fact]
    public void ChangeStatus_WaitingForApprovalToHired_ThrowsException()
    {
        TestInvalidTransition(ApplicationStatus.WaitingForApproval, ApplicationStatus.Hired);
    }

    [Fact]
    public void ChangeStatus_StartedToHired_ThrowsException()
    {
        TestInvalidTransition(ApplicationStatus.Started, ApplicationStatus.Hired);
    }

    [Fact]
    public void ChangeStatus_CodingTestPassedToCodingTest_Success()
    {
        TestValidTransition(ApplicationStatus.CodingTestPassed, ApplicationStatus.CodingTest);
    }


    // Helper method to test invalid transitions
    private void TestInvalidTransition(ApplicationStatus currentStatus, ApplicationStatus nextStatus)
    {
        Assert.False(ApplicationStatusManager.CanTransitionToNextState(currentStatus, nextStatus));

        // Ensure that an InvalidOperationException is thrown when attempting an invalid transition
        Assert.Throws<InvalidOperationException>(() =>
            ApplicationStatusManager.ChangeStatus(currentStatus, nextStatus));
    }
    
    [Fact]
    public void GetTransitionRules_InvalidApplicationStatus_ThrowsException()
    {
        var invalidApplicationStatus = (ApplicationStatus) (-1); // Create an invalid ApplicationStatus value
        Assert.Throws<ArgumentOutOfRangeException>(() => ApplicationStatusTransitionRules.GetTransitionRules(invalidApplicationStatus));
    }

}