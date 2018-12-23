using ProtoBuf;

namespace Server.Data
{
    /// <summary>
    /// 内测返回给玩家虚拟币的逻辑
    /// </summary>
    [ProtoContract]
    public class FanHuanData
    {
        [ProtoMember(1)]
        public int OperationType=1;  //1 通知返还   2领取返还
        [ProtoMember(2)]
        public int GetType = 4; //领取的类 领取的类型    1一类型   2二类型  3有返还   4无返还
        [ProtoMember(3)]
        public int ErrorCode = 0;// 错误码
        [ProtoMember(4)]
        public int Diamond = 0; //非帮钻
        [ProtoMember(5)]
        public int VipLevel= 0;//可以进行兑换的VIP等级
    }
}
