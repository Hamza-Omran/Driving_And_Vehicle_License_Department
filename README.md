# DVLD – Driving & Vehicle License Department System

A full-featured **desktop management system** for handling driving licenses, vehicle-related records, and driver workflows, built using **C# and .NET Framework** with a clean **3-layer architecture**.

**Context:** Desktop Application Engineering Project  
**Platform:** Windows  
**Architecture:** 3-Layer (DAL / BLL / Presentation)

---

## System Overview

DVLD is designed to model the **real operational workflow** of a driving and vehicle licensing authority.

Rather than a simple CRUD application, the system implements:
- Multi-step application lifecycles
- Strict business rules and validations
- Role-based internal users
- License issuance, renewal, replacement, detention, and release
- Test scheduling and prerequisite enforcement

The focus is on **architecture, data integrity, and workflow correctness**.

---

## Architecture

The application follows a strict **3-Layer Architecture**, ensuring separation of concerns and long-term maintainability.

### 1. Data Access Layer (DAL)
Responsible for all database communication.

- SQL Server integration via ADO.NET
- Encapsulated CRUD operations
- Centralized connection management
- Data mapping between database and business objects

### 2. Business Logic Layer (BLL)
Implements all domain rules and workflows.

- Application lifecycle enforcement
- Test prerequisite validation
- License eligibility logic
- Detention and release rules
- Fee calculations and state transitions

### 3. Presentation Layer
Windows Forms–based user interface.

- Workflow-driven forms
- Role-aware navigation
- Data validation and feedback
- Central dashboard for system access

---

## Core System Modules

### 1. Person & Driver Management
- Centralized person records
- National ID uniqueness
- Driver creation and tracking
- License history per person

### 2. Applications & Licensing
- Local driving license applications
- License issuance, renewal, and replacement
- International license issuance
- Application status tracking

### 3. Test Management
- Vision, Written, and Practical tests
- Appointment scheduling
- Test result recording
- Retake handling with fees
- Enforced test order dependencies

### 4. License Detention
- License detention for violations
- Fine handling
- Release workflow
- Detention history tracking

### 5. Users & Security
- System user management
- Authentication and access control
- Activity tracking (CreatedByUserID)
- Password protection

---

## Key Engineering Highlights

- Strict **layer separation** (no UI ↔ DB coupling)
- Workflow-driven business logic
- State-based application handling
- License lifecycle management
- Reusable domain entities
- SQL Server–backed relational design (15+ tables)
- Realistic government-style rules enforcement

---

## Technology Stack

- **Language:** C# (.NET Framework)
- **UI:** Windows Forms
- **Database:** Microsoft SQL Server
- **Data Access:** ADO.NET
- **Architecture:** 3-Layer (DAL / BLL / UI)

---

## Engineering Focus

This project emphasizes:
- Enterprise-style desktop architecture
- Business rule enforcement
- Data integrity and validation
- Complex workflow modeling
- Maintainable and scalable code structure

It is intentionally designed to resemble **real administrative systems**, not simple academic demos.

---

## Documentation

To keep the README focused, full technical details are available separately:
- Database schema and entities
- Business rules and workflows
- UI module breakdown
- Installation and configuration steps

See the `doc.md` file for complete documentation.

---

**Status:** Completed academic system  
**Scope:** Desktop system architecture & business logic design  
**Platform:** Windows (.NET Framework) 
