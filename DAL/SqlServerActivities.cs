﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using IDAL;
using Models;

namespace DAL
{
    public class SqlServerActivities:IActivities
    {
        public DataTable SelectxxTop4()
        {
            string sql = "select Top 4 * from Activities where Act_grade='小学' order by Click_num desc";
            return DBHelper.GetFillData(sql);
        }
        public DataTable SelectczTop4()
        {
            string sql = "select Top 4 * from Activities where Act_grade='初中' order by Click_num desc";
            return DBHelper.GetFillData(sql);
        }
        public DataTable SelectgzTop4()
        {
            string sql = "select Top 4 * from Activities where Act_grade='高中' order by Click_num desc";
            return DBHelper.GetFillData(sql);
        }
        public int InsertActivity(Activities activities)
        {
            string sql = "insert into Activities(Act_id,Act_theme,Act_time,Act_content,Act_address,Spo_id,Act_images,Act_grade) values(@Act_id,@Act_theme,@Act_time,@Act_content,@Act_address,@Spo_id,@Act_images,@Act_grade,@Act_grade)";
            SqlParameter[] para =
            {
                new SqlParameter ("@Act_id",activities.Act_id),
                new SqlParameter ("@Act_theme",activities.Act_theme),
                new SqlParameter ("@Act_time",activities.Act_time),
                new SqlParameter ("@Act_content",activities.Act_content),
                new SqlParameter ("@Act_address",activities.Act_address),
                new SqlParameter ("@Spo_id",activities.Spo_id),
                new SqlParameter ("@Act_images",activities.Act_images),
                new SqlParameter ("@Act_grade",activities.Act_grade)
            };
            return DBHelper.GetExcuteNonQuery(sql, para);
        }
        public int DeleteActivity(int Act_id)
        {
            SqlParameter[] sp = { new SqlParameter("@Act_id", Act_id) };
            return DBHelper.GetExcuteNonQuery("DeleteActivity", System.Data.CommandType.StoredProcedure, sp);
        }
    }
}
