#include "ProtoPackTool.h"

#define MAX_PROTOBUF_MEM_SIZE 40960
/////////////////////////////////
$Proto_StaticObject$
/////////////////////////////////
void ProtoPackTool::getProtoFromByte(int msgId,const void* protoBuf,int len,char** result)
{
$Proto_Content$
}

bool ProtoPackTool::getByteFromProto(int msgId,::google::protobuf::MessageLite* proto,char** byteArray,int &byteArrayLen )
{
		static char* protoBufMem=new char[MAX_PROTOBUF_MEM_SIZE];
		//memset(protoBufMem,0,512);
		int protoHeaderSize=sizeof(ProtoHeader);
		if(proto->SerializeToArray(protoBufMem+protoHeaderSize,MAX_PROTOBUF_MEM_SIZE-protoHeaderSize)){
			int dataLen=proto->GetCachedSize();
			ProtoHeader* ph=(ProtoHeader*)protoBufMem;
			//字节序问题, 在ServerTool里面做过转换了
			ph->len=dataLen+protoHeaderSize;
			ph->msg_id=msgId;
			*byteArray=protoBufMem;
			byteArrayLen=ph->len;
			return true;
		}else{
			return false;
		}
}


