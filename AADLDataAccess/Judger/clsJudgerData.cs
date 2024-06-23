﻿using AADL_DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using AADL_DataAccess.HelperClasses;

namespace AADLDataAccess.Judger
{
    public static class clsJudgerData
    {
        public enum enWhichID { JudgerID = 1, PractitionerID, PersonID }

        public static bool GetJudgerInfoByJudgerID(int InputJudgerID, ref int PractitionerID, ref int PersonID, ref bool IsLawyer, ref DateTime IssueDate,
                                                    ref int SubscriptionTypeID, ref int SubscriptionWayID, ref int CreatedByUserID, ref bool IsActive,
                                                    ref int? LastEditByUserID, ref Dictionary<int, string> CasesJudgerPracticesIDNameDictionary)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetJudgerInfoByJudgerID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@JudgerID", InputJudgerID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // Read first result set
                                if (reader.Read())
                                {
                                    PersonID = (int)reader["PersonID"];
                                    IsLawyer = (bool)reader["IsLawyer"];
                                    SubscriptionTypeID = (int)reader["SubscriptionTypeID"];
                                    SubscriptionWayID = (int)reader["SubscriptionWayID"];
                                }

                                // Read second result set
                                reader.NextResult();
                                if (reader.Read())
                                {
                                    PractitionerID = (int)reader["PractitionerID"];
                                    IssueDate = (DateTime)reader["IssueDate"];
                                    LastEditByUserID = reader["LastEditByUserID"] as int?;
                                    CreatedByUserID = (int)reader["CreatedByUserID"];
                                    IsActive = (bool)reader["IsActive"];
                                }

                                // Read third result set
                                reader.NextResult();
                                while (reader.Read())
                                {
                                    // Process the data from JudgerCasesPractices table
                                    int judgerCaseTypeId = reader.GetInt32(reader.GetOrdinal("JudgeCaseTypeID"));
                                    string judgerCaseTypeName = reader.GetString(reader.GetOrdinal("JudgeCaseTypeName"));

                                    CasesJudgerPracticesIDNameDictionary.Add(judgerCaseTypeId, judgerCaseTypeName);
                                }

                                isFound = true;
                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsJudgerData class, get info by PractitionerID():\n" + ex.Message,
                    EventLogEntryType.Error);
            }
            catch (Exception ex)
            {

                clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsJudgerData class, get info by PractitionerID():\n" + ex.Message,
                    EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }

        public static bool GetJudgerInfoByPractitionerID(int InputPractitionerID, ref int JudgerID, ref int PersonID, ref bool IsLawyer, ref DateTime IssueDate,
                                                            ref int SubscriptionTypeID, ref int SubscriptionWayID, ref int CreatedByUserID, ref bool IsActive,
                                                            ref int? LastEditByUserID, ref Dictionary<int, string> CasesJudgerPracticesIDNameDictionary)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetJudgerInfoByPractitionerID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PractitionerID", InputPractitionerID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // Read first result set
                                if (reader.Read())
                                {
                                    PersonID = (int)reader["PersonID"];
                                    IsLawyer = (bool)reader["IsLawyer"];
                                    SubscriptionTypeID = (int)reader["SubscriptionTypeID"];
                                    SubscriptionWayID = (int)reader["SubscriptionWayID"];
                                }

                                // Read second result set
                                reader.NextResult();
                                if (reader.Read())
                                {
                                    JudgerID = (int)reader["JudgerID"];
                                    IssueDate = (DateTime)reader["IssueDate"];
                                    LastEditByUserID = reader["LastEditByUserID"] as int?;
                                    CreatedByUserID = (int)reader["CreatedByUserID"];
                                    IsActive = (bool)reader["IsActive"];
                                }

                                // Read third result set
                                reader.NextResult();
                                while (reader.Read())
                                {
                                    // Process the data from JudgerCasesPractices table
                                    int judgerCaseTypeId = reader.GetInt32(reader.GetOrdinal("JudgeCaseTypeID"));
                                    string judgerCaseTypeName = reader.GetString(reader.GetOrdinal("JudgeCaseTypeName"));

                                    CasesJudgerPracticesIDNameDictionary.Add(judgerCaseTypeId, judgerCaseTypeName);
                                }

                                isFound = true;
                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsJudgerData class, get info by PractitionerID():\n" + ex.Message,
                    EventLogEntryType.Error);
            }
            catch (Exception ex)
            {

                clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsJudgerData class, get info by PractitionerID():\n" + ex.Message,
                    EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }

        public static bool GetJudgerInfoByPersonID(int InputPersonID, ref int JudgerID, ref int PractitionerID, ref bool IsLawyer, ref DateTime IssueDate,
                                                            ref int SubscriptionTypeID, ref int SubscriptionWayID, ref int CreatedByUserID, ref bool IsActive,
                                                            ref int? LastEditByUserID, ref Dictionary<int, string> CasesJudgerPracticesIDNameDictionary)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetJudgerInfoByPersonID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", InputPersonID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // Read first result set
                                if (reader.Read())
                                {
                                    PractitionerID = (int)reader["PractitionerID"];
                                    IsLawyer = (bool)reader["IsLawyer"];
                                    SubscriptionTypeID = (int)reader["SubscriptionTypeID"];
                                    SubscriptionWayID = (int)reader["SubscriptionWayID"];
                                }

                                // Read second result set
                                reader.NextResult();
                                if (reader.Read())
                                {
                                    JudgerID = (int)reader["JudgerID"];
                                    IssueDate = (DateTime)reader["IssueDate"];
                                    LastEditByUserID = reader["LastEditByUserID"] as int?;
                                    CreatedByUserID = (int)reader["CreatedByUserID"];
                                    IsActive = (bool)reader["IsActive"];
                                }

                                // Read third result set
                                reader.NextResult();
                                while (reader.Read())
                                {
                                    // Process the data from JudgerCasesPractices table
                                    int judgerCaseTypeId = reader.GetInt32(reader.GetOrdinal("JudgeCaseTypeID"));
                                    string judgerCaseTypeName = reader.GetString(reader.GetOrdinal("JudgeCaseTypeName"));

                                    CasesJudgerPracticesIDNameDictionary.Add(judgerCaseTypeId, judgerCaseTypeName);
                                }

                                isFound = true;
                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsJudgerData class, get info by PractitionerID():\n" + ex.Message,
                    EventLogEntryType.Error);
            }
            catch (Exception ex)
            {

                clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsJudgerData class, get info by PractitionerID():\n" + ex.Message,
                    EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }

        /// <summary>
        /// Can create a new Judger profile in database, and verify if it has a practitioner profile  or not .
        /// by default it is lawyer = false 
        /// <returns> List of two new IDs ([0]NewJudgerID, [1]NewPractitionerID) </returns>
        public static (int NewJudgerID, int NewPractitionerID) AddNewJudger(int PersonID, int SubscriptionTypeID, int SubscriptionWayID, int CreatedByUserID,
                                                                                bool IsActive, Dictionary<int, string> CasesJudgerPracticesIDNameDictionary)
        {
            int newJudgerID = -1, newPractitionerID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewJudger", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@SubscriptionTypeID", SubscriptionTypeID);
                        command.Parameters.AddWithValue("@SubscriptionWayID", SubscriptionWayID);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@IsActive", IsActive);


                        // Create table-valued parameter for cases IDs
                        var JudgerCasesTable = new DataTable();

                        JudgerCasesTable.Columns.Add("CaseID", typeof(int));

                        // Iterate over cases and insert into  table-valued parameter
                        foreach (int JudgerCaseID in CasesJudgerPracticesIDNameDictionary.Keys)
                            JudgerCasesTable.Rows.Add(JudgerCaseID);

                        // Add table-valued parameter
                        SqlParameter parameter = command.Parameters.AddWithValue("@JudgerCasesPracticesIds", JudgerCasesTable);
                        parameter.SqlDbType = SqlDbType.Structured;
                        parameter.TypeName = "dbo.HashSetOfInt";// Replace "YourHashSetType" with the actual SQL Server type name

                        // Add output parameter for the NewJudgerID
                        SqlParameter newJudgerIDParameter = new SqlParameter("@NewJudgerID", SqlDbType.Int);
                        newJudgerIDParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(newJudgerIDParameter);

                        // Add output parameter for the NewJudgerID
                        SqlParameter newPractitionerParameter = new SqlParameter("@OutputPractitionerID", SqlDbType.Int);
                        newPractitionerParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(newPractitionerParameter);

                        connection.Open();

                        command.ExecuteNonQuery();

                        newJudgerID = (int)command.Parameters["@NewJudgerID"].Value;
                        newPractitionerID = (int)command.Parameters["@OutputPractitionerID"].Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                clsDataAccessSettings.WriteEventToLogFile("Judger data access class , add to database method()\nSQL EXCEPTION:" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WriteEventToLogFile("Judger data access class , add to database method()\n" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return (newJudgerID, newPractitionerID);
        }

        /// <summary>
        /// I passed the only available  or allowed parameter for updating 
        /// </summary>
        /// <returns>Is it updated successfully or not </returns>
        public static bool UpdateJudger(int JudgerID, int PractitionerID, int SubscriptionTypeID, int SubscriptionWayID, bool IsActive,
                                            int? LastEditByUserID, Dictionary<int, string> CasesJudgerPracticesIDNameDictionary)
        {
            int EffectedRows = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_UpdateJudger", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@JudgerID", JudgerID);
                        command.Parameters.AddWithValue("@PractitionerID", PractitionerID);
                        command.Parameters.AddWithValue("@SubscriptionTypeID", SubscriptionTypeID);
                        command.Parameters.AddWithValue("@SubscriptionWayID", SubscriptionWayID);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@LastEditByUserID", LastEditByUserID);


                        // Create table-valued parameter for cases IDs
                        var CasesTable = new DataTable();
                        CasesTable.Columns.Add("CaseID", typeof(int));

                        // Iterate over cases and insert into  table-valued parameter
                        foreach (int CaseID in CasesJudgerPracticesIDNameDictionary.Keys)
                            CasesTable.Rows.Add(CaseID);

                        // Add table-valued parameter
                        SqlParameter parameter = command.Parameters.AddWithValue("@JudgerCasesPracticesIds", CasesTable);
                        parameter.SqlDbType = SqlDbType.Structured;
                        parameter.TypeName = "dbo.HashSetOfInt";// Replace "YourHashSetType" with the actual SQL Server type name


                        connection.Open();

                        EffectedRows = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                clsDataAccessSettings.WriteEventToLogFile("Judger data access class , update  method()\n" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WriteEventToLogFile("Judger data access class , update  method()\n" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }

            return EffectedRows > 0;
        }

        public static bool Deactivate(int judgerID)
            => clsDataAccessHelper.Deactivate("SP_DeactivateJudger", "JudgerID", judgerID);

        public static bool Activate(int judgerID)
            => clsDataAccessHelper.Activate("SP_ActivateJudger", "JudgerID", judgerID);

        public static bool DeletePermanently(int? judgerID)
            => clsDataAccessHelper.Delete("SP_DeleteJudgerPermanently", "JudgerID", judgerID);

        public static bool IsJudgerExist(int ID, enWhichID WhichID)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_IsJudgerExist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID", ID);
                        command.Parameters.AddWithValue("@WhichID", (int)WhichID);

                        // Add output parameter for the IsDeleted
                        SqlParameter returnValueParameter = new SqlParameter("@IsExist", SqlDbType.Bit);
                        returnValueParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(returnValueParameter);

                        connection.Open();

                        command.ExecuteNonQuery();

                        isExist = (bool)command.Parameters["@IsExist"].Value;
                    }
                }
            }

            catch (Exception ex)
            {
                clsDataAccessSettings.WriteEventToLogFile("clsPerson Data access layer, is exists(RegulatorID) method\n" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                isExist = false;
            }

            return isExist;
        }
    
        public static int Count()
            => clsDataAccessHelper.Count("SP_GetTotalJudgersCount");

        public static DataTable GetJudgersPerPage(ushort pageNumber, uint rowsPerPage)
            => clsDataAccessHelper.AllInPages(pageNumber, rowsPerPage, "SP_GetJudgersPerPage");
    }

}