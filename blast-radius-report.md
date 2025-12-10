# Blast Radius Analysis Report: Alberto Polak

**Analysis Date:** December 10, 2025  
**Subject:** Alberto Polak (User)  
**Entity Type:** User Account

## Executive Summary

This report provides a comprehensive analysis of the blast radius for user **Alberto Polak**. The blast radius represents the potential scope of impact if this user account were to be compromised. The analysis identified **33 Azure Key Vault resources** that are directly accessible by Alberto Polak through granted permissions.

### Key Findings

- **Total Impacted Resources:** 33 Key Vaults
- **Direct Access Path:** All resources have a single-step access path (direct permissions)
- **Resource Type:** Microsoft Azure Key Vault (`microsoft.keyvault/vaults`)
- **Subscription:** All resources belong to subscription `[REDACTED]`

## Risk Assessment

### Overall Risk Level: **HIGH** ⚠️

The high risk classification is based on the following factors:

1. **Extensive Access Scope:** Alberto Polak has permissions to 33 different Key Vaults across multiple resource groups
2. **Sensitive Resource Type:** Key Vaults store critical secrets, certificates, and encryption keys
3. **Cross-Environment Access:** Access spans multiple environments including production, development, and demo resources
4. **Centralized Impact:** Compromise of this single user account could expose secrets across the entire organization

## Detailed Entity Analysis

### Risk Level Classification Methodology

Entities have been classified into risk tiers based on:
- Resource naming patterns (production, demo, development environments)
- Resource group context
- Functional purpose indicators

---

### 🔴 CRITICAL RISK - Production & Core Infrastructure (9 entities)

These Key Vaults appear to support production systems and core infrastructure based on naming patterns:

| Rank | Key Vault Name | Resource Group | Risk Factors |
|------|----------------|----------------|--------------|
| 1 | **wg-prod** | wg-prod-deployments | Production deployment vault |
| 2 | **payroll01** | woodgrove-sentinelgraph | Payroll system - sensitive data |
| 3 | **CoreId-kv-c2gq** | coreid-rg-0x2y | Core identity infrastructure |
| 4 | **ModernWork-kv-xa1e** | modernwork-rg-0x2y | Modern work infrastructure |
| 5 | **HubVNet-kv-l3sp** | hubvnet-rg-0x2y | Hub virtual network infrastructure |
| 6 | **WoodgroveAutomationKV** | woodgrove-userprovisioning-rg | User provisioning automation |
| 7 | **DesiredStateManagementKV** | ztenv01desiredstate | Zero-trust desired state management |
| 8 | **wg-verifiedemployee** | woodgroveverifiedemployee | Verified employee credentials |
| 9 | **sentineldemos** | woodgrove-rg | Sentinel security demos |

**Impact if Compromised:** Complete exposure of production secrets, potential service disruption, data breach risk

---

### 🟠 HIGH RISK - Security & Specialized Services (8 entities)

Key Vaults supporting security infrastructure, AI services, and specialized functions:

| Rank | Key Vault Name | Resource Group | Risk Factors |
|------|----------------|----------------|--------------|
| 10 | **wg-entra-tls-inspection** | woodgrove-rg | TLS inspection for Entra ID |
| 11 | **fw-cert-kv-eodl1fmPodQrU** | woodgrove-rg | Firewall certificate management |
| 12 | **fw-cert-kv-4FYAYX0P5xO3H** | woodgrove-rg | Firewall certificate management |
| 13 | **fw-cert-kv-7Ar5j8JJkPbB1** | woodgrove-rg | Firewall certificate management |
| 14 | **kv-aoaihub265060096545** | woodgrove-mdc-ai | AI hub services |
| 15 | **kv-wgaihub098811020122** | wg-ai-hub | AI hub services |
| 16 | **wgyubipreregkv** | woodgroveyubicopoc | Yubikey pre-registration |
| 17 | **myTLSKeyVault** | woodgrove-rg | TLS certificate management |

**Impact if Compromised:** Security infrastructure breach, firewall certificate exposure, AI service compromise

---

### 🟡 MEDIUM RISK - MDC & Arc Resources (8 entities)

Microsoft Defender for Cloud and Azure Arc related Key Vaults:

| Rank | Key Vault Name | Resource Group | Risk Factors |
|------|----------------|----------------|--------------|
| 18 | **woodgrove-MDC-Vault** | woodgrove-mdc-rg | MDC production vault |
| 19 | **woodgrove-MDC-Vault-Demo** | woodgrove-mdc-rg | MDC demo vault |
| 20 | **kv-woodgrove-demo-pken** | woodgrove-mdc-rg | MDC demo resources |
| 21 | **arcboxksswlrmzv52lg** | woodgrove-mdc-rg | Arc-enabled infrastructure |
| 22 | **arcbox5cmre4mg2r2vw** | woodgrove-mdc-arc | Arc-enabled infrastructure |
| 23 | **kv-mdcagentvxbnu** | rg-mdcagent | MDC agent configuration |
| 24 | **kv-zavaprivatey2c2v** | rg-mdcagent-validation | MDC agent validation |
| 25 | **mdtiworkbookm5xeucozid** | woodgrove-rg | MDC threat intelligence |

**Impact if Compromised:** Security monitoring blind spots, Arc infrastructure exposure

---

### 🟢 LOWER RISK - Development, Demo & Test Resources (8 entities)

Key Vaults primarily used for development, testing, and demonstration purposes:

| Rank | Key Vault Name | Resource Group | Risk Factors |
|------|----------------|----------------|--------------|
| 26 | **woodgrove-dev-kv** | woodgrove-rg | Development environment |
| 27 | **VmsParkcity** | woodgrove-alpine | Alpine/SAP VMs |
| 28 | **parkcitySAP-KV** | woodgrove-alpine | SAP environment |
| 29 | **myaccountlinkedin** | appsvc_linux_centralus_basic | LinkedIn account integration |
| 30 | **MyKeyVault12** | woodgrove-rg | Generic/test vault |
| 31 | **woodgrove-ksi-keyvault** | woodgrove-rg | KSI (test) vault |
| 32 | **kv-ignite-adatum** | ignite-woodgroove | Ignite conference demo |
| 33 | **DCEDCRKeyVault** | woodgrove-rg | Data collection endpoint/rule |

**Impact if Compromised:** Limited production impact, potential exposure of test data and development credentials

---

## Attack Path Analysis

All 33 resources share the same attack path structure:

```
Alberto Polak (user)
    └─[has permissions to]→ Key Vault Resource
```

**Path Characteristics:**
- **Path Length:** 1 (direct access)
- **Edge Type:** Permission-based access
- **No Intermediate Hops:** Direct permission grants eliminate the need for lateral movement

This direct access pattern means that if Alberto Polak's account is compromised, an attacker immediately gains access to all 33 Key Vaults without needing to perform privilege escalation or lateral movement.

## Recommendations

### Immediate Actions (Within 24 hours)

1. **Review Permission Necessity:** Audit whether Alberto Polak requires access to all 33 Key Vaults
2. **Implement MFA:** Ensure strong multi-factor authentication is enabled for this account
3. **Enable Monitoring:** Set up alerts for any Key Vault access by this account
4. **Review Recent Activity:** Check audit logs for any suspicious access patterns

### Short-term Actions (Within 1 week)

1. **Apply Least Privilege:** Remove unnecessary Key Vault permissions
2. **Segregate Access:** Separate production and non-production access to different accounts/groups
3. **Implement Just-In-Time Access:** Use Azure PIM for elevated Key Vault access
4. **Conditional Access Policies:** Enforce stricter access controls based on location, device compliance

### Long-term Actions (Within 1 month)

1. **Role Segmentation:** Create role-based access groups instead of individual user permissions
2. **Access Reviews:** Implement quarterly access reviews for all Key Vault permissions
3. **Break Glass Procedures:** Document and test procedures for emergency access scenarios
4. **Zero Trust Implementation:** Implement comprehensive zero-trust controls across all Key Vaults

## Technical Details

### Resource Distribution by Resource Group

| Resource Group | Count | Category |
|----------------|-------|----------|
| woodgrove-rg | 10 | Primary resource group |
| woodgrove-mdc-rg | 4 | Microsoft Defender for Cloud |
| woodgrove-alpine | 2 | SAP/Alpine environment |
| wg-prod-deployments | 1 | Production deployments |
| coreid-rg-0x2y | 1 | Core identity |
| modernwork-rg-0x2y | 1 | Modern work |
| hubvnet-rg-0x2y | 1 | Hub network |
| Others | 13 | Various specialized groups |

### Subscription Information

All resources are located in the same Azure subscription:
- **Subscription ID:** `[REDACTED]`

This concentration in a single subscription increases the blast radius impact.

## Conclusion

The blast radius analysis reveals that Alberto Polak has extensive access to sensitive Key Vault resources across the organization. With 33 Key Vaults accessible through direct permissions, this account represents a significant security risk if compromised. The predominance of production and security-critical resources in the blast radius necessitates immediate action to reduce the attack surface and implement stronger access controls.

### Risk Summary
- **Severity:** HIGH
- **Exposure:** 33 Key Vault resources
- **Attack Complexity:** LOW (single-step direct access)
- **Impact:** SEVERE (organization-wide secret exposure potential)

---

*Report generated automatically based on security graph analysis*  
*For questions or concerns, contact your security team*
