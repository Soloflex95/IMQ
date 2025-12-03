using IMQ.Core.Entities;

namespace IMQ.Core.Interfaces;

/// <summary>
/// Assessment Engine service for evaluating worker qualifications against job requirements
/// </summary>
public interface IAssessmentService
{
    /// <summary>
    /// Evaluate a worker's qualification against a job's requirements
    /// </summary>
    /// <param name="qualificationId">Qualification to assess</param>
    /// <param name="jobId">Job requirements to assess against</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Assessment result with color-coded status</returns>
    Task<Assessment> AssessQualificationAsync(Guid qualificationId, Guid jobId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Batch assess all qualifications for a worker against a job
    /// </summary>
    Task<IEnumerable<Assessment>> AssessWorkerForJobAsync(Guid workerId, Guid jobId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Manager approval with e-signature
    /// </summary>
    Task<Assessment> ApproveAssessmentAsync(Guid assessmentId, string approvedBy, string reasonCode, string? justification = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Manager override with mandatory justification
    /// </summary>
    Task<Assessment> OverrideAssessmentAsync(Guid assessmentId, string approvedBy, string reasonCode, string overrideJustification, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Publish assessment to Auditor Portal
    /// </summary>
    Task PublishAssessmentAsync(Guid assessmentId, string publishedBy, CancellationToken cancellationToken = default);
}
