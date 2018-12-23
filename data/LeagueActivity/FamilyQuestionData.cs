using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
    /// <summary>
    /// 活动答题数据
    /// </summary>
    [ProtoContract]
    public class FamilyQuestionData
    {
        /// <summary>
        /// 当前题目数
        /// </summary>
        [ProtoMember(1)]
        public int currentNum = 0;

        /// <summary>
        /// 题目内容
        /// </summary>
        [ProtoMember(2)]
        public string question = "";

        /// <summary>
        /// 连续答队的题目数
        /// </summary>
        [ProtoMember(3)]
        public int comb = 0;

        /// <summary>
        /// 累计经验
        /// </summary>
        [ProtoMember(4)]
        public long totalExp = 0;

		/// <summary>
		/// 题目id
		/// </summary>
		[ProtoMember(5)]
		public long questionId = 0;

		/// <summary>
		/// 选项A
		/// </summary>
		[ProtoMember(6)]
		public string anwserA = "";

		/// <summary>
		/// 选项B
		/// </summary>
		[ProtoMember(7)]
		public string anwserB = ""; 
	}

    /// <summary>
    /// 活动答题数据
    /// </summary>
    [ProtoContract]
    public class FamilyQuestionAnswerList
    {
        /// <summary>
        /// 当前题目数
        /// </summary>
        [ProtoMember(1)]
        public List<string> answers;
	}
}