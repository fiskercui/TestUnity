#ifndef UnpackNetWork_h
#define UnpackNetWork_h

#include <memory>
$Proto_Header$

//去掉0长度数组的警告
#pragma warning (disable:4200)
#pragma pack(1)
typedef struct st_protoHeader
{
	uint16_t len;
	uint16_t msg_id;
	uint16_t seq;
	uint32_t crc;
	char data[0];
} ProtoHeader;
#pragma pack()

struct ProtoPackTool
{
/** msgId 消息ID，protoBuf 返回的二进制（未解析），len 返回的二进制长度（未解析）,result(解析出来的二进制）   **/
	static VGAME_PROTO_EXPORT void getProtoFromByte(int msgId,const void* protoBuf,int len,char** result);
	
	
	static VGAME_PROTO_EXPORT bool getByteFromProto(int msgId,::google::protobuf::MessageLite* proto,char** byteArray,int &byteArrayLen );
};


#endif // ParseMsg_h__
