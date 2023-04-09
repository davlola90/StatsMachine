# State Machine Configuration

This document describes the configuration of the state machine used in the application.

## States

The application has the following states:

- **WaitingForApproval**: The application is waiting for approval from the hiring manager.
- **Started**: The application has been started and is in progress.
- **Stage1Test**: The applicant has completed the first stage of the testing process.
- **PassedStage1Test**: The applicant has passed the first stage of the testing process.
- **FailedStage1Test**: The applicant has failed the first stage of the testing process.
- **CodingTest**: The applicant is taking the coding test.
- **CodingTestPassed**: The applicant has passed the coding test.
- **CodingTestFailed**: The applicant has failed the coding test.
- **Decision**: The hiring manager has made a decision about the applicant.
- **Hired**: The applicant has been hired.
- **Rejected**: The applicant has been rejected.

## Transitions

The following transitions are allowed:

- **WaitingForApproval**: Can transition to **Started** or **Rejected**.
- **Started**: Can transition to **Stage1Test**, **Rejected**, or **Hired**.
- **Stage1Test**: Can transition to **PassedStage1Test**, **FailedStage1Test**, or **Rejected**.
- **PassedStage1Test**: Can transition to **CodingTest** or **Rejected**.
- **FailedStage1Test**: Can transition to **Rejected**.
- **CodingTest**: Can transition to **CodingTestPassed**, **CodingTestFailed**, or **Rejected**.
- **CodingTestPassed**: Can transition to **Decision** or **Rejected**.
- **CodingTestFailed**: Can transition to **Rejected**.
- **Decision**: Can transition to **Hired** or **Rejected**.
- **Hired**: No transitions allowed.
- **Rejected**: No transitions allowed.

