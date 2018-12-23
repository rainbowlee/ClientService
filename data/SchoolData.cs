using System.Collections.Generic;
using ProtoBuf;
using System;
using GameServer.Logic;

namespace Server.Data
{

    [ProtoContract]
    public class SchoolOP
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        [ProtoMember(1)]
        public List<String> FieldNames;


        /// <summary>
        /// 更新的师徒数据
        /// </summary>
        [ProtoMember(2)]
        public SchoolData UpdateData;

        /// <summary>
        /// 角色ID
        /// </summary>
        [ProtoMember(3)]
        public int RoleID;

    }


    /// <summary>
    /// 师徒数据
    /// </summary>
    [ProtoContract]
    public class SchoolData
    {
        /// <summary>
        /// 副本的ID
        /// </summary>
        [ProtoMember(1)]
        public int Rid = 0;

        /// <summary>
        /// 我的老师
        /// </summary>
        [ProtoMember(2)]
        public int TeacherID = 0;

        /// <summary>
        /// 我的徒弟
        /// </summary>
        [ProtoMember(3)]
        public List<Student> Stds = new List<Student>();

        public List<Student> Students
        {
            get 
            {
                return Stds;
            }
        }

        /// <summary>
        /// 所有的宝箱
        /// </summary>
        [ProtoMember(4)]
        public List<TeacherBox> Boxes = new List<TeacherBox>();

        public List<TeacherBox> TeacherBoxs
        {
            get
            {
                return Boxes;
            }
        }

        /// <summary>
        /// 成为老师时间
        /// </summary>
        [ProtoMember(5)]
        public String LastAsTearcherTime="";

        /// <summary>
        /// 叛逃师门惩罚的结束时间
        /// </summary>
        [ProtoMember(6)]
        public String LastAsStudentTime = "";

        /// <summary>
        /// 操作的天
        /// </summary>
        [ProtoMember(7)]
        public String OpDay = "";

        /// <summary>
        /// 传功总次数
        /// </summary>
        [ProtoMember(8)]
        public int SendBoxCount= 0;

        /// <summary>
        /// 每天传功次数
        /// </summary>
        [ProtoMember(9)]
        public int DaySendBoxCount= 0 ;

        /// <summary>
        /// 每天传功次数
        /// </summary>
        [ProtoMember(10)]
        public int SettingClosed = 0;


        /// <summary>
        /// 叛逃惩罚
        /// </summary>
        public String LeaveTeacherPunishEndTime 
        {
            get { return LastAsStudentTime; }
            set { LastAsStudentTime = value; }
        }


        /// <summary>
        ///  上次提醒传功时间
        /// </summary>
        [ProtoMember(11)]
        public String RemindTeacherSendBoxTime=""; 

        /// <summary>
        /// 申请拜师时间
        /// </summary>
        public String _AppAddTeacherTime ="";

        /// <summary>
        /// 申请收徒时间
        /// </summary>
        public String _AppAddStudentTime="";


        /// <summary>
        /// 是否系统关闭
        /// </summary>
        /// <returns></returns>
        public bool isSettingClosed()
        {
            return SettingClosed > 0;
        }

        /// <summary>
        /// 空余宝箱位置
        /// </summary>
        /// <returns></returns>
        public int GetIdleBoxIndex()
        {
            List<int> list = new List<int>();
            foreach (TeacherBox box in TeacherBoxs)
            {
                list.Add(box.BoxIndex);
            }
            for (int i = 0; i < 4; i++)
            {
                if (!list.Contains(i))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 是不宝箱已经满了
        /// </summary>
        public bool HasBoxFull
        {
            get { return TeacherBoxs.Count >= 4; }
            set { }
        }

        /// <summary>
        /// 是否存在解锁的宝箱
        /// </summary>
        /// <returns></returns>
        public bool HasUnlockBox()
        {
            foreach (TeacherBox box in TeacherBoxs)
            {
                if (box.Status == 2)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获得某个box
        /// </summary>
        /// <param name="BoxIndex"></param>
        /// <returns></returns>
        public TeacherBox GetTeacherBox(int BoxIndex)
        {
            foreach (TeacherBox box in TeacherBoxs)
            {
                if (box.BoxIndex == BoxIndex)
                {
                    return box;
                }
            }
            return null;
        }

        /// <summary>
        /// 删除宝箱
        /// </summary>
        /// <param name="box"></param>
        public void RemoveTeacherBox(TeacherBox box)
        {
            TeacherBoxs.Remove(box);
        }


        private List<int> _ApplyStudents;

        /// <summary>
        /// 是否存在某位徒弟
        /// </summary>
        /// <param name="StudentID"></param>
        /// <returns></returns>
        public bool HasStudent(int StudentID)
        {
            foreach (Student std in Students)
            {
                if (std.RoleID == StudentID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool RemoveStudent(int StudentID)
        {
            foreach (Student std in Students)
            {
                if (std.RoleID == StudentID)
                {
                    std.RoleID = 0;
                    std.SendBoxCount = 0;
                    return true;
                }
            }
            return false;
        }

        public Student GetStudentData(int StudentID)
        {
            foreach (Student std in Students)
            {
                if (std.RoleID == StudentID)
                {
                    return std;
                }
            }
            return null;
        }

        public int MaxSudentNum = 3;

        private Student NewStudent()
        {
            Student student =  new Student
            {
                StudentIndex = Students.Count + 1
            };
            Students.Add(student);
            return student;
        }

        /// <summary>
        /// 申请徒弟列表
        /// </summary>
        public List<int> ApplyStudents
        {
            get
            {
                if (_ApplyStudents == null)
                {
                    _ApplyStudents = new List<int>();
                }
                return _ApplyStudents;
            }
        }

        /// <summary>
        /// 是否已经拜师
        /// </summary>
        /// <returns></returns>
        public bool HasTeacher
        {
            get { return TeacherID > 0; }
            set { }
        }



    }

    [ProtoContract]
    public class Student
    {
        /// <summary>
        /// 索引位置
        /// </summary>
        [ProtoMember(1)]
        public int StudentIndex;

        /// <summary>
        /// 传功次数
        /// </summary>
        [ProtoMember(2)]
        public int SendBoxCount;

        /// <summary>
        /// 弟子ID
        /// </summary>
        [ProtoMember(3)]
        public int RoleID;
    }

    /// <summary>
    /// 师傅传送的宝箱
    /// </summary>
    [ProtoContract]
    public class TeacherBox
    {
        /// <summary>
        /// 配置ID
        /// </summary>
        [ProtoMember(1)]
        public int BoxIndex;

        /// <summary>
        /// 经验数量
        /// </summary>
        [ProtoMember(2)]
        public long Exp;


        /// <summary>
        /// 配置
        /// </summary>
        [ProtoMember(3)]
        public int ConfigID;


        /// <summary>
        /// 状态
        /// </summary>
        [ProtoMember(4)]
        public int Status;

        public bool Unlock
        {
            get { return Status == 2; }
            set { }

        }

        /// <summary>
        /// 开启时间
        /// </summary>
        [ProtoMember(5)]
        public String OpenTime="";

    }

}
