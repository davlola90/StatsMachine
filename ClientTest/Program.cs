// See https://aka.ms/new-console-template for more information


using StateMachineV1;

var canMoveFromStartedToStageOne = ApplicationStatusManager.CanTransitionToNextState(ApplicationStatus.Started, ApplicationStatus.Stage1Test);
var canMoveBackFromStageOneToStarted = ApplicationStatusManager.CanTransitionToNextState(ApplicationStatus.Stage1Test, ApplicationStatus.Started);

Console.WriteLine("Hello, World!");