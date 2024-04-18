namespace RecALLDemo.Infrasturcture.IntegrationEventLog.Models;


public enum EventState {
    NotPublished = 0,
    InProcess = 1,
    Published = 2,
    PublishedFailed = 3
}
