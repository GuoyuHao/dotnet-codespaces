# Blast Radius Report: Alberto Polak

## Executive Summary

This report analyzes the blast radius of **Alberto Polak**, identifying all entities that could be impacted if this user account is compromised. The analysis reveals that Alberto Polak has direct permissions to **33 Azure Key Vaults** across multiple resource groups, representing a significant security exposure.

**Key Findings:**
- **Total Entities at Risk:** 33 Azure Key Vaults
- **Path Distance:** All entities are directly accessible (1-hop)
- **Edge Type:** "has permissions to" for all resources
- **Known Vulnerabilities:** None detected across all entities
- **Criticality Score:** 0 (baseline) for all entities

---

## Risk Classification Methodology

Entities are ranked based on the following risk factors:
1. **Production Environment Indicators** - Resources with "prod" naming
2. **Critical Workload Indicators** - Services like AI, MDC (Microsoft Defender for Cloud), Sentinel
3. **Firewall & Security Infrastructure** - Resources with "fw-cert" or security-related naming
4. **Core Identity & Authentication** - Resources related to identity management
5. **General Production Resources** - Other production or sensitive workloads
6. **Development & Testing Resources** - Lower-risk dev/test environments

---

## Entities Ranked by Risk Level

### 🔴 CRITICAL RISK (Tier 1)

These entities represent the highest risk due to production environment designation or critical security infrastructure.

| Rank | Entity Name | Resource Type | Resource Group | Risk Factors |
|------|------------|---------------|----------------|--------------|
| 1 | wg-prod | microsoft.keyvault/vaults | wg-prod-deployments | Production environment, deployment-related |
| 2 | sentineldemos | microsoft.keyvault/vaults | woodgrove-rg | Microsoft Sentinel security operations |
| 3 | wg-entra-tls-inspection | microsoft.keyvault/vaults | woodgrove-rg | Entra ID TLS inspection, identity security |
| 4 | fw-cert-kv-eodl1fmPodQrU | microsoft.keyvault/vaults | woodgrove-rg | Firewall certificate management |
| 5 | fw-cert-kv-4FYAYX0P5xO3H | microsoft.keyvault/vaults | woodgrove-rg | Firewall certificate management |
| 6 | fw-cert-kv-7Ar5j8JJkPbB1 | microsoft.keyvault/vaults | woodgrove-rg | Firewall certificate management |

**Risk Assessment:** Compromise could lead to:
- Production service disruption
- Security infrastructure bypass
- TLS/certificate compromise affecting encrypted communications
- Identity system vulnerabilities

---

### 🟠 HIGH RISK (Tier 2)

These entities support critical workloads including AI, cloud security, and core identity services.

| Rank | Entity Name | Resource Type | Resource Group | Risk Factors |
|------|------------|---------------|----------------|--------------|
| 7 | CoreId-kv-c2gq | microsoft.keyvault/vaults | coreid-rg-0x2y | Core identity services |
| 8 | kv-aoaihub265060096545 | microsoft.keyvault/vaults | woodgrove-mdc-ai | Azure OpenAI Hub, AI workloads |
| 9 | kv-wgaihub098811020122 | microsoft.keyvault/vaults | wg-ai-hub | AI Hub services |
| 10 | woodgrove-MDC-Vault | microsoft.keyvault/vaults | woodgrove-mdc-rg | Microsoft Defender for Cloud |
| 11 | woodgrove-MDC-Vault-Demo | microsoft.keyvault/vaults | woodgrove-mdc-rg | Microsoft Defender for Cloud Demo |
| 12 | kv-woodgrove-demo-pken | microsoft.keyvault/vaults | woodgrove-mdc-rg | Microsoft Defender for Cloud Demo |
| 13 | arcboxksswlrmzv52lg | microsoft.keyvault/vaults | woodgrove-mdc-rg | Azure Arc security workloads |
| 14 | arcbox5cmre4mg2r2vw | microsoft.keyvault/vaults | woodgrove-mdc-arc | Azure Arc security workloads |
| 15 | kv-mdcagentvxbnu | microsoft.keyvault/vaults | rg-mdcagent | MDC Agent infrastructure |

**Risk Assessment:** Compromise could lead to:
- AI service disruption or data exposure
- Cloud security monitoring bypass
- Identity and access management vulnerabilities
- Hybrid cloud (Arc) security gaps

---

### 🟡 MEDIUM RISK (Tier 3)

These entities support important business functions and automation.

| Rank | Entity Name | Resource Type | Resource Group | Risk Factors |
|------|------------|---------------|----------------|--------------|
| 16 | WoodgroveAutomationKV | microsoft.keyvault/vaults | woodgrove-userprovisioning-rg | User provisioning automation |
| 17 | DesiredStateManagementKV | microsoft.keyvault/vaults | ztenv01desiredstate | Zero Trust desired state management |
| 18 | payroll01 | microsoft.keyvault/vaults | woodgrove-sentinelgraph | Payroll system (sensitive PII) |
| 19 | woodgrove-ksi-keyvault | microsoft.keyvault/vaults | woodgrove-rg | Key Security Infrastructure |
| 20 | wg-verifiedemployee | microsoft.keyvault/vaults | woodgroveverifiedemployee | Verified employee credentials |
| 21 | wgyubipreregkv | microsoft.keyvault/vaults | woodgroveyubicopoc | YubiKey pre-registration PoC |
| 22 | ModernWork-kv-xa1e | microsoft.keyvault/vaults | modernwork-rg-0x2y | Modern Work solutions |
| 23 | HubVNet-kv-l3sp | microsoft.keyvault/vaults | hubvnet-rg-0x2y | Hub virtual network infrastructure |
| 24 | parkcitySAP-KV | microsoft.keyvault/vaults | woodgrove-alpine | SAP integration |
| 25 | VmsParkcity | microsoft.keyvault/vaults | woodgrove-alpine | VM management |

**Risk Assessment:** Compromise could lead to:
- Unauthorized user provisioning
- Payroll data exposure (PII/financial data)
- Authentication infrastructure compromise
- Business application disruption

---

### 🟢 MODERATE RISK (Tier 4)

These entities support testing, validation, and development activities.

| Rank | Entity Name | Resource Type | Resource Group | Risk Factors |
|------|------------|---------------|----------------|--------------|
| 26 | kv-zavaprivatey2c2v | microsoft.keyvault/vaults | rg-mdcagent-validation | MDC Agent validation/testing |
| 27 | kv-ignite-adatum | microsoft.keyvault/vaults | ignite-woodgroove | Conference/demo environment |
| 28 | mdtiworkbookm5xeucozid | microsoft.keyvault/vaults | woodgrove-rg | MDTI workbook resources |
| 29 | DCEDCRKeyVault | microsoft.keyvault/vaults | woodgrove-rg | Data Collection Endpoint/Rules |
| 30 | woodgrove-dev-kv | microsoft.keyvault/vaults | woodgrove-rg | Development environment |
| 31 | MyKeyVault12 | microsoft.keyvault/vaults | woodgrove-rg | Generic key vault |
| 32 | myTLSKeyVault | microsoft.keyvault/vaults | woodgrove-rg | TLS certificate testing |
| 33 | myaccountlinkedin | microsoft.keyvault/vaults | appsvc_linux_centralus_basic | Application service testing |

**Risk Assessment:** Compromise could lead to:
- Development/test environment disruption
- Demo environment compromise (limited production impact)
- Testing infrastructure exposure

---

## Blast Radius Analysis

### Attack Path Visualization

```
Alberto Polak (User)
    │
    ├─[has permissions to]─> wg-prod (Key Vault)
    ├─[has permissions to]─> sentineldemos (Key Vault)
    ├─[has permissions to]─> wg-entra-tls-inspection (Key Vault)
    ├─[has permissions to]─> fw-cert-kv-eodl1fmPodQrU (Key Vault)
    ├─[has permissions to]─> fw-cert-kv-4FYAYX0P5xO3H (Key Vault)
    ├─[has permissions to]─> fw-cert-kv-7Ar5j8JJkPbB1 (Key Vault)
    ├─[has permissions to]─> CoreId-kv-c2gq (Key Vault)
    ├─[has permissions to]─> kv-aoaihub265060096545 (Key Vault)
    └─[has permissions to]─> ... (25 more Key Vaults)
```

### Impact Scope

- **Subscription:** ab48f397-fc82-4634-aa52-62dd91b3ebaa
- **Resource Groups Affected:** 16 unique resource groups
- **Total Resources at Risk:** 33 Azure Key Vaults
- **Lateral Movement Risk:** Direct access to all resources (no chaining required)

---

## Security Recommendations

### Immediate Actions (Priority 1)

1. **Review and Audit Permissions**
   - Conduct immediate audit of Alberto Polak's access requirements
   - Remove permissions to Key Vaults not required for current role
   - Implement least privilege access model

2. **Enable Multi-Factor Authentication (MFA)**
   - Enforce MFA for this high-privilege account
   - Consider implementing phishing-resistant MFA (FIDO2/Windows Hello)

3. **Implement Conditional Access**
   - Restrict access to trusted devices only
   - Implement location-based access policies
   - Require compliant device state

### Short-term Actions (Priority 2)

4. **Segregate Production and Non-Production Access**
   - Create separate accounts for production vs. development access
   - Implement Just-In-Time (JIT) access for production Key Vaults
   - Use Azure PIM (Privileged Identity Management) for elevation

5. **Enhanced Monitoring**
   - Enable Azure Key Vault logging for all accessed vaults
   - Configure alerts for unusual access patterns
   - Implement Microsoft Sentinel detection rules for this account

6. **Break Glass Account Review**
   - If this is a break-glass account, ensure proper controls are in place
   - Rotate credentials regularly
   - Implement secure credential storage

### Long-term Actions (Priority 3)

7. **Implement Service Principals**
   - Migrate automation tasks to service principals with limited scope
   - Reduce dependency on user accounts for system operations

8. **Regular Access Reviews**
   - Implement quarterly access certification process
   - Automated deprovisioning for unused permissions
   - Track permission usage analytics

9. **Zero Trust Architecture**
   - Implement continuous verification for all access requests
   - Move towards workload identity federation where possible
   - Implement network microsegmentation

---

## Conclusion

Alberto Polak represents a **significant security risk** with direct permissions to 33 Azure Key Vaults spanning production, security infrastructure, AI services, and identity management systems. The broad scope of access creates a large blast radius where a single compromised credential could impact:

- Production services and deployments
- Security monitoring and defense systems
- Identity and authentication infrastructure
- AI and modern workplace applications
- Financial and HR systems (payroll)

**Risk Score:** HIGH - Immediate attention required

The principle of least privilege should be applied urgently to reduce this blast radius. Consider implementing role-based access control (RBAC), Just-In-Time access, and proper segregation between production and non-production environments.

---

**Report Generated:** 2025-12-10  
**Analysis Tool:** Microsoft Security Graph - Blast Radius Query  
**Subscription ID:** ab48f397-fc82-4634-aa52-62dd91b3ebaa  
**Total Entities Analyzed:** 33
