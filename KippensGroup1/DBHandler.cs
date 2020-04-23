﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KippensGroup1
{
    public class DBHandler
    {
        private string connectionString;

        public DBHandler(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool checkIfDBExist()
        {
            MySqlConnection db = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("USE kippens; SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'kippens'", db);
            // checks if database exist
            try
            {
                db.Open();
                var reader = cmd.ExecuteReader();
                db.Close();
            }catch(Exception e)
            {
                return false;
            }
                       
            return true;
        }

        public void createDB()
        {
            MySqlConnection db = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("CREATE DATABASE kippens;", db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            cmd = new MySqlCommand("USE kippens; create table Role(roleID int AUTO_INCREMENT NOT NULL, Name Varchar(50) NOT NULL, Description Varchar(900), PRIMARY KEY(roleID)); ", db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();


            cmd = new MySqlCommand("USE kippens; create table User(userID int NOT NULL AUTO_INCREMENT, name varchar(50) NOT NULL, username varchar(50) NOT NULL, email varchar(50) NOT NULL,password varchar(128) NOT NULL,number varchar(15) NULL,roleID int NOT NULL,PRIMARY KEY(userID),FOREIGN KEY(roleID) REFERENCES Role(roleID)); ", db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            cmd = new MySqlCommand("USE kippens; create table Volunteer(volunteerID int AUTO_INCREMENT NOT NULL,userID int NOT NULL,name Varchar(50) NOT NULL,role varchar(900) NOT NULL,PRIMARY KEY(volunteerID),FOREIGN KEY(userID) REFERENCES User(userID)); ", db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            cmd = new MySqlCommand("USE kippens; create table Donation(Name Varchar(50) NOT NULL,description Varchar(900) NOT NULL,userID int NOT NULL,donationID int NOT NULL AUTO_INCREMENT,time DATETIME NOT NULL,roleID int NOT NULL,QUANTITY int NOT NULL,PRIMARY KEY(donationID),FOREIGN KEY(userID) REFERENCES User(userID),FOREIGN KEY(roleID) REFERENCES Role(roleID)); ", db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            cmd = new MySqlCommand("USE kippens; create table Report(filePath Varchar(200) NOT NULL,timeCreated Time NOT NULL,frequency varchar(50) NOT NULL,reportID int NOT NULL,roleID int NOT NULL AUTO_INCREMENT,FOREIGN KEY(roleID) REFERENCES Role(roleID),PRIMARY KEY(reportID)); ", db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            cmd = new MySqlCommand("USE kippens; create table Transactions(transactionID int NOT NULL AUTO_INCREMENT,time DateTime NOT NULL,roleID int NOT NULL,name Varchar(50) NOT NULL,description Varchar(900) NOT NULL,userID int NOT NULL,QUANTITY int NOT NULL,PRIMARY KEY(transactionID),FOREIGN KEY(userID) REFERENCES User(userID),FOREIGN KEY(roleID) REFERENCES Role(roleID));", db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            db.Close();
        }
    }
}
