﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace ACP
{
    public class supplierClass
    {
        dbClass db = new dbClass();
        public DataTable fetchRecord() {
            return db.getRecord("select * from vwSupplier");
        }
        public DataTable InfotCat()
        {
            return db.getRecord("select * from infoCategory");
        }


        //Address CRUD Operation
        public int addressID() {
            int currentMaxValue = 0;
            currentMaxValue = db.autoIncrement("SELECT ISNULL(MAX(addressID), 0) FROM address");
            return currentMaxValue;
        }
        public DataTable fetch_address() 
        {
            return db.getRecord("select addressID as 'Address ID', [desc] as 'Description', LTRIM(RTRIM(REPLACE(ISNULL([address],' ')+', '+ISNULL (city,' ')+', '+ISNULL(province,' '), '  ',' '))) as 'Address', transDate as 'Date Created' from vwAddress");
        }
        public void address(string AddressID,string desc,string address, string city,string province, string remarks ) {
            try
            {
                SqlConnection conn = db.getConnection();
               conn.Open();
               SqlCommand cmd = new SqlCommand("sp_Supplier", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@desc", "ADDRESS");
               cmd.Parameters.AddWithValue("@Id", "");
               cmd.Parameters.AddWithValue("@action", "INSERT");
               cmd.Parameters.AddWithValue("@AddressID", AddressID);
               cmd.Parameters.AddWithValue("@addressDesc", desc);
               cmd.Parameters.AddWithValue("@address", address);
               cmd.Parameters.AddWithValue("@city", city);
               cmd.Parameters.AddWithValue("@province", province);
               cmd.Parameters.AddWithValue("@remarks", remarks);
               cmd.ExecuteNonQuery();
               conn.Close();
               MessageBox.Show("Successfully Inserted","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
       
        }

        //Supplier Crud 
        public void insertSupplier(string suppID, string TID, string suppDesc, string agent, string infoCatID, string addressID)
        {
            try
            {
                SqlConnection conn = db.getConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_Supplier", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desc", "SUPPLIER");
                cmd.Parameters.AddWithValue("@Id", "");
                cmd.Parameters.AddWithValue("@action", "INSERT");
                cmd.Parameters.AddWithValue("@suppID", suppID);
                cmd.Parameters.AddWithValue("@TID", TID);
                cmd.Parameters.AddWithValue("@suppDesc", suppDesc);
                cmd.Parameters.AddWithValue("@agent", agent);
                cmd.Parameters.AddWithValue("@infoCatID", infoCatID);
               // cmd.Parameters.AddWithValue("@infoCatID", infoCatID);
                cmd.Parameters.AddWithValue("@addressID", addressID);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully Inserted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable getSuppByID(string suppID) {


            return db.getRecord("Select * from fc_sPInfo('"+suppID+"')");
             
        
        }

        //Record Type CRUD
        public int TID(){
            int currentMaxValue = 0;
            currentMaxValue = db.autoIncrement("SELECT ISNULL(MAX(TID), 0) FROM recordType");
            return currentMaxValue;
        }
        public DataTable fetchRType() {

            return db.getRecord("Select * From vwRecordType");
        }
        public void insertRecordType(string TID,string tDesc,string rType, string processDesc) {

            try
            {
                SqlConnection conn = db.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_Supplier", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@desc", "RECORDTYPE");
            cmd.Parameters.AddWithValue("@Id", "");
            cmd.Parameters.AddWithValue("@action", "INSERT");
            cmd.Parameters.AddWithValue("@TID", TID);
            cmd.Parameters.AddWithValue("@tDesc", tDesc);
            cmd.Parameters.AddWithValue("@rType", rType);
            cmd.Parameters.AddWithValue("@processDesc", processDesc);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully Inserted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

    
}
