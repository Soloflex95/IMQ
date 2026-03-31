# IMQ Core Entities

## 1. User
Represents an authenticated individual interacting with the system.

Attributes:
- UserId
- Name
- Email
- Role(s)
- TenantId

---

## 2. Worker
Represents an employee or contractor whose qualifications are tracked.

Attributes:
- WorkerId
- UserId (linked account)
- Job Assignments
- ManagerId
- Qualification Records

---

## 3. Job Title
Defines a role within the organization.

Attributes:
- JobTitleId
- Name
- Description

---

## 4. Job Requirement
Defines the required qualifications for a job.

Attributes:
- RequirementId
- JobTitleId
- Required Skills
- Required Education
- Required Certifications

---

## 5. Qualification Record
Represents a worker’s qualifications.

Attributes:
- QualificationId
- WorkerId
- Skills
- Education
- Certifications
- Experience

---

## 6. Assessment
Evaluation of a worker against job requirements.

Attributes:
- AssessmentId
- WorkerId
- RequirementId
- Status (Qualified / Not Qualified / Pending)
- Decision Reasons
- Approval Signature

---

## 7. Audit Record
Tracks all system actions.

Attributes:
- AuditId
- UserId
- Action
- Timestamp
- EntityAffected
