import protoMaker
import time
import os

os.system(r'del proto_src\\*.proto')
os.system(r'del luaproto\\protobuf\\*.lua') 
os.system(r'del jsproto\\*.js') 

protoMaker.cpp_output="./netproto/"
protoMaker.lua_output="./luaproto/protobuf/" 
protoMaker.js_output="./jsproto/" 

protoMaker.loadXML(r'proto.xml')

protoMaker.writeEnum()
protoMaker.writeEnumLua()
protoMaker.writeEnumJS() 
protoMaker.writeDefine()
protoMaker.writeMessage('proto_src')
protoMaker.writeMsggroup()
# protoMaker.walk_dir("proto_src")
# protoMaker.walk_lua("proto_src")


protoMaker.walk_csharp("proto_src")
protoMaker.write_luainit(protoMaker.lua_output) 

#cwd = os.getcwd()
#print cwd

time.sleep(1)
#os.system("dllexport.bat")
os.system("copy2client.bat")
print 'finished'
time.sleep(4)

