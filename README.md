Database Change Monitor: Tables vs. Indexes
A database monitoring utility designed to detect, log, and analyze real-time change events (DDL/DML) on 
database Tables versus Indexes. This project tracks schema modifications, index rebuilds, fragmentation shifts, and table updates to provide clear operational insights into database performance and structural changes.
---
Features
Event Tracking: Captures real-time changes to table structures and index definitions.
Table vs. Index Comparison: Compares the impact and frequency of updates on base tables against associated indexes.
Performance Impact Analysis: Monitors index fragmentation and build/rebuild events triggered by heavy table modifications.
Audit Logging: Maintains a structured event log for schema drift, index creation, dropping, and structural alterations.
---
Key Use Cases
Schema Drift Detection: Identify unexpected table or index modifications across environments.
Index Optimization: Track redundant or unused indexes following major table write operations.
Database Auditing: Keep a clear trail of DDL changes impacting critical database objects.
---
Repository Structure
