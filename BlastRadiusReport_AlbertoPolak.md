# Blast Radius Report: Alberto Polak

**Report Generated:** 2025-12-10  
**Subject:** Alberto Polak (User)  
**Analysis Type:** Security Blast Radius Assessment

## Executive Summary

This report analyzes the potential blast radius of user **Alberto Polak** within the Azure infrastructure. The blast radius represents the scope of potential impact if this user account were to be compromised. Alberto Polak has direct permissions to **33 Azure Key Vault resources** across multiple resource groups and subscriptions.

### Key Findings

- **Total Accessible Resources:** 33 Key Vaults
- **Resource Type:** Microsoft.KeyVault/vaults
- **Subscription:** ab48f397-fc82-4634-aa52-62dd91b3ebaa
- **Permission Type:** Has permissions to (direct access)
- **Path Length:** 1 (direct access - highest risk)

### Risk Assessment Overview

All identified resources represent a **HIGH RISK** level due to:
1. Direct access to sensitive Key Vault resources
2. Key Vaults store critical secrets, certificates, and encryption keys
3. Compromise could lead to widespread credential exposure
4. Single-hop access path (no intermediate controls)

---

## Detailed Entity Rankings

The following entities are ranked by risk level based on their criticality, naming patterns, and potential impact:

### 🔴 CRITICAL RISK - Production & Core Infrastructure (Rank 1-10)

#### 1. wg-prod (Production Key Vault)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/wg-prod-deployments/providers/microsoft.keyvault/vaults/wg-prod`
- **Resource Group:** wg-prod-deployments
- **Risk Factors:** 
  - Production environment naming ("prod")
  - Likely contains production secrets and certificates
  - Critical for production deployments
- **Criticality Score:** 0 (as reported)
- **Has Vulnerabilities:** No

#### 2. woodgrove-ksi-keyvault (KSI Infrastructure)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-rg/providers/microsoft.keyvault/vaults/woodgrove-ksi-keyvault`
- **Resource Group:** woodgrove-rg
- **Risk Factors:**
  - Key infrastructure component (KSI)
  - Part of main resource group
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 3. sentineldemos (Security/Monitoring)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-rg/providers/microsoft.keyvault/vaults/sentineldemos`
- **Resource Group:** woodgrove-rg
- **Risk Factors:**
  - Security monitoring related (Sentinel)
  - Could contain security operation secrets
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 4. CoreId-kv-c2gq (Core Identity Services)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/coreid-rg-0x2y/providers/microsoft.keyvault/vaults/coreid-kv-c2gq`
- **Resource Group:** coreid-rg-0x2y
- **Risk Factors:**
  - Core identity services
  - Critical for authentication/authorization
  - Compromise could affect all user access
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 5. WoodgroveAutomationKV (Automation Services)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-userprovisioning-rg/providers/microsoft.keyvault/vaults/woodgroveautomationkv`
- **Resource Group:** woodgrove-userprovisioning-rg
- **Risk Factors:**
  - User provisioning automation
  - Could affect account creation/management
  - Service account credentials likely stored here
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 6. payroll01 (Financial Data)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-sentinelgraph/providers/microsoft.keyvault/vaults/payroll01`
- **Resource Group:** woodgrove-sentinelgraph
- **Risk Factors:**
  - Payroll system access
  - Contains sensitive financial/employee data credentials
  - High compliance risk (GDPR, financial regulations)
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 7. HubVNet-kv-l3sp (Network Hub)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/hubvnet-rg-0x2y/providers/microsoft.keyvault/vaults/hubvnet-kv-l3sp`
- **Resource Group:** hubvnet-rg-0x2y
- **Risk Factors:**
  - Hub virtual network infrastructure
  - Critical for network connectivity
  - Central point in network topology
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 8. ModernWork-kv-xa1e (Modern Workplace)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/modernwork-rg-0x2y/providers/microsoft.keyvault/vaults/modernwork-kv-xa1e`
- **Resource Group:** modernwork-rg-0x2y
- **Risk Factors:**
  - Modern workplace services (likely M365 integration)
  - Could affect collaboration tools and productivity apps
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 9. DesiredStateManagementKV (Configuration Management)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/ztenv01desiredstate/providers/microsoft.keyvault/vaults/desiredstatemanagementkv`
- **Resource Group:** ztenv01desiredstate
- **Risk Factors:**
  - Desired state configuration
  - Zero Trust environment (ztenv)
  - Critical for infrastructure automation
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 10. parkcitySAP-KV (ERP System)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-alpine/providers/microsoft.keyvault/vaults/parkcitysap-kv`
- **Resource Group:** woodgrove-alpine
- **Risk Factors:**
  - SAP ERP system access
  - Business-critical enterprise resource planning
  - Contains database and system credentials
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

---

### 🟠 HIGH RISK - Security & Infrastructure (Rank 11-20)

#### 11. wg-entra-tls-inspection (Entra ID/TLS Security)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-rg/providers/microsoft.keyvault/vaults/wg-entra-tls-inspection`
- **Resource Group:** woodgrove-rg
- **Risk Factors:** TLS certificates and Entra ID security
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 12. myTLSKeyVault (TLS Certificate Management)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-rg/providers/microsoft.keyvault/vaults/mytlskeyvault`
- **Resource Group:** woodgrove-rg
- **Risk Factors:** TLS/SSL certificates for secure communications
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 13. fw-cert-kv-eodl1fmPodQrU (Firewall Certificates #1)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-rg/providers/microsoft.keyvault/vaults/fw-cert-kv-eodl1fmpodqru`
- **Resource Group:** woodgrove-rg
- **Risk Factors:** Firewall security certificates
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 14. fw-cert-kv-4FYAYX0P5xO3H (Firewall Certificates #2)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-rg/providers/microsoft.keyvault/vaults/fw-cert-kv-4fyayx0p5xo3h`
- **Resource Group:** woodgrove-rg
- **Risk Factors:** Firewall security certificates
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 15. fw-cert-kv-7Ar5j8JJkPbB1 (Firewall Certificates #3)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-rg/providers/microsoft.keyvault/vaults/fw-cert-kv-7ar5j8jjkpbb1`
- **Resource Group:** woodgrove-rg
- **Risk Factors:** Firewall security certificates
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 16. wg-verifiedemployee (Employee Verification)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgroveverifiedemployee/providers/microsoft.keyvault/vaults/wg-verifiedemployee`
- **Resource Group:** woodgroveverifiedemployee
- **Risk Factors:** Employee identity verification system
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 17. wgyubipreregkv (Yubikey/MFA Services)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgroveyubicopoc/providers/microsoft.keyvault/vaults/wgyubipreregkv`
- **Resource Group:** woodgroveyubicopoc
- **Risk Factors:** Multi-factor authentication infrastructure
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 18. DCEDCRKeyVault (Data Collection)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-rg/providers/microsoft.keyvault/vaults/dcedcrkeyvault`
- **Resource Group:** woodgrove-rg
- **Risk Factors:** Data Collection Endpoint/Rules infrastructure
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 19. VmsParkcity (Virtual Machine Management)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-alpine/providers/microsoft.keyvault/vaults/vmsparkcity`
- **Resource Group:** woodgrove-alpine
- **Risk Factors:** VM administrative credentials
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 20. MyKeyVault12 (General Purpose)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-rg/providers/microsoft.keyvault/vaults/mykeyvault12`
- **Resource Group:** woodgrove-rg
- **Risk Factors:** General key vault - purpose unknown
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

---

### 🟡 MEDIUM-HIGH RISK - Development & Security Tools (Rank 21-28)

#### 21. woodgrove-MDC-Vault (Microsoft Defender for Cloud)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-mdc-rg/providers/microsoft.keyvault/vaults/woodgrove-mdc-vault`
- **Resource Group:** woodgrove-mdc-rg
- **Risk Factors:** Security monitoring and compliance
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 22. woodgrove-MDC-Vault-Demo (MDC Demo Environment)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-mdc-rg/providers/microsoft.keyvault/vaults/woodgrove-mdc-vault-demo`
- **Resource Group:** woodgrove-mdc-rg
- **Risk Factors:** Demo environment, lower business impact
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 23. kv-woodgrove-demo-pken (MDC Demo)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-mdc-rg/providers/microsoft.keyvault/vaults/kv-woodgrove-demo-pken`
- **Resource Group:** woodgrove-mdc-rg
- **Risk Factors:** Demo environment
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 24. arcboxksswlrmzv52lg (Arc-enabled Infrastructure #1)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-mdc-rg/providers/microsoft.keyvault/vaults/arcboxksswlrmzv52lg`
- **Resource Group:** woodgrove-mdc-rg
- **Risk Factors:** Azure Arc hybrid management
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 25. arcbox5cmre4mg2r2vw (Arc-enabled Infrastructure #2)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-mdc-arc/providers/microsoft.keyvault/vaults/arcbox5cmre4mg2r2vw`
- **Resource Group:** woodgrove-mdc-arc
- **Risk Factors:** Azure Arc hybrid management
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 26. kv-mdcagentvxbnu (MDC Agent)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/rg-mdcagent/providers/microsoft.keyvault/vaults/kv-mdcagentvxbnu`
- **Resource Group:** rg-mdcagent
- **Risk Factors:** Security agent infrastructure
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 27. kv-zavaprivatey2c2v (Validation Private)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/rg-mdcagent-validation/providers/microsoft.keyvault/vaults/kv-zavaprivatey2c2v`
- **Resource Group:** rg-mdcagent-validation
- **Risk Factors:** Validation/testing environment
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 28. mdtiworkbookm5xeucozid (MDC Workbook)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-rg/providers/microsoft.keyvault/vaults/mdtiworkbookm5xeucozid`
- **Resource Group:** woodgrove-rg
- **Risk Factors:** Workbook/reporting infrastructure
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

---

### 🟢 MEDIUM RISK - AI/Development Services (Rank 29-33)

#### 29. kv-aoaihub265060096545 (Azure OpenAI Hub)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-mdc-ai/providers/microsoft.keyvault/vaults/kv-aoaihub265060096545`
- **Resource Group:** woodgrove-mdc-ai
- **Risk Factors:** AI service API keys
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 30. kv-wgaihub098811020122 (Woodgrove AI Hub)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/wg-ai-hub/providers/microsoft.keyvault/vaults/kv-wgaihub098811020122`
- **Resource Group:** wg-ai-hub
- **Risk Factors:** AI service API keys
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 31. woodgrove-dev-kv (Development Environment)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/woodgrove-rg/providers/microsoft.keyvault/vaults/woodgrove-dev-kv`
- **Resource Group:** woodgrove-rg
- **Risk Factors:** Development environment, non-production
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 32. kv-ignite-adatum (Demo/Conference)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/ignite-woodgrove/providers/microsoft.keyvault/vaults/kv-ignite-adatum`
- **Resource Group:** ignite-woodgrove
- **Risk Factors:** Conference demo environment
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

#### 33. myaccountlinkedin (Third-party Integration)
- **Resource ID:** `/subscriptions/ab48f397-fc82-4634-aa52-62dd91b3ebaa/resourcegroups/appsvc_linux_centralus_basic/providers/microsoft.keyvault/vaults/myaccountlinkedin`
- **Resource Group:** appsvc_linux_centralus_basic
- **Risk Factors:** Third-party service integration
- **Criticality Score:** 0
- **Has Vulnerabilities:** No

---

## Recommendations

### Immediate Actions (Critical Priority)

1. **Implement Principle of Least Privilege**
   - Review if Alberto Polak requires access to all 33 Key Vaults
   - Remove unnecessary permissions, especially to production environments
   - Consider role-based access with time-bound assignments

2. **Enable Enhanced Monitoring**
   - Configure Azure Monitor alerts for Key Vault access by this account
   - Enable audit logging for all accessed Key Vaults
   - Set up anomaly detection for unusual access patterns

3. **Implement Multi-Factor Authentication**
   - Ensure MFA is enforced for this high-privilege account
   - Consider requiring step-up authentication for Key Vault access
   - Implement Conditional Access policies based on location/device

4. **Credential Rotation**
   - Implement automated secret rotation for all Key Vaults
   - Reduce secret lifetime where possible
   - Use managed identities instead of service principals where applicable

### Medium-Term Actions

5. **Access Segmentation**
   - Create separate accounts for different environment tiers (prod/dev/demo)
   - Implement break-glass procedures for emergency access
   - Use Azure Privileged Identity Management (PIM) for just-in-time access

6. **Zero Trust Implementation**
   - Require network restrictions on Key Vault access
   - Implement private endpoints for sensitive Key Vaults
   - Enable Azure Key Vault firewall rules

### Long-Term Actions

7. **Regular Access Reviews**
   - Quarterly review of all Key Vault permissions
   - Automated reporting of high-privilege accounts
   - Compliance checks against security baselines

8. **Incident Response Planning**
   - Develop specific runbooks for compromised high-privilege accounts
   - Test credential revocation procedures
   - Document emergency secret rotation procedures

---

## Risk Scoring Methodology

The entities were ranked based on the following criteria:

1. **Environment Type** (30% weight)
   - Production: Highest risk
   - Core Infrastructure: Critical risk
   - Development/Demo: Lower risk

2. **Resource Purpose** (30% weight)
   - Financial/Payroll: Highest risk
   - Identity/Authentication: Critical risk
   - Security Infrastructure: High risk
   - AI/Development: Medium risk

3. **Business Impact** (20% weight)
   - Enterprise systems (SAP, Core ID): Highest impact
   - Security/Monitoring: High impact
   - Demo/Test: Lower impact

4. **Compliance Requirements** (20% weight)
   - Financial data: Highest compliance risk
   - PII/Employee data: High compliance risk
   - Technical infrastructure: Medium compliance risk

**Note on Criticality Scores:** The "Criticality Score: 0" shown for each resource is the base score reported by the security graph API. The risk rankings in this report (Critical, High, Medium-High, Medium) are derived from our manual analysis using the methodology above, which considers additional contextual factors beyond the base criticality score. All resources should be considered high-risk due to the direct access pattern and the sensitive nature of Key Vault resources.

---

## Conclusion

Alberto Polak's account represents a **significant security risk** due to the extensive blast radius across 33 Key Vault resources. The direct access pattern (single-hop) means there are no intermediate security controls that could limit damage in case of account compromise.

**Estimated Blast Radius Impact:** If this account is compromised, an attacker would have immediate access to secrets, certificates, and keys across production, development, and security infrastructure environments, potentially affecting:
- Production deployments
- Identity and authentication systems
- Financial/payroll systems
- Network security infrastructure
- ERP systems (SAP)
- AI services and APIs

**Priority:** This account should be treated as a Tier 0 asset requiring the highest level of security controls and monitoring.

---

**Report Classification:** Internal Security Assessment  
**Next Review Date:** 2026-01-10  
**Prepared by:** Security Analysis Tool
