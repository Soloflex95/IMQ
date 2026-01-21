namespace IMQ.Core.Data;

/// <summary>
/// Master list of standardized qualification titles for GxP compliance
/// </summary>
public static class MasterQualificationList
{
    /// <summary>
    /// Standardized qualification titles used across the system
    /// </summary>
    public static readonly List<string> StandardTitles = new()
    {
        // Aseptic & Sterile Operations
        "Aseptic Technique",
        "Sterile Gowning",
        "Clean Room Operations",
        "Environmental Monitoring",
        
        // Quality & Compliance
        "GMP Compliance",
        "GDP Compliance",
        "GLP Compliance",
        "GCP Compliance",
        "21 CFR Part 11",
        "EU Annex 11",
        "Data Integrity",
        "Quality Auditing",
        "Root Cause Analysis",
        "CAPA Management",
        "Deviation Handling",
        
        // Documentation & Procedures
        "SOP Documentation",
        "Batch Record Review",
        "Technical Writing",
        "Electronic Batch Records",
        "Document Control",
        
        // Laboratory Skills
        "HPLC Operation",
        "GC Operation",
        "UV-Vis Spectroscopy",
        "Karl Fischer Titration",
        "Dissolution Testing",
        "Microbiology Testing",
        "Endotoxin Testing",
        "Sterility Testing",
        "Method Validation",
        "Analytical Method Transfer",
        
        // Manufacturing & Processing
        "Tablet Compression",
        "Capsule Filling",
        "Blending Operations",
        "Granulation",
        "Coating Operations",
        "Lyophilization",
        "Fermentation",
        "Cell Culture",
        "Downstream Processing",
        "Formulation Development",
        
        // Equipment & Calibration
        "Equipment Qualification (IQ/OQ/PQ)",
        "Calibration Management",
        "Preventive Maintenance",
        "Change Control",
        "Equipment Cleaning",
        
        // Inspection & Testing
        "Visual Inspection",
        "In-Process Testing",
        "Finished Product Testing",
        "Stability Testing",
        "Raw Material Testing",
        
        // Safety & Handling
        "Chemical Safety",
        "Biosafety Level 2",
        "Biosafety Level 3",
        "Hazardous Material Handling",
        "Controlled Substance Handling",
        "Waste Management",
        
        // Regulatory & Submissions
        "Regulatory Submissions",
        "FDA Inspection Readiness",
        "EMA Inspection Readiness",
        "Annual Product Review",
        "Product Quality Review",
        
        // Clinical & Study Management
        "Good Clinical Practice (GCP)",
        "Clinical Trial Management",
        "Informed Consent",
        "Adverse Event Reporting",
        "Protocol Development",
        "Study Monitoring",
        "Site Management",
        
        // Packaging & Labeling
        "Packaging Operations",
        "Labeling Review",
        "Serialization",
        "Tamper Evidence",
        
        // Software & Systems
        "LIMS Administration",
        "ERP Systems (SAP)",
        "CSV (Computer System Validation)",
        "Electronic Signatures",
        "Laboratory Informatics",
        
        // Project Management
        "Project Management",
        "Risk Management",
        "Validation Master Planning",
        "Technology Transfer"
    };
}
