#!/usr/bin/python
import protoMaker

protoMaker.out_cmd='--c_out='
protoMaker.cpp_output="../server/proto/"
protoMaker.protoc_cmd="protoc-c"
protoMaker.loadXML(r'proto.xml')
protoMaker.writeEnum()
protoMaker.writeDefine()
protoMaker.writeMessage('proto_src')
protoMaker.writeMsggroup()
protoMaker.walk_dir("proto_src")
